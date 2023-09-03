using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class HexDB : MonoBehaviour
{

    private static Dictionary<Vector2Int,HexTile> _hexagenTileDB = new Dictionary<Vector2Int, HexTile>();

    public static Dictionary<Vector2Int,HexTile> HexagenTileDB
    {
        get{return _hexagenTileDB;}
        set{_hexagenTileDB = value;}
    }

}
