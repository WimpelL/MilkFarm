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


    public void Start()
    {
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

                    Replace();
                    go = goTemp;                
                }

            }
        }
    } 

    private void Replace()
    {
        if(Input.GetMouseButton(0))
        {
            Debug.Log("Knopca [0] nazhata");
            if(RaycastCamera.HehTileSelected.statusType != EmployStatusType.none)
            {
                Debug.Log("Knopca [0] nazhata. Logika 2");
                // змінення хексів 
                for (int i = 0; i < HexDB.SorchDBForKeyBuild(RaycastCamera.HehTileSelected.keyBuild).Length; i++)
                {
                    HexDB.SorchDBForKeyBuild(RaycastCamera.HehTileSelected.keyBuild)[i].statusType = EmployStatusType.none;
                    HexDB.SorchDBForKeyBuild(RaycastCamera.HehTileSelected.keyBuild)[i].keyBuild = 0;
                    _block.SetColor("_Color", Color.blue);
                    HexDB.SorchDBForKeyBuild(RaycastCamera.HehTileSelected.keyBuild)[i].GetComponent<Renderer>().SetPropertyBlock(_block);
                }
                            
                // удалить ГО буілд
                BuildManager.S.goBuildDic.Remove(RaycastCamera.HehTileSelected.keyBuild);

                // удалить буілд з БД
                BuildDB.DeleteBuildInBuildDB(RaycastCamera.HehTileSelected.keyBuild);
                // знищення дистроїра
                Destroy(disBuilder); 


            }
        }

    }
}
