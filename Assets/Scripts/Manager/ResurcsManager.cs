using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResurcsManager : MonoBehaviour
{
    public static ResurcsManager S;


    public Dictionary<Res,int> ResTempDicRemove,ResTempDicAdd;
    
    private Conector conect;

    private void Start()
    {
        S = this;
        GameObject connectorObject = GameObject.Find("Conector");
        conect = connectorObject.AddComponent<Conector>(); 
        ResTempDicRemove = new Dictionary<Res, int>()
        {
            [Res.power] = 0,[Res.piple] = 0,[Res.gold]  = 0,[Res.grass] = 0,
            [Res.hey]   = 0,[Res.cow]   = 0,[Res.milk]  = 0,
        };
        ResTempDicAdd = new Dictionary<Res, int>()
        {
            [Res.power] = 2,[Res.piple] = 2,[Res.gold]  = 0,[Res.grass] = 0,
            [Res.hey]   = 0,[Res.cow]   = 0,[Res.milk]  = 0,
        };
    }
    // обнулення темпового словника
    public void ObnulenniaResurcesTempDic()
    {
        foreach (var res in ResTempDicRemove)
        {
            ResTempDicAdd[res.Key] = 0;
        }
        foreach (var res in ResTempDicAdd)
        {
            ResTempDicRemove[res.Key] = 0;
        }
    }
    // Занесення в темповий словник витрати минулого тижня
    public void ZanesenniaResurcesTempDic()
    {
        foreach (var build in conect.InfoBuildsDBDic)
        {
            foreach (var res in build.Value.resursNeedDic)
            {
                ResTempDicRemove[res.Key] += res.Value;
            }
            ResTempDicAdd[build.Value.resursProduct] += build.Value.storageResursProduct;
        }
        ResTempDicAdd[Res.power] += 2;
        ResTempDicAdd[Res.piple] += 2;
    }






    public void CostsResourcesForBuilding(Build build)
    {
        //Капітальні витрати ресурсів на будівництво
        conect.RemoveResToResurcsBD(Res.gold, build.cinaBuild);
        ResTempDicRemove[Res.gold] += build.cinaBuild;

        conect.RemoveResToResurcsBD(Res.power, 1);
        ResTempDicRemove[Res.power] += 1;

        conect.RemoveResToResurcsBD(Res.piple, 1);
        ResTempDicRemove[Res.piple] += 1;

        //Поточні витрати ресурсів in Temp
        foreach (var res in build.resursNeedDic)
        {
            ResTempDicRemove[res.Key] += res.Value;
        }
        ResTempDicAdd[build.resursProduct] += build.storageResursProduct;
        
    }

    public void CurrentReceiptsOfResources(Build build)
    {
        //Поточні надходження ресурсів
        conect.AddResToResurcsBD(build.resursProduct, build.storageResursProduct);
        //Поточні витрати ресурсів
        foreach (var res in build.resursNeedDic)
        {
            conect.RemoveResToResurcsBD(res.Key, res.Value);
        }
    }
    //Розробити верифікацію

    public bool ResursCvoteBuilder()
    {
        bool result = true;
        if(conect.InfoResurcesDic[Res.gold] - ResTempDicRemove[Res.gold] <= 0)
        {
            UIManager.S.ActiveMasageErrore("немає грошей");
            Debug.Log("Немає грошей") ;
            result = false;
        }
        else if(ResTempDicAdd[Res.power] - ResTempDicRemove[Res.power] < 0
        && conect.InfoResurcesDic[Res.power] - ResTempDicRemove[Res.power] < 0)
        {
            UIManager.S.ActiveMasageErrore("ви виснажені");
            Debug.Log("Ви виснажені") ;
            result = false;
        }
        else if(ResTempDicAdd[Res.piple] - ResTempDicRemove[Res.piple] < 0
        && conect.InfoResurcesDic[Res.piple] - ResTempDicRemove[Res.piple] < 0)
        {
            UIManager.S.ActiveMasageErrore("нікому робити");
            Debug.Log("Нікому робити") ;
            result = false;
        }

        return result;

    }

}
