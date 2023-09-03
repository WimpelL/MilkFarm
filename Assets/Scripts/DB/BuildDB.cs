using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildDB : MonoBehaviour
{
    private static Dictionary<int,Build> _buildsDBDic = new Dictionary<int, Build>();
    private static Dictionary<int, GameObject> _goBuildDic = new Dictionary<int, GameObject>();

    public static Dictionary<int,Build> BuildsDBDic
    {
        get{return _buildsDBDic;}
        set{_buildsDBDic = value;}
    }
    public static Dictionary<int, GameObject> GOBuildDBDic
    {
        get{return _goBuildDic;}
        set{_goBuildDic = value;}
    }
    
}
