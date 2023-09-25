using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Magazin : BuildBuilder
{


    public override void SetOptionsBuild()
    {
        Build.cinaBuild = 10;

        Build.resursProduct = Res.gold;
        Build.storageResursProduct = 1;
        Build.resursNeedDic = new Dictionary<Res, int>
        {
            { Res.piple,  1 }  ,
            { Res.power,  1 }  ,
            { Res.gold,   1 }  
        };
        Build.name = "Magazin";
    }
}
