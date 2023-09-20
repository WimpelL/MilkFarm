using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResurcsBD : MonoBehaviour
{
    private static  Dictionary<Res,float> _resurcesDic = new Dictionary<Res, float>()
        {
            [Res.power] = 2,
            [Res.piple] = 2,
            [Res.gold]  = 100,
            [Res.grass] = 0,
            [Res.hey]   = 0,
            [Res.cow]   = 0,
            [Res.milk]  = 0,
        };

    public static Dictionary<Res,float> ResurcesDic
    {
        get{return _resurcesDic;}
        set{_resurcesDic = value;}
    }
}
