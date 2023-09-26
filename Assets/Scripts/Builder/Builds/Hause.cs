using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hause : BuildBuilder
{
    public override void SetOptionsBuild()
    {
        Build.cinaBuild = 10;

        Build.resursProduct = Res.piple;
        Build.storageResursProduct = 10;
        Build.resursNeedDic = new Dictionary<Res, int>
        {
            { Res.gold,   1 }, 
            { Res.power,  1 },
            { Res.piple,  1 },
            { Res.milk,  10 }  
        };
        Build.name = "Dim";
    }
}
