using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ConectBuildDB : MonoBehaviour
{
    public void AddGOToGOBuildDic(int key, GameObject goBuild)
    {
        BuildDB.GOBuildDBDic.Add(key, goBuild);
    }

    public void AddBuildToBuildsDBDic(int key, Build build)
    {
        BuildDB.BuildsDBDic.Add(key,build);
    }
    public Dictionary<int,Build> InfoBuildsDBDic
    {
        get{return BuildDB.BuildsDBDic;}
    }
    public  Dictionary<int, GameObject> InfoGOBuildDBDic
    {
        get{return BuildDB.GOBuildDBDic;}
    }

    public void RemoveBuildToBuildsDBDic(int destroyKey)
    {
        BuildDB.BuildsDBDic.Remove(destroyKey);
    }
    public void RemoveGOToGOBuildDic(int destroyKey)
    {
        BuildDB.GOBuildDBDic.Remove(destroyKey);
    }
    

    
}
