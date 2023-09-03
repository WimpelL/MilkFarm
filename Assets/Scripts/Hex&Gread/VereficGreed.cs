using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VereficGreed : MonoBehaviour
{
    private int mapSizeX;
    private int mapSizeY;
    private MaterialPropertyBlock _block;
    private BuildingGread bG = new BuildingGread();

    public void Start()
    {
        mapSizeX = MakeGread.MapSizeX;
        mapSizeY = MakeGread.MapSizeY;
        _block = new MaterialPropertyBlock();
    }
   
    private void Update()
    {
        string goTemp;
        string go = "";

        if(MakeGreadBuilder.greadBuilder != null)
        {
            for (int x = 0; x <= mapSizeX; x++)
            {
                for (int y = 0; y <= mapSizeY; y++)
                {
                    if(MakeGread.ArrPosGoOnMap[x,y].GetComponent<HexTile>().statusType == EmployStatusType.busy)
                    MakeGread.ArrPosGoOnMap[x,y].GetComponent<SpriteRenderer>().enabled = true;
                }
            }
            if( RaycastCamera.RayInfo )
            {
                goTemp = RaycastCamera.HexSelected.name;
                if(goTemp != go)
                {
                    MakeGreadBuilder.greadBuilder.transform.position = RaycastCamera.HexSelected.transform.position;

                    int x = RaycastCamera.HehTileSelected.posGoOnMapX;                
                    int y = RaycastCamera.HehTileSelected.posGoOnMapY;

                    Color clr = CompresEmployGreadAndBuildChild(x,y) ? Color.red : Color.blue;
                    _block.SetColor("_Color", clr);

                    for (int i = 0; i < MakeGreadBuilder.greadBuilder.transform.childCount; i++)
                    {
                        GameObject hexOfGreadBuilder = MakeGreadBuilder.greadBuilder.transform.GetChild(i).gameObject;
                        hexOfGreadBuilder.GetComponent<Renderer>().SetPropertyBlock(_block);
                    }              
                    
                    ReplaceEmployGreadForBuildChild( x, y);
                    
                    go = goTemp;                
                }

            }
        }
    } 

    private void ReplaceEmployGreadForBuildChild(int x, int y)
    {
        if(Input.GetMouseButton(0))
        {
            if(!CompresEmployGreadAndBuildChild(x,y))
            {
                BuildManager.S.MakeGOBuild();
                HexTile [] buildChild = bG.HexSeven(x,y);
                for (int i = 0; i < buildChild.Length; i++)
                {
                    buildChild[i].statusType = EmployStatusType.busy;
                    _block.SetColor("_Color", Color.red);
                    buildChild[i].GetComponent<Renderer>().SetPropertyBlock(_block);
                    BuildManager.S.OverlayBuildToHexDB(buildChild[i]);

                }
                Destroy(MakeGreadBuilder.greadBuilder); 
                for (int x1 = 0; x1 <= mapSizeX; x1++)
                {
                    for (int y1 = 0; y1 <= mapSizeY; y1++)
                    {
                        MakeGread.ArrPosGoOnMap[x1,y1].GetComponent<SpriteRenderer>().enabled = false;
                    }
                }
                
            }
        }   
    }

    private bool CompresEmployGreadAndBuildChild(int x, int y)
    {
        
        bool result = false;
        result = x + 1 > mapSizeX || y + 1 > mapSizeY || x - 1 < 0 || y - 1 < 0;

        if(x < mapSizeX && y < mapSizeY && x > 0 && y > 0 )
        {     
            HexTile [] buildChild = bG.HexSeven(x,y);
            
            for (int i = 0; i < buildChild.Length; i++)
            {
                if(buildChild[i].statusType == EmployStatusType.busy)
                {
                    result = true;
                    break;
                }
            }
        }
        return result;
    }

}




