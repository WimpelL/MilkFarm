using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildDistroer : MonoBehaviour
{
    [Header("Setting DistroerBuilder")]
    public GameObject distroerBuildPrefab;  
    public static GameObject disBuilder;

    private Vector3 mousePosition, worldPosition;
    private string goTemp;
    private string go = "";
    private MaterialPropertyBlock _block;
    private int mapSizeX;
    private int mapSizeY;

    public void Start()
    {
        mapSizeX = MakeGread.MapSizeX;
        mapSizeY = MakeGread.MapSizeY;
        _block = new MaterialPropertyBlock();
    }


    public void Distroer()
    {

        if(disBuilder == null)
        {
            //if 'Builder' battum
            disBuilder = Instantiate<GameObject>( distroerBuildPrefab);
            mousePosition = Input.mousePosition;
            mousePosition.z = 10.0f; // встановлюємо зміщення по осі Z для перетворення в координати світу
            disBuilder.transform.position = Camera.main.ScreenToWorldPoint(mousePosition);
        }
        
    } 

    private void Update()
    {
        if(disBuilder != null)
        {
            if( RaycastCamera.RayInfo )
            {
                goTemp = RaycastCamera.HexSelected.name;
                if(goTemp != go)
                {
                    disBuilder.transform.position = RaycastCamera.HexSelected.transform.position;

                    Color clr = RaycastCamera.HehTileSelected.statusType == EmployStatusType.none
                    ? Color.blue : Color.red;
                    _block.SetColor("_Color", clr);
                    disBuilder.GetComponent<Renderer>().SetPropertyBlock(_block);           

                    //int x = RaycastCamera.HehTileSelected.posGoOnMapX;                
                    //int y = RaycastCamera.HehTileSelected.posGoOnMapY;

                    //Color clr = CompresEmployGreadAndBuildChild(x,y) ? Color.red : Color.blue;
                    //ReplaceEmployGreadForBuildChild( x, y);
                    if(Input.GetMouseButton(0))
                    {
                        if(RaycastCamera.HehTileSelected.statusType != EmployStatusType.none)
                        {
                            BuildManager.S.MakeGOBuild(); //??? удалить ГО
                            HexTile [] buildChild = SorchHexDestroy(RaycastCamera.HehTileSelected);
                            for (int i = 0; i < buildChild.Length; i++)
                            {
                                buildChild[i].statusType = EmployStatusType.busy;
                                _block.SetColor("_Color", Color.red);
                                buildChild[i].GetComponent<Renderer>().SetPropertyBlock(_block);
                                BuildManager.S.OverlayBuildToHexDB(buildChild[i]);

                            }
                            Destroy(disBuilder); 
                            for (int x1 = 0; x1 <= mapSizeX; x1++)
                            {
                                for (int y1 = 0; y1 <= mapSizeY; y1++)
                                {
                                    MakeGread.ArrPosGoOnMap[x1,y1].GetComponent<SpriteRenderer>().enabled = false;
                                }
                            }

                        }
                    }
                    go = goTemp;                
                }

            }
        }


    } 
    /*private  HexTile [] SorchHexDestroy(HexTile hex)
    {
        int keyBuild = hex.keyBuild;


        return hexTiles;
    }*/
    /*private void ReplaceEmployGreadForBuildChild(int x, int y)
    {
        if(Input.GetMouseButton(0))
        {
            if(RaycastCamera.HehTileSelected.statusType != EmployStatusType.none)
            {
                BuildManager.S.MakeGOBuild();
                HexTile [] buildChild = BuildingGread.HexSeven(x,y);
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

        if(x < mapSizeX && y < mapSizeY && x > 0 && y > 0 )
        {     
            HexTile [] buildChild = BuildingGread.HexSeven(x,y);
            
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
    }*/
}
