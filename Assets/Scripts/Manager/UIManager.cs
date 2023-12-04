using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class UIManager : MonoBehaviour
{
    public static UIManager S;


    public GameObject panelUIPrefab;
    public TextMeshProUGUI masageError;
    public Canvas canvas;

    [Header("Text for resurce")]   
    public TextMeshProUGUI textPower;
    public TextMeshProUGUI textPiple;
    public TextMeshProUGUI textGold;
    public TextMeshProUGUI textGrass;
    public TextMeshProUGUI textHey;
    public TextMeshProUGUI textCow;
    public TextMeshProUGUI textMilk;

    [Header("Text for Cost resurce")]   
    public TextMeshProUGUI textCostPower;
    public TextMeshProUGUI textCostPiple;
    public TextMeshProUGUI textCostGold;
    public TextMeshProUGUI textCostGrass;
    public TextMeshProUGUI textCostHey;
    public TextMeshProUGUI textCostCow;
    public TextMeshProUGUI textCostMilk;

    [Header("Text for Info Menu")]   
    public TextMeshProUGUI textFermStepOfGame;
    public TextMeshProUGUI textManeyForStep;
    public TextMeshProUGUI textManeyForLastStep;
    public TextMeshProUGUI textCredit;
    public TextMeshProUGUI textTax;
    public TextMeshProUGUI textBuildExpenses;
    public TextMeshProUGUI textResult;



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
            
            DeletePanelUI();
        }
        else
        {
            
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
            panelUI = Instantiate(panelUIPrefab, canvas.transform);
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
        
        UpgradeTextRes();
        //UpgradeTextInfoMenu();

        masageError.gameObject.SetActive(false);

    }
    void UpgradeTextRes()
    {
        textPower.text = "енергії: " + conect.InfoResurcesDic[Res.power];
        textPiple.text = "робітників: " + conect.InfoResurcesDic[Res.piple];
        textGold.text = "грошей: " + conect.InfoResurcesDic[Res.gold];
        textGrass.text = "трави: " + conect.InfoResurcesDic[Res.grass];
        textHey.text = "сіна: " + conect.InfoResurcesDic[Res.hey];
        textCow.text = "корів: " + conect.InfoResurcesDic[Res.cow];
        textMilk.text = "молока: " + conect.InfoResurcesDic[Res.milk];
    }
    void UpgradeTextTempRes()
    {
        textCostPower.text = ResurcsManager.S.ResTempDicAdd[Res.power]
            + "( -" + ResurcsManager.S.ResTempDicRemove[Res.power] + " )";
        textCostPiple.text = ResurcsManager.S.ResTempDicAdd[Res.piple]
            + "( -" + ResurcsManager.S.ResTempDicRemove[Res.piple] + " )";
        textCostGold.text = ResurcsManager.S.ResTempDicAdd[Res.gold] 
            + "( -" + ResurcsManager.S.ResTempDicRemove[Res.gold] + " )";
        textCostGrass.text = ResurcsManager.S.ResTempDicAdd[Res.grass]
            + "( -" + ResurcsManager.S.ResTempDicRemove[Res.grass] + " )";
        textCostHey.text = ResurcsManager.S.ResTempDicAdd[Res.hey]
            + "( -" + ResurcsManager.S.ResTempDicRemove[Res.hey] + " )";
        textCostCow.text = ResurcsManager.S.ResTempDicAdd[Res.cow]
            + "( -" + ResurcsManager.S.ResTempDicRemove[Res.cow] + " )";
        textCostMilk.text = ResurcsManager.S.ResTempDicAdd[Res.milk]
            + "( -" + ResurcsManager.S.ResTempDicRemove[Res.milk] + " )";

    }
    public void UpgradeTextInfoMenu()
    {
        textFermStepOfGame.text = "Ферма хід " + GameManager.S.WeakNumber + " з 10";
        textManeyForStep.text = "Зароблено "
        + (ResurcsManager.S.ResTempDicAdd[Res.gold] - ResurcsManager.S.ResTempDicRemove[Res.gold])
        + " за хід";
        textManeyForLastStep.text = "за минулий період 100";
        textCredit.text = "кредит 100";
        textTax.text = "податок 100";
        textBuildExpenses.text = "витрати на будівництво 100";
        textResult.text = "ітог 100";

    }

    void Update()
    {

        MethodMasageErrore();

        UpgradeTextTempRes();
        UpgradeTextInfoMenu();
        UpgradeTextRes();
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
