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
    public Dictionary<int, Build> buildDic = new Dictionary<int, Build>();
    public int key;

    private Build build;   
    private Barn barn = new Barn();
    private DirBuilder dirBuild = new DirBuilder();
    private GameObject goBuild;
    private SpriteRenderer sprTemp;


    private void Start()
    {
        S = this;
    }

    public  void MakeBuild()
    {
        if(buildDic.Count == 0) key = 1;
        else key = buildDic.Keys.Last()+1;

        dirBuild.SetBuildBuilder(barn);
        dirBuild.ConstructionBuild();
        build = dirBuild.GetBuild();
        buildDic.Add(key, build);

        goBuild = Instantiate(prefabHause) as GameObject;
        goBuild.transform.position = MakeGreadBuilder.greadBuilder.transform.position;
        sprTemp = goBuild.GetComponent<SpriteRenderer>();
        sprTemp.sprite = cowHause;
        goBuildDic.Add(key, goBuild);

        Debug.Log("buildDic.Count" + buildDic.Count);
        
    }
    public void OverlayBuildToHexDB(HexTile hex) 
    {

        hex.keyBuild = key; 
    }

}
