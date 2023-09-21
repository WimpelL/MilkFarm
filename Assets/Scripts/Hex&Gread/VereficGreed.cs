using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VereficGreed : MonoBehaviour
{

    [Header("Setting MakeGreadBuilder")]
    public GameObject greadBuilderPrefab;  
    public static GameObject greadBuilder;

    private Vector3 mousePosition;
    private int mapSizeX;
    private int mapSizeY;
    private MaterialPropertyBlock _block;
    private BuildingGread bG;
    private string tempNameBuilder;


    public void Start()
    {
        mapSizeX = MakeGread.MapSizeX;
        mapSizeY = MakeGread.MapSizeY;
        _block = new MaterialPropertyBlock();
    }
    public void BuildingOffice()
    {
        tempNameBuilder = "Office";
        MGB(); 
    }
    public void BuildingMagazine()
    {
        tempNameBuilder = "Magazine";
        MGB();
    }
    public void BuildingHause()
    {
        tempNameBuilder = "Hause";
        MGB();
    }
    public void BuildingPole()
    {
        tempNameBuilder = "Pole";
        MGB();
    }
    public void BuildingSinoval()
    {
        tempNameBuilder = "Sinoval";
        MGB();
    }
    public void BuildingKorovnik()
    {
        tempNameBuilder = "Korovnik";
        MGB();
    }
    public void BuildingDoilka()
    {
        tempNameBuilder = "Doilka";
        MGB();
    }

    public void MGB()
    {
        if(greadBuilder == null)
        { 
            greadBuilder = Instantiate<GameObject>(greadBuilderPrefab);
            bG =  greadBuilder.AddComponent<BuildingGread>();
            mousePosition = Input.mousePosition;
            mousePosition.z = 10.0f; // встановлюємо зміщення по осі Z для перетворення в координати світу
            greadBuilder.transform.position = Camera.main.ScreenToWorldPoint(mousePosition);
            UIManager.S.DeletePanelUI(); // знищює стару панель UI
            
        }
        
    } 
   
    private void Update()
    {
        string goTemp;
        string go = "";

        if(greadBuilder != null)
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
                    greadBuilder.transform.position = RaycastCamera.HexSelected.transform.position;

                    int x = RaycastCamera.HehTileSelected.posGoOnMapX;                
                    int y = RaycastCamera.HehTileSelected.posGoOnMapY;

                    Color clr = CompresEmployGreadAndBuildChild(x,y) ? Color.red : Color.blue;
                    _block.SetColor("_Color", clr);

                    for (int i = 0; i < greadBuilder.transform.childCount; i++)
                    {
                        GameObject hexOfGreadBuilder = greadBuilder.transform.GetChild(i).gameObject;
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
                BuildManager.S.MakeGOBuild(tempNameBuilder);
                HexTile [] buildChild = bG.HexSeven(x,y);
                for (int i = 0; i < buildChild.Length; i++)
                {
                    buildChild[i].statusType = EmployStatusType.busy;
                    _block.SetColor("_Color", Color.red);
                    buildChild[i].GetComponent<Renderer>().SetPropertyBlock(_block);
                    BuildManager.S.OverlayBuildToHexDB(buildChild[i]);

                }
                Destroy(greadBuilder); 
                for (int x1 = 0; x1 <= mapSizeX; x1++)
                {
                    for (int y1 = 0; y1 <= mapSizeY; y1++)
                    {
                        MakeGread.ArrPosGoOnMap[x1,y1].GetComponent<SpriteRenderer>().enabled = false;
                    }
                }
                
            }
        }
        else if(Input.GetMouseButton(1))
        {
            Destroy(greadBuilder); 
            for (int x1 = 0; x1 <= mapSizeX; x1++)
            {
                for (int y1 = 0; y1 <= mapSizeY; y1++)
                {
                    MakeGread.ArrPosGoOnMap[x1,y1].GetComponent<SpriteRenderer>().enabled = false;
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




