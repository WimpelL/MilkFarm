using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildingGread
{
    HexTile [] buildChild;
    ConectHexDB cHexDB = new ConectHexDB();
    public  HexTile [] HexSeven(int x,int y)
    {
        HexTile [] buildChild;
        if(x % 2 == 0)
        {
            buildChild = new HexTile [] {
                Vec(x,y),
                Vec(x,y+1),
                Vec(x,y-1),
                Vec(x-1,y),
                Vec(x+1,y),
                Vec(x+1,y-1),
                Vec(x-1,y-1)
            };
            //       4.5
            //  3.4 |4.4| 5.4
            //  3.3  4.3  5.3
        } 
        else
        {
            buildChild = new HexTile [] {
                Vec(x,y),
                Vec(x,y+1),
                Vec(x,y-1),
                Vec(x-1,y),
                Vec(x+1,y),
                Vec(x-1,y+1),
                Vec(x+1,y+1)
            };
            //  2.4  3.4  4.4     
            //  2.3 |3.3| 4.3
            //       3.2
        }
        return buildChild;
    } 
    private HexTile Vec (int x, int y)
    {
        Vector2Int vec = new Vector2Int(x,y);
        return cHexDB.InfoHexagenTileDB[vec];
    }
}

