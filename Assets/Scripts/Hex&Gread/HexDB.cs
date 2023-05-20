using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HexDB : MonoBehaviour
{

    private static Dictionary<Vector2Int,HexTile> HexagenTileDB = new Dictionary<Vector2Int, HexTile>();

    public static void SaveHexagenTileDB (HexTile hexSave, int x, int y)
    {
        Vector2Int vec = new Vector2Int(x,y);
        HexagenTileDB.Add(vec, hexSave);
    }
    public static HexTile LoadHexagenTileDB(int x, int y)
    {
        Vector2Int vec = new Vector2Int(x,y);
        return HexagenTileDB[vec];
    }

}
