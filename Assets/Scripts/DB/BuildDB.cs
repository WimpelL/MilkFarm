using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildDB : MonoBehaviour
{
    private static Dictionary<int,Build> _buildsDB = new Dictionary<int, Build>();

    public static void SaveBuildDB (Build buildSave, int key)
    {
       _buildsDB.Add(key, buildSave);
        Debug.Log("BuildsDB.Count" + _buildsDB.Count);
    }
    public static Build LoadBuildDB(int key)
    {
        return _buildsDB[key];
    }
    public static void DeleteBuildInBuildDB(int key)
    {
        _buildsDB.Remove(key);
    }
    
}
