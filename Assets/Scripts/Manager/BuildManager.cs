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
    private Conector conect;
    //private ConectResurcsDB cResDB;


    private void Start()
    {
        S = this;
        GameObject connectorObject = GameObject.Find("Conector");
        conect = connectorObject.AddComponent<Conector>(); 

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
        conect.AddGOToGOBuildDic(key, goBuild);  
        

        if(tempNameBuilder == "Office")
        {
            dirBuild.SetBuildBuilder(buildOffice);
            MakeBuild();
            sprTemp.sprite = office;

        } 
        else if(tempNameBuilder == "Magazine")
        {
            dirBuild.SetBuildBuilder(buildMagazin);
            MakeBuild();
            sprTemp.sprite = magazin;

        } 
        else if(tempNameBuilder == "Hause")
        {
            dirBuild.SetBuildBuilder(buildHause);
            MakeBuild();
            sprTemp.sprite = hause;

        } 
        else if(tempNameBuilder == "Pole")
        {
            dirBuild.SetBuildBuilder(buildPole);
            MakeBuild();
            sprTemp.sprite = pole;

        } 
        else if(tempNameBuilder == "Sinoval")
        {
            dirBuild.SetBuildBuilder(buildSinoval);
            MakeBuild();
            sprTemp.sprite = sinoval;

        } 
        else if(tempNameBuilder == "Korovnik")
        {
            dirBuild.SetBuildBuilder(buildKorivnuk);
            MakeBuild();
            sprTemp.sprite = korovnik;

        } 
        else if(tempNameBuilder == "Doilka")
        {
            dirBuild.SetBuildBuilder(buildMolocodoil);
            MakeBuild();
            sprTemp.sprite = doilnia;

        } 
        else Debug.Log("Сбой методу MakeGOBuild");
        tempNameBuilder ="";

    }
    public int MakeKeyBuild()
    {
        int key;
        if(conect.InfoBuildsDBDic.Count == 0) key = 1;
        else key = conect.InfoBuildsDBDic.Keys.Max() + 1;
        return key;
    }

    private  void MakeBuild()
    {
        dirBuild.ConstructionBuild();
        build = dirBuild.GetBuild();
        build.name = build.name + key;
        conect.AddBuildToBuildsDBDic(key,build);

        ResurcsManager.S.CostsResourcesForBuilding(build);
        //ResurcsManager.S.CurrentReceiptsOfResources(build);
        
    }

    public void OverlayBuildToHexDB(HexTile hex) 
    {
        hex.keyBuild = key; 
    }

}
