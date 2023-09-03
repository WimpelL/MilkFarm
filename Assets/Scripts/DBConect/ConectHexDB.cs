using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class ConectHexDB : MonoBehaviour
{
    public void SaveHexagenTileDB (HexTile hexSave, int x, int y)
    {
        Vector2Int vec = new Vector2Int(x,y);
        HexDB.HexagenTileDB.Add(vec, hexSave);
    }
    public HexTile LoadHexagenTileDB(int x, int y)
    {
        Vector2Int vec = new Vector2Int(x,y);
        
        return HexDB.HexagenTileDB[vec];
    }
    public HexTile [] SorchDBForKeyBuild(int key)
    {
        var result = HexDB.HexagenTileDB.Values.Where( hex => hex.keyBuild == key).ToArray();
        return result;
    }

}
