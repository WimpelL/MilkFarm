using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResurcsManager : MonoBehaviour
{
    public static ResurcsManager S;

    private ConectResurcsDB cResDB;

    private void Start()
    {
        S = this;
        cResDB = new ConectResurcsDB();
    }
    
    public void AddResWhileBuildingToResurcsBD(Build build)
    {
        cResDB.AddResToResurcsBD(build.resursProduct, build.storageResursProduct);
    }

    public void RemoveWhileBuildingResToResurcsBD(Build build)
    {
        cResDB.RemoveResToResurcsBD(Res.gold, build.cinaBuild);
        cResDB.RemoveResToResurcsBD(Res.power, 1);
        cResDB.RemoveResToResurcsBD(Res.piple, 1);
        if( cResDB.InfoResurcesDic[Res.gold]  < 0 ||
            cResDB.InfoResurcesDic[Res.power] < 0 ||
            cResDB.InfoResurcesDic[Res.piple] < 0    )
            Debug.Log("Будинок не збудувати");

    }

}
