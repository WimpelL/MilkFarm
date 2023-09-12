using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;


public class BuildManager : MonoBehaviour
{

    public static BuildManager S;

    [Header("Setting")]
    public Sprite office;
    public Sprite magazin;
    public Sprite hause;
    public Sprite pole;
    public Sprite sinoval;
    public Sprite korovnik;
    public Sprite doilnia;
    public GameObject prefabHause;

    private Build build;   
    private Korivnuk barn;
    private DirBuilder dirBuild;
    private GameObject goBuild;
    private SpriteRenderer sprTemp;
    private int key;
    private ConectBuildDB cBuildDB;
    private ConectResurcsDB cResDB;


    private void Start()
    {
        S = this;
        cBuildDB = new ConectBuildDB();
        cResDB = new ConectResurcsDB();
        barn = new Korivnuk();
        dirBuild = new DirBuilder();

    }

    /*



    public void BuildingDoilka()
    {
        tempNameBuilder = "Doilka";
        MGB();
    }
    */

    public  void MakeGOBuild(string tempNameBuilder)
    {
        
        goBuild = Instantiate(prefabHause) as GameObject;
        goBuild.transform.position = VereficGreed.greadBuilder.transform.position;
        sprTemp = goBuild.GetComponent<SpriteRenderer>();
        key = cBuildDB.MakeKeyBuild();
        cBuildDB.SaveGOBuildDic(key, goBuild);  

        if(tempNameBuilder == "Office") sprTemp.sprite = office;
        else if(tempNameBuilder == "Magazine") sprTemp.sprite = magazin;
        else if(tempNameBuilder == "Hause") sprTemp.sprite = hause;
        else if(tempNameBuilder == "Pole") sprTemp.sprite = pole;
        else if(tempNameBuilder == "Sinoval") sprTemp.sprite = sinoval;
        else if(tempNameBuilder == "Korovnik") sprTemp.sprite = korovnik;
        else if(tempNameBuilder == "Doilka") sprTemp.sprite = doilnia;
        else Debug.Log("Сбой в методу MakeGOBuild");
        tempNameBuilder ="";

        MakeBuild();
    }

    private  void MakeBuild()
    {
        dirBuild.SetBuildBuilder(barn);
        dirBuild.ConstructionBuild();
        build = dirBuild.GetBuild();
        build.name = build.name + key;
        cBuildDB.SaveBuildsDBDic(key,build);
        cResDB.SaveResurcsBD(Res.milk,build);
        

    }

    public void OverlayBuildToHexDB(HexTile hex) 
    {
        hex.keyBuild = key; 
    }

}
