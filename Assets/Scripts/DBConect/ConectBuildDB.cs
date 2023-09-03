using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class ConectBuildDB : MonoBehaviour
{
    public void SaveGOBuildDic(int key, GameObject goBuild)
    {
        BuildDB.GOBuildDBDic.Add(key, goBuild);
    }

    public void SaveBuildsDBDic(int key, Build build)
    {
        BuildDB.BuildsDBDic.Add(key,build);
    }
    public int MakeKeyBuild()
    {
        int key;
        if(BuildDB.BuildsDBDic.Count == 0) key = 1;
        else key = BuildDB.BuildsDBDic.Keys.Max() + 1;
        return key;
    }
    public void DestroyBuildsDBDic(int destroyKey)
    {
        BuildDB.BuildsDBDic.Remove(destroyKey);
    }
    public void DestroyGOBuildDic(int destroyKey)
    {
        BuildDB.GOBuildDBDic.Remove(destroyKey);
    }


    public GameObject goOfGOBuildDic(int key)
    {
        return BuildDB.GOBuildDBDic[key];
    }
    public Build buildOfBuildDic(int key)
    {
        return BuildDB.BuildsDBDic[key];
    }

    

    
}
