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

    public void LoadInfoPanelUIForBuild( HexTile hex)
    {
        panel.panelTextName.text = BuildDB.LoadBuildDB(hex.keyBuild).name;
    }

    public void CreatePanelUI()
    {
        if(panelUI == null)
        panelUI = Instantiate<GameObject>(panelUIPrefab, canvas.transform);
        panel = panelUI.GetComponent<UIPanel>();
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
