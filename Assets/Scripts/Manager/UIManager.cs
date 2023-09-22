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
    public TextMeshProUGUI masageError;

    public Canvas canvas;


    private GameObject panelUI = null;
    private UIPanel panel;
    private Conector conect;
    private float displayTime = 5f; // Час відображення повідомлення (у секундах)
    private float fadeDuration = 1f; // Тривалість зникнення (у секундах)
    private float elapsedTime = 0f; 
    private bool isFading = false;

    public void InicialUIReaction(HexTile hex)
    {
        if(hex.statusType == EmployStatusType.none) 
        {
            Debug.Log("Non Build");
            DeletePanelUI();
        }
        else
        {
            Debug.Log(conect.InfoBuildsDBDic[hex.keyBuild].name);
            if(BuildDistroer.disBuilder == null)
            {
                CreatePanelUI();
                LoadInfoPanelUIForBuild(hex);
            }
        }
    }

    public void LoadInfoPanelUIForBuild( HexTile hex)
    {
        panel.panelTextName.text = conect.InfoBuildsDBDic[hex.keyBuild].name;
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

        GameObject connectorObject = GameObject.Find("Conector");
        conect = connectorObject.AddComponent<Conector>();
        
        textPower.text = "енергії: " + ResurcsBD.ResurcesDic[Res.power];
        textPiple.text = "робітників: " + ResurcsBD.ResurcesDic[Res.piple];
        textGold.text = "грошей: " + ResurcsBD.ResurcesDic[Res.gold];
        textGrass.text = "трави: " + ResurcsBD.ResurcesDic[Res.grass];
        textHey.text = "сіна: " + ResurcsBD.ResurcesDic[Res.hey];
        textCow.text = "корів: " + ResurcsBD.ResurcesDic[Res.cow];
        textMilk.text = "молока: " + ResurcsBD.ResurcesDic[Res.milk];
        masageError.gameObject.SetActive(false);
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
        MethodMasageErrore();
        
    }

    public void ActiveMasageErrore(string mesage)
    {
        masageError.gameObject.SetActive(true);
        masageError.alpha = 1f;
        masageError.text = mesage;
        displayTime = 5f; 
        fadeDuration = 1f; 
        elapsedTime = 0f; 
        isFading = false;
    }   

    private void MethodMasageErrore()
    {
        if(masageError.gameObject.activeSelf)
        {
            if (!isFading)
            {
                // Зачекайте displayTime секунд перед початком зникнення
                if (elapsedTime < displayTime)
                {
                    elapsedTime += Time.deltaTime;
                }
                else
                {
                    isFading = true;
                }
            }
            else
            {
                // Зменшуйте прозорість тексту протягом fadeDuration секунд
                if (masageError.alpha > 0)
                {
                    float alphaChange = Time.deltaTime / fadeDuration;
                    masageError.alpha -= alphaChange;
                }
                else
                {
                    // По завершенні зникнення відключіть текст і видаліть гейм об'єкт
                    masageError.gameObject.SetActive(false);
                }
            }
        }



        

        
        

        

        
        

    


    }
}
