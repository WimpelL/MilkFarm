using System.Collections;
using System.Collections.Generic;
using UnityEngine;

class Barn : BuildBuilder
{
    public override void SetBuildToDB()
    {
        throw new System.NotImplementedException();
    }

    public override void SetOptionsBuild()
    {
        Build.resursInstrument = Res.cow;
        Build.storageResursInstrument = 5;
        Build.resursProduct = Res.milk;
        Build.storageResursProduct = 100f;
        Build.resursNeed = Res.hey;
        Build.storageResursNeed = 100f;
        Build.unit = 5;
        Build.spead = 0.1f;
    }
}
