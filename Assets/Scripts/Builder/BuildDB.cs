using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildDB : MonoBehaviour
{
    private static Dictionary<int,Build> BuildsDB = new Dictionary<int, Build>();

    public static void SaveHexagenTileDB (Build buildSave, int key)
    {
        BuildsDB.Add(key, buildSave);
    }
    public static Build LoadHexagenTileDB(int key)
    {
        return BuildsDB[key];
    }
}
