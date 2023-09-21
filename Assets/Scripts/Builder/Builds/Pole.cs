using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pole : BuildBuilder
{


    public override void SetOptionsBuild()
    {
        Build.cinaBuild = 10;
        Build.cinaOborud = 2;
        Build.cinaRes = 1;
        Build.oborud = 1;
        Build.maxOborud = 10;
        Build.resursProduct = Res.grass;
        Build.storageResursProduct = 1;
        Build.resursNeedDic = new Dictionary<Res, int>
        {
            { Res.gold,  1 }, 
            { Res.piple, 1 },
            { Res.power, 1 } 
        };
        Build.name = "Pole";
    }
}
