using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResurcsBD : MonoBehaviour
{
    private static  Dictionary<Res,float> _resurcesDic = new Dictionary<Res, float>()
        {
            [Res.hey] =    0,
            [Res.cow] =    0,
            [Res.gold] =   0, 
            [Res.milk] =   0,
            [Res.piple] =  0
        };

    public static Dictionary<Res,float> ResurcesDic
    {
        get{return _resurcesDic;}
        set{_resurcesDic = value;}
    }
}
