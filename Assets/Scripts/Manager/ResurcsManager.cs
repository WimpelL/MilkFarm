using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResurcsManager : MonoBehaviour
{
    public static ResurcsManager S;

    public int pipleBaza = 2;


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
            [Res.power] = pipleBaza,[Res.piple] = pipleBaza,[Res.gold]  = 0,[Res.grass] = 0,
            [Res.hey]   = 0,[Res.cow]   = 0,[Res.milk]  = 0,
        };
    }

    public void toNextWekResursTempDic()
    {
        // обнулення темпового словника
        foreach (var res in ResTempDicRemove)
        {
            ResTempDicAdd[res.Key] = 0;
        }
        foreach (var res in ResTempDicAdd)
        {
            ResTempDicRemove[res.Key] = 0;
        }
        // Занесення в темповий словник витрати минулого тижня     
        ResTempDicAdd[Res.power] += pipleBaza;
        ResTempDicAdd[Res.piple] += pipleBaza;          
        foreach (var build in conect.InfoBuildsDBDic)
        {
            if(build.Value.work)
            {
                foreach (var res in build.Value.resursNeedDic)
                {
                    ResTempDicRemove[res.Key] += res.Value * build.Value.oborud;
                }
                ResTempDicAdd[build.Value.resursProduct] +=
                build.Value.storageResursProduct * build.Value.oborud;
                               
            }

        }

    }

    public void toNextWekResursInDB()
    {
        conect.ResToResurcsBD(Res.power,pipleBaza);
        conect.ResToResurcsBD(Res.piple,pipleBaza);
        foreach (var build in conect.InfoBuildsDBDic)
        {
            if(build.Value.work)
            {
                //Поточні витрати ресурсів
                foreach (var res in build.Value.resursNeedDic)
                {
                    conect.RemoveResToResurcsBD(res.Key, res.Value * build.Value.oborud);
                }
                //Поточні надходження ресурсів
                conect.AddResToResurcsBD(build.Value.resursProduct,
                 build.Value.storageResursProduct * build.Value.oborud);
            }
        }
    }


    public void ResourcesForBuilding(Build build)
    {
        //Капітальні витрати ресурсів на будівництво в БД
        conect.RemoveResToResurcsBD(Res.gold, build.cinaBuild);
        conect.RemoveResToResurcsBD(Res.power, 1);
        conect.RemoveResToResurcsBD(Res.piple, 1);

        //Капітальні витрати ресурсів на будівництво в in Temp
        ResTempDicRemove[Res.gold]  += build.cinaBuild;
        ResTempDicRemove[Res.power] += 1;
        ResTempDicRemove[Res.piple] += 1;

        //Поточні витрати ресурсів in Temp
        foreach (var res in build.resursNeedDic)
        {
            ResTempDicRemove[res.Key] += res.Value;
        }
        if( build.resursProduct != Res.gold &&
            build.resursProduct != Res.power &&
            build.resursProduct != Res.piple )
        ResTempDicAdd[build.resursProduct] += build.storageResursProduct;
        
    }

    public void ResurceForStopBuid()
    {
        ResTempDicRemove[Res.power] -= 1;
        ResTempDicRemove[Res.piple] -= 1;
        ResTempDicRemove[Res.gold]  += 1;
    }
    public void ResurceForPlayBuid()
    {
        ResTempDicRemove[Res.power] += 1;
        ResTempDicRemove[Res.piple] += 1;
        ResTempDicRemove[Res.gold] += 1; 
    }
    public void resurceForAddGear(Build build)
    {
        //Капітальні витрати ресурсів на будівництво в БД
        conect.RemoveResToResurcsBD(Res.gold, build.cinaOborud);
        conect.RemoveResToResurcsBD(Res.power, 1);
        conect.RemoveResToResurcsBD(Res.piple, 1);
        //Капітальні витрати ресурсів на будівництво в in Temp
        ResTempDicRemove[Res.gold] +=  build.cinaOborud; 
        ResTempDicRemove[Res.power] +=  1; 
        ResTempDicRemove[Res.piple] +=  1; 
        //Поточні витрати ресурсів in Temp
        foreach (var res in build.resursNeedDic)
        {
            ResTempDicRemove[res.Key] += res.Value;
        }
        if( build.resursProduct != Res.gold &&
            build.resursProduct != Res.power &&
            build.resursProduct != Res.piple )
        ResTempDicAdd[build.resursProduct] += build.storageResursProduct;
    }


    // верифікація будівництва
    public bool ResursCvoteBuilder()
    {
        bool result = true;
        if(conect.InfoResurcesDic[Res.gold] <= 0)
        {
            UIManager.S.ActiveMasageErrore("немає грошей");
            Debug.Log("Немає грошей") ;
            result = false;
        }
        else if(conect.InfoResurcesDic[Res.power] <= 0)
        {
            UIManager.S.ActiveMasageErrore("ви виснажені");
            Debug.Log("Ви виснажені") ;
            result = false;
        }
        else if(conect.InfoResurcesDic[Res.piple] <= 0)
        {
            UIManager.S.ActiveMasageErrore("нікому робити");
            Debug.Log("Нікому робити") ;
            result = false;
        }
        return result;
    }

    // верифікація ходу
    public bool ResursCvoteInNextWek()
    {
        bool result = true;
        /*if(ResTempDicAdd[Res.gold] <= ResTempDicRemove[Res.gold])
        {
            UIManager.S.ActiveMasageErrore("немає грошей. вимкніть будинки");
            Debug.Log("Немає грошей") ;
            result = false;
        }*/
        if(ResTempDicAdd[Res.power] < ResTempDicRemove[Res.power])
        {
            UIManager.S.ActiveMasageErrore("ви виснажені. вимкніть будинки ");
            Debug.Log("Ви виснажені") ;
            result = false;
        }
        else if(ResTempDicAdd[Res.piple] < ResTempDicRemove[Res.piple])
        {
            UIManager.S.ActiveMasageErrore("нікому робити. вимкніть будинки");
            Debug.Log("Нікому робити") ;
            result = false;
        }
        return result;
    }
}
