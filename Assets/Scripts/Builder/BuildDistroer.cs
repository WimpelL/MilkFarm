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

                    go = goTemp;                
                }
                Replace();
            }
        }
    } 

    private void Replace()
    {
        if(Input.GetMouseButton(0))
        {
            if(RaycastCamera.HehTileSelected.statusType != EmployStatusType.none)
            {
                HexTile [] buildHex = HexDB.SorchDBForKeyBuild(RaycastCamera.HehTileSelected.keyBuild);
                Debug.Log(buildHex.Length);
                // удалить буілд з БД i ГО буілд
                DeleteBuild(RaycastCamera.HehTileSelected.keyBuild);                
                // змінення хексів 
                for (int i = 0; i < buildHex.Length; i++)
                {
                    buildHex[i].statusType = EmployStatusType.none;
                    buildHex[i].keyBuild = 0;
                    _block.SetColor("_Color", Color.blue);
                    buildHex[i].GetComponent<Renderer>().SetPropertyBlock(_block);
                }        
                // знищення дистроїра
                Destroy(disBuilder); 
            }
        }
    }
    private void DeleteBuild(int destroyKey)
    {
        BuildDB.BuildsDBDic.Remove(destroyKey);
        Debug.Log("DeleteGOBuildInBuildDB.key " + destroyKey);
        GameObject gameObjectToRemove = BuildDB.GOBuildDic[destroyKey];
        BuildDB.GOBuildDic.Remove(destroyKey);
        Destroy(gameObjectToRemove);
        Debug.Log(" _goBuildDic Count" + BuildDB.GOBuildDic.Count);

    }
}
