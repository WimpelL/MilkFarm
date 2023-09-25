using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Office : BuildBuilder
{


    public override void SetOptionsBuild()
    {
        Build.cinaBuild = 10;

        Build.resursProduct = Res.power;
        Build.storageResursProduct = 10;
        Build.resursNeedDic = new Dictionary<Res, int>
        {
            { Res.gold,  1 }, 
            { Res.piple, 1 },
            { Res.power, 1 }
        };
        Build.name = "Office";
    }
}
