using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ConectHexDB : MonoBehaviour
{
    public void AddHexToTileDB (HexTile hexSave, int x, int y)
    {
        Vector2Int vec = new Vector2Int(x,y);
        HexDB.HexagenTileDB.Add(vec, hexSave);
    }
    public Dictionary<Vector2Int,HexTile> InfoHexagenTileDB
    {
        get{return HexDB.HexagenTileDB;}
    }



}
