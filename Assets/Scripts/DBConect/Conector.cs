using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Conector : MonoBehaviour
{
    // Conect to Data Base "BuildDB"
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
    // Conect to Data Base "HexDB"
    public void AddHexToTileDB (HexTile hexSave, int x, int y)
    {
        Vector2Int vec = new Vector2Int(x,y);
        HexDB.HexagenTileDB.Add(vec, hexSave);
    }
    public Dictionary<Vector2Int,HexTile> InfoHexagenTileDB
    {
        get{return HexDB.HexagenTileDB;}
    }
    //  Conect to Data Base "ResurcsBD"
    public void AddResToResurcsBD(Res res, int quantity)
    {
        ResurcsBD.ResurcesDic[res] += quantity;
    }
    public void RemoveResToResurcsBD(Res res, int quantity)
    {
        ResurcsBD.ResurcesDic[res] -= quantity;
    }
    public Dictionary<Res,float> InfoResurcesDic
    {
        get{return  ResurcsBD.ResurcesDic;}
    }
}
