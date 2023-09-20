using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class UIManager : MonoBehaviour
{
    public static UIManager S;

    public GameObject panelUIPrefab;
    public TextMeshProUGUI textPower;
    public TextMeshProUGUI textPiple;
    public TextMeshProUGUI textGold;
    public TextMeshProUGUI textGrass;
    public TextMeshProUGUI textHey;
    public TextMeshProUGUI textCow;
    public TextMeshProUGUI textMilk;
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
            Debug.Log(cBuildDB.InfoBuildsDBDic[hex.keyBuild].name);
            if(BuildDistroer.disBuilder == null)
            {
                CreatePanelUI();
                LoadInfoPanelUIForBuild(hex);
            }
        }
    }

    public void LoadInfoPanelUIForBuild( HexTile hex)
    {
        panel.panelTextName.text = cBuildDB.InfoBuildsDBDic[hex.keyBuild].name;
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
        textPower.text = "енергії: " + ResurcsBD.ResurcesDic[Res.power];
        textPiple.text = "робітників: " + ResurcsBD.ResurcesDic[Res.piple];
        textGold.text = "грошей: " + ResurcsBD.ResurcesDic[Res.gold];
        textGrass.text = "трави: " + ResurcsBD.ResurcesDic[Res.grass];
        textHey.text = "сіна: " + ResurcsBD.ResurcesDic[Res.hey];
        textCow.text = "корів: " + ResurcsBD.ResurcesDic[Res.cow];
        textMilk.text = "молока: " + ResurcsBD.ResurcesDic[Res.milk];
    }


    void Update()
    {
        textPower.text = "енергії: " + ResurcsBD.ResurcesDic[Res.power];
        textPiple.text = "робітників: " + ResurcsBD.ResurcesDic[Res.piple];
        textGold.text = "грошей: " + ResurcsBD.ResurcesDic[Res.gold];
        textGrass.text = "трави: " + ResurcsBD.ResurcesDic[Res.grass];
        textHey.text = "сіна: " + ResurcsBD.ResurcesDic[Res.hey];
        textCow.text = "корів: " + ResurcsBD.ResurcesDic[Res.cow];
        textMilk.text = "молока: " + ResurcsBD.ResurcesDic[Res.milk];
        
    }
}
