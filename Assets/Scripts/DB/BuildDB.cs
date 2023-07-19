using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class BuildDB : MonoBehaviour
{
    private static Dictionary<int,Build> _buildsDB = new Dictionary<int, Build>();
    private static Dictionary<int, GameObject> _goBuildDic = new Dictionary<int, GameObject>();

    public static void SaveBuildDB (Build buildSave, int key)
    {
        _buildsDB.Add(key, buildSave);
        //Debug.Log("BuildsDB.Count" + _buildsDB.Count);
    }
    public static Build LoadBuildDB(int key)
    {
        return _buildsDB[key];
    }
    public static void DeleteBuildInBuildDB(int key)
    {
        _buildsDB.Remove(key);
    }
    public static void SaveGOBuildDB (GameObject buildGOSave, int key)
    {
        _goBuildDic.Add(key, buildGOSave);
        Debug.Log("_goBuildsDB.Count" + _buildsDB.Count);
    }
    public static void DeleteGOBuildInBuildDB(int key)
    {
        Debug.Log("DeleteGOBuildInBuildDB.key " + key);
        GameObject gameObjectToRemove = _goBuildDic[key];
        _goBuildDic.Remove(key);
        Destroy(gameObjectToRemove);
        Debug.Log(" _goBuildDic Count" +  _goBuildDic.Count);

    }
    public static int MakeKeyBuild()
    {
        int key;
        if(_goBuildDic.Count == 0) key = 1;
        else key = _goBuildDic.Keys.Max() + 1;
        return key;
    }
    
}
