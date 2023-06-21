using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildDB : MonoBehaviour
{
    private static Dictionary<int,Build> BuildsDB = new Dictionary<int, Build>();

    public static void SaveBuildDB (Build buildSave, int key)
    {
        BuildsDB.Add(key, buildSave);
        Debug.Log("BuildsDB.Count" + BuildsDB.Count);
    }
    public static Build LoadBuildDB(int key)
    {
        return BuildsDB[key];
    }
    
}
