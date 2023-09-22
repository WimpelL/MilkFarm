using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResurcsManager : MonoBehaviour
{
    public static ResurcsManager S;

    private Conector conect;

    private void Start()
    {
        S = this;
        GameObject connectorObject = GameObject.Find("Conector");
        conect = connectorObject.AddComponent<Conector>(); 
    }
    
    public void AddResWhileBuildingToResurcsBD(Build build)
    {
        conect.AddResToResurcsBD(build.resursProduct, build.storageResursProduct);
    }

    public void RemoveWhileBuildingResToResurcsBD(Build build)
    {
        conect.RemoveResToResurcsBD(Res.gold, build.cinaBuild);
        conect.RemoveResToResurcsBD(Res.power, 1);
        conect.RemoveResToResurcsBD(Res.piple, 1);
    }

    public void UtilizationOfResourcesForCurrentNeeds(Build build)
    {
        //Використання ресурсу на поточні потреби
        foreach (var res in build.resursNeedDic)
        {
            conect.RemoveResToResurcsBD(res.Key, res.Value);
        }
    }

    public bool ResursCvoteBuilder()
    {
        bool result = true;
        if(conect.InfoResurcesDic[Res.gold] - 10 <= 0)
        {
            UIManager.S.ActiveMasageErrore("немає грошей");
            Debug.Log("Немає грошей") ;
            result = false;
        }
        else if(conect.InfoResurcesDic[Res.power] - 1 <= 0)
        {
            UIManager.S.ActiveMasageErrore("ви виснажені");
            Debug.Log("Ви виснажені") ;
            result = false;
        }
        else if(conect.InfoResurcesDic[Res.piple] - 1 <= 0)
        {
            UIManager.S.ActiveMasageErrore("нікому робити");
            Debug.Log("Нікому робити") ;
            result = false;
        }

        return result;

    }

    /*public void UtilizationOfResourcesForCurrentNeeds()
    {
        //Використання ресурсу на поточні потреби
        foreach (var build in cBuildDB.InfoBuildsDBDic)
        {
            foreach (var res in build.Value.resursNeedDic)
            {
                cResDB.RemoveResToResurcsBD(res.Key, res.Value);
            }
        }
    }*/

}
