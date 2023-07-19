using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class HexDB : MonoBehaviour
{

    private static Dictionary<Vector2Int,HexTile> _hexagenTileDB = new Dictionary<Vector2Int, HexTile>();

    public static void SaveHexagenTileDB (HexTile hexSave, int x, int y)
    {
        Vector2Int vec = new Vector2Int(x,y);
        _hexagenTileDB.Add(vec, hexSave);
    }
    public static HexTile LoadHexagenTileDB(int x, int y)
    {
        Vector2Int vec = new Vector2Int(x,y);
        return _hexagenTileDB[vec];
    }
    public static HexTile [] SorchDBForKeyBuild(int key)
    {
        var result = _hexagenTileDB.Values.Where( hex => hex.keyBuild == key).ToArray();
        return result;
    }

}