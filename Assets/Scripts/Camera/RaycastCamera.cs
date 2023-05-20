using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RaycastCamera : MonoBehaviour
{
    private string goTemp;
    private string go;
    private static bool _rayInfo;
    private static GameObject _hexSelected;
    private static HexTile _hexTileSelected;    
    public static bool RayInfo { get {return _rayInfo;}}
    public static GameObject HexSelected { get {return _hexSelected;}}
    public static HexTile HehTileSelected { get{return _hexTileSelected;}}    

    private void LateUpdate()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit2D hit = Physics2D.Raycast(ray.origin,ray.direction,15,
                                            LayerMask.GetMask("GreadMap"));
        _rayInfo = hit;


        if (hit.collider != null 
            && hit.collider.gameObject.GetComponent<SpriteRenderer>() != null)
        {

            goTemp = hit.collider.gameObject.name;
            if(goTemp != go)
            {
                _hexSelected = hit.collider.gameObject;                
                _hexTileSelected = _hexSelected.GetComponent<HexTile>();
                Debug.Log("Name GO " + hit.collider.gameObject.name + " KeyB = " + _hexTileSelected.keyBuild);
                go = goTemp;                
            }

        }

    }

    
}
    // Raycast for 3D phisics
    // private void LateUpdate()
    // {
    //    Ray rey = Camera.main.ScreenPointToRay(Input.mousePosition);
    //
    //    RaycastHit hit;    
    //    if(Physics.Raycast(rey, out hit))
    //    {
    //        Debug.Log("Name GO " + hit.collider.gameObject.name);
    //    }
    // }

    /* Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
    RaycastHit2D hit = Physics2D.Raycast(
        ray.origin,
        ray.direction,
        Mathf.Infinity, 
        //райкаст лише на об'єктах з дефолтним шаром.
        //Якщо, інший шар, вкажіть його в методі GetMask.
        LayerMask.GetMask("Default"),
        Mathf.NegativeInfinity,
        (float)QueryTriggerInteraction.Collide);*/

