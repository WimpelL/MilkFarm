using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Reaction : MonoBehaviour
{
    
    private void OnMouseDown()
    {
        HexTile hex = gameObject.GetComponent<HexTile>();

        if(hex.statusType == EmployStatusType.none) 
        {
            Debug.Log("Non Build");
            UIManager.S.DeletePanelUI();
        }
        else
        {
            Debug.Log(BuildDB.LoadBuildDB(hex.keyBuild).name);
            UIManager.S.CreatePanelUI();
            UIManager.S.LoadInfoPanelUIForBuild(hex);
        }
    }
}
