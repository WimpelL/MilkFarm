using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;


public class BuildManager : MonoBehaviour
{

    public static BuildManager S;

    [Header("Setting")]
    public Sprite manHause;
    public Sprite cowHause;
    public Sprite hayHause;
    public Sprite skladHause;
    public Sprite magazinHause;
    public GameObject prefabHause;

    private Build build;   
    private Barn barn = new Barn();
    private DirBuilder dirBuild = new DirBuilder();
    private GameObject goBuild;
    private SpriteRenderer sprTemp;
    private int key;
    private ConectBuildDB cBuildDB = new ConectBuildDB();
    private ConectResurcsDB cResDB = new ConectResurcsDB();


    private void Start()
    {
        S = this;
    }

    public  void MakeGOBuild()
    {
        goBuild = Instantiate(prefabHause) as GameObject;
        goBuild.transform.position = MakeGreadBuilder.greadBuilder.transform.position;
        sprTemp = goBuild.GetComponent<SpriteRenderer>();
        sprTemp.sprite = cowHause;
        key = cBuildDB.MakeKeyBuild();
        cBuildDB.SaveGOBuildDic(key, goBuild);
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
