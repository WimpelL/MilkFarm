using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class UIManager : MonoBehaviour
{
    public static UIManager S;

    public GameObject panelUIPrefab;
    public TextMeshProUGUI milk;
    public Canvas canvas;

    private GameObject panelUI = null;
    private UIPanel panel;
    private ConectBuildDB cBuildDB = new ConectBuildDB();

    public void InicialUIReaction(HexTile hex)
    {
        if(hex.statusType == EmployStatusType.none) 
        {
            Debug.Log("Non Build");
            DeletePanelUI();
        }
        else
        {
            Debug.Log(cBuildDB.buildOfBuildDic(hex.keyBuild).name);
            if(BuildDistroer.disBuilder == null)
            {
                CreatePanelUI();
                LoadInfoPanelUIForBuild(hex);
            }
        }
    }

    public void LoadInfoPanelUIForBuild( HexTile hex)
    {
        panel.panelTextName.text = cBuildDB.buildOfBuildDic(hex.keyBuild).name;
    }

    public void CreatePanelUI()
    {

        if(panelUI == null)
        {
            panelUI = Instantiate<GameObject>(panelUIPrefab, canvas.transform);
            panel = panelUI.GetComponent<UIPanel>();
        }

    }

    public void DeletePanelUI()
    {
        if(panelUI != null)
        Destroy(panelUI);
    }




    void Start()
    {
        S = this;

        milk.text = "Milk: " + ResurcsManager.Milk;
        
    }


    void Update()
    {
        milk.text = "Milk: " + ResurcsManager.Milk;
        
    }
}
