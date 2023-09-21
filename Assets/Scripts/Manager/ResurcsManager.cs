using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResurcsManager : MonoBehaviour
{
    public static ResurcsManager S;

    //private ConectResurcsDB cResDB;
    //private ConectBuildDB cBuildDB;
    private Conector conect;

    private void Start()
    {
        S = this;
        GameObject connectorObject = GameObject.Find("Conector");
        conect = connectorObject.AddComponent<Conector>(); 
        //cBuildDB = new ConectBuildDB();
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
        if( conect.InfoResurcesDic[Res.gold]  < 0 ||
            conect.InfoResurcesDic[Res.power] < 0 ||
            conect.InfoResurcesDic[Res.piple] < 0    )
            Debug.Log("Будинок не збудувати");
    }

    public void UtilizationOfResourcesForCurrentNeeds(Build build)
    {
        //Використання ресурсу на поточні потреби
        foreach (var res in build.resursNeedDic)
        {
            conect.RemoveResToResurcsBD(res.Key, res.Value);
        }
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
