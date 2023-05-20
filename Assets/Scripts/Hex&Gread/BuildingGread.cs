using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildingGread
{
    HexTile [] buildChild;
    public static HexTile [] HexSeven(int x,int y)
    {
        HexTile [] buildChild;
        if(x % 2 == 0)
        {
            buildChild = new HexTile [] {
                HexDB.LoadHexagenTileDB(x,y),
                HexDB.LoadHexagenTileDB(x,y+1),
                HexDB.LoadHexagenTileDB(x,y-1),
                HexDB.LoadHexagenTileDB(x-1,y),
                HexDB.LoadHexagenTileDB(x+1,y),
                HexDB.LoadHexagenTileDB(x+1,y-1),
                HexDB.LoadHexagenTileDB(x-1,y-1)
            };

            //arrPosHexOnMap[x,y],
            //arrPosHexOnMap[],
            //arrPosHexOnMap[],               //       4.5
            //arrPosHexOnMap[],               //  3.4 |4.4| 5.4
            //arrPosHexOnMap[],               //  3.3  4.3  5.3
            //arrPosHexOnMap[],
            //arrPosHexOnMap[]
        } 
        else
        {
            buildChild = new HexTile [] {
                HexDB.LoadHexagenTileDB(x,y),
                HexDB.LoadHexagenTileDB(x,y+1),
                HexDB.LoadHexagenTileDB(x,y-1),
                HexDB.LoadHexagenTileDB(x-1,y),
                HexDB.LoadHexagenTileDB(x+1,y),
                HexDB.LoadHexagenTileDB(x-1,y+1),
                HexDB.LoadHexagenTileDB(x+1,y+1)
            };

            /*arrPosHexOnMap[x,y],
            arrPosHexOnMap[x,y+1],
            arrPosHexOnMap[x,y-1],               //  2.4  3.4  4.4     
            arrPosHexOnMap[x-1,y],               //  2.3 |3.3| 4.3
            arrPosHexOnMap[x+1,y],               //       3.2
            arrPosHexOnMap[x-1,y+1], 
            arrPosHexOnMap[x+1,y+1]*/  

        }
        return buildChild;
    } 
}

