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
    private Korivnuk buildKorivnuk;
    private Hause buildHause;
    private Magazin buildMagazin;
    private Molocodoil buildMolocodoil;
    private Office buildOffice;
    private Pole buildPole;
    private Sinoval buildSinoval;

    private DirBuilder dirBuild;
    private GameObject goBuild;
    private SpriteRenderer sprTemp;
    private int key;
    private ConectBuildDB cBuildDB;
    //private ConectResurcsDB cResDB;


    private void Start()
    {
        S = this;
        cBuildDB = new ConectBuildDB();
        //cResDB = new ConectResurcsDB();
        dirBuild = new DirBuilder();

        buildOffice = new Office();
        buildMagazin = new Magazin();
        buildHause = new Hause();
        buildPole = new Pole();
        buildSinoval = new Sinoval();
        buildKorivnuk = new Korivnuk();
        buildMolocodoil = new Molocodoil();

    }


    public  void MakeGOBuild(string tempNameBuilder)
    {
        
        goBuild = Instantiate(prefabHause) as GameObject;
        goBuild.transform.position = VereficGreed.greadBuilder.transform.position;
        sprTemp = goBuild.GetComponent<SpriteRenderer>();
        key = MakeKeyBuild();
        cBuildDB.AddGOToGOBuildDic(key, goBuild);  
        

        if(tempNameBuilder == "Office")
        {
            dirBuild.SetBuildBuilder(buildOffice);
            MakeBuild();
            sprTemp.sprite = office;
            ResurcsManager.S.AddResWhileBuildingToResurcsBD(build);
            ResurcsManager.S.RemoveWhileBuildingResToResurcsBD(build);
        } 
        else if(tempNameBuilder == "Magazine")
        {
            dirBuild.SetBuildBuilder(buildMagazin);
            MakeBuild();
            sprTemp.sprite = magazin;
            ResurcsManager.S.AddResWhileBuildingToResurcsBD(build);
            ResurcsManager.S.RemoveWhileBuildingResToResurcsBD(build);
        } 
        else if(tempNameBuilder == "Hause")
        {
            dirBuild.SetBuildBuilder(buildHause);
            MakeBuild();
            sprTemp.sprite = hause;
            ResurcsManager.S.AddResWhileBuildingToResurcsBD(build);
            ResurcsManager.S.RemoveWhileBuildingResToResurcsBD(build);
        } 
        else if(tempNameBuilder == "Pole")
        {
            dirBuild.SetBuildBuilder(buildPole);
            MakeBuild();
            sprTemp.sprite = pole;
            ResurcsManager.S.AddResWhileBuildingToResurcsBD(build);
            ResurcsManager.S.RemoveWhileBuildingResToResurcsBD(build);
        } 
        else if(tempNameBuilder == "Sinoval")
        {
            dirBuild.SetBuildBuilder(buildSinoval);
            MakeBuild();
            sprTemp.sprite = sinoval;
            ResurcsManager.S.AddResWhileBuildingToResurcsBD(build);
            ResurcsManager.S.RemoveWhileBuildingResToResurcsBD(build);
        } 
        else if(tempNameBuilder == "Korovnik")
        {
            dirBuild.SetBuildBuilder(buildKorivnuk);
            MakeBuild();
            sprTemp.sprite = korovnik;
            ResurcsManager.S.AddResWhileBuildingToResurcsBD(build);
            ResurcsManager.S.RemoveWhileBuildingResToResurcsBD(build);
        } 
        else if(tempNameBuilder == "Doilka")
        {
            dirBuild.SetBuildBuilder(buildMolocodoil);
            MakeBuild();
            sprTemp.sprite = doilnia;
            ResurcsManager.S.AddResWhileBuildingToResurcsBD(build);
            ResurcsManager.S.RemoveWhileBuildingResToResurcsBD(build);
        } 
        else Debug.Log("Сбой методу MakeGOBuild");
        tempNameBuilder ="";

    }
    public int MakeKeyBuild()
    {
        int key;
        if(cBuildDB.InfoBuildsDBDic.Count == 0) key = 1;
        else key = cBuildDB.InfoBuildsDBDic.Keys.Max() + 1;
        return key;
    }

    private  void MakeBuild()
    {
        dirBuild.ConstructionBuild();
        build = dirBuild.GetBuild();
        build.name = build.name + key;
        cBuildDB.AddBuildToBuildsDBDic(key,build);
    }

    public void OverlayBuildToHexDB(HexTile hex) 
    {
        hex.keyBuild = key; 
    }

}
