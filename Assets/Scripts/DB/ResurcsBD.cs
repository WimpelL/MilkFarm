using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResurcsBD : MonoBehaviour
{
    private static  Dictionary<Res,int> _resurcesDic = new Dictionary<Res, int>()
        {
            [Res.power] = 2,
            [Res.piple] = 4,
            [Res.gold]  = 100,
            [Res.grass] = 0,
            [Res.hey]   = 0,
            [Res.cow]   = 0,
            [Res.milk]  = 0,
        };

    public static Dictionary<Res,int> ResurcesDic
    {
        get{return _resurcesDic;}
        set{_resurcesDic = value;}
    }
}
