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

    [Header("Dynamikally")]
    public Dictionary<int, GameObject> goBuildDic = new Dictionary<int, GameObject>();


    private Build build;   
    private Barn barn = new Barn();
    private DirBuilder dirBuild = new DirBuilder();
    private GameObject goBuild;
    private SpriteRenderer sprTemp;


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

        goBuildDic.Add(MakeKeyBuild(), goBuild);
        //Debug.Log("buildDic.Count" + goBuildDic.Count);

        MakeBuild();
    }
    private int MakeKeyBuild()
    {
        int key;
        if(goBuildDic.Count == 0) key = 1;
        else key = goBuildDic.Keys.Last()+1;
        return key;
    }

    private  void MakeBuild()
    {
        dirBuild.SetBuildBuilder(barn);
        dirBuild.ConstructionBuild();
        build = dirBuild.GetBuild();
        build.name = build.name + MakeKeyBuild();
        BuildDB.SaveBuildDB(build, MakeKeyBuild());
    }

    public void OverlayBuildToHexDB(HexTile hex) 
    {

        hex.keyBuild = MakeKeyBuild(); 
    }

}
