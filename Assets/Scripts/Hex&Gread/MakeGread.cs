using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MakeGread : MonoBehaviour
{
    
    [Header("Setting CreateMap")]

    public GameObject hexPrefab;
    public Transform greedMap;
    public int mapSizeX = 10;
    public int mapSizeY = 10;

    private static int _mapSizeX;
    public static int MapSizeX
    {
        get{return _mapSizeX;}
    }
    
    private static int _mapSizeY;
    public static int MapSizeY
    {
        get{return _mapSizeY;}
    }
    public static GameObject[,] ArrPosGoOnMap
    {
        get{return _arrPosGoOnMap;}
        set{_arrPosGoOnMap = value;}
    }
    private static GameObject[,] _arrPosGoOnMap;

    private Vector2 pos;
    private float stepX = -0.25f;
    private float stepY = 0;
    private MaterialPropertyBlock _block;

    private void Awake()
    {
        _mapSizeX = mapSizeX;
        _mapSizeY = mapSizeY;


        _block = new MaterialPropertyBlock();
        _arrPosGoOnMap = new GameObject[mapSizeX+1,mapSizeY+1];
        _block.SetColor("_Color", Color.red);
        for (int x = 0; x <= mapSizeX; x++)
        {
            stepY = x % 2 == 0 ? 0 : 0.5f;
            for (int y = 0; y <= mapSizeY; y++)
            {
                
                GameObject hex = Instantiate<GameObject>(hexPrefab);
                hex.transform.SetParent(greedMap);
                pos = new Vector2(x - stepX/5, y + stepY);
                hex.transform.position = pos;
                hex.name = "x " + x + " y " + y;
                _arrPosGoOnMap[x,y]= hex;
                SaveHexOptionToDB( hex, x, y, pos);
                
            }
            stepX++;
        }
        Debug.Log("_arrPosGoOnMap " + _arrPosGoOnMap.Length);
    }

    private void SaveHexOptionToDB(GameObject hex, int x, int y,Vector2 pos)
    {
        HexTile ht = hex.GetComponent<HexTile>();
        ht.posOnMap = pos;
        ht.posGoOnMapX = x;
        ht.posGoOnMapY = y;
        HexDB.SaveHexagenTileDB(ht,x,y); 
    }
}
