using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;


public class BuildManager : MonoBehaviour
{

    public static BuildManager S;

    [Header("Setting sprite Hause")]
    public Sprite office;
    public Sprite magazin;
    public Sprite hause;
    public Sprite pole;
    public Sprite sinoval;
    public Sprite korovnik;
    public Sprite doilnia;

    [Header("Setting sprite Gear")]
    public Sprite gearPoleSprite;
    public Sprite gearSinovalSprite;
    public Sprite gearKorovnikSprite;
    public Sprite gearDoilniaSprite;

    [Header("Setting sprite Stop/Play")]
    public Sprite stopSpr;
    public Sprite playSpr;

    [Header("Setting sprite prefabHause")]
    public GameObject prefabHause;
    public GameObject prefabGear;
    public GameObject prefabStop;



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
    private GameObject goGear;
    private GameObject goStop;
    private Dictionary<int,GameObject> _goStopDic = new Dictionary<int, GameObject>();



    private void Start()
    {
        S = this;
        GameObject connectorObject = GameObject.Find("Conector");
        conect = connectorObject.AddComponent<Conector>(); 

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
        ResurcsManager.S.ResourcesForBuilding(build);
        
    }

    public void OverlayBuildToHexDB(HexTile hex) 
    {
        hex.keyBuild = key; 
    }

    public void AddGear(Build build)
    {
        if(build.oborud <= build.maxOborud)
        {
            
            build.oborud += 1;

            ResurcsManager.S.resurceForAddGear(build);

            goGear = goBuild = Instantiate(prefabGear) as GameObject;
            int keyT = conect.InfoBuildsDBDic.FirstOrDefault(pair => pair.Value == build).Key;
            goGear.transform.position = RandomVec (conect.InfoGOBuildDBDic[keyT].transform.position);
            sprTemp = goGear.GetComponent<SpriteRenderer>();
            if(build.name.StartsWith("Pole")) sprTemp.sprite = gearPoleSprite;
            else if(build.name.StartsWith("Sinoval")) sprTemp.sprite = gearSinovalSprite;
            else if(build.name.StartsWith("Korivnuk")) sprTemp.sprite = gearKorovnikSprite;
            else if(build.name.StartsWith("Molocodoilka")) sprTemp.sprite = gearDoilniaSprite;
            else  Debug.Log("AddGear.build.name.StartsWith problem");

        }
        else
        {
            Debug.Log("Max oborud");
        }
    }
    private Vector3 RandomVec (Vector3 vector3)
    {
        var offset = Random.insideUnitCircle * Random.Range(0.1f,0.3f);
        offset = offset.normalized;
        var vec2 = offset + Random.insideUnitCircle;
        vector3 = new Vector3(vector3.x + vec2.x, vector3.y + vec2.y, -1f);
        return vector3; 
    }

    public void StopBuildinDB(Build build)
    {
        if(build.work)
        {
            int keyT = conect.InfoBuildsDBDic.FirstOrDefault(pair => pair.Value == build).Key;
            conect.StopBuildinDB(keyT);
            ResurcsManager.S.ResurceForStopBuid();
            Debug.Log("keyT " + keyT);
            goStop = Instantiate(prefabStop) as GameObject;
            Vector3 vect3SBT = conect.InfoGOBuildDBDic[keyT].transform.position;
            vect3SBT.z = -1f;
            goStop.transform.position = vect3SBT;
            sprTemp = goStop.GetComponent<SpriteRenderer>();
            sprTemp.sprite = stopSpr;
            _goStopDic.Add(keyT,goStop);
            
        }
    }
    public void PlayBuildinDB (Build build)
    {
        if(!build.work)
        {
            int keyT = conect.InfoBuildsDBDic.FirstOrDefault(pair => pair.Value == build).Key;
            conect.PlayBuildinDB(keyT);
            ResurcsManager.S.ResurceForPlayBuid(); 

            GameObject destroyGoStop = _goStopDic[keyT];
            _goStopDic.Remove(keyT);
            Destroy(destroyGoStop);
        }
    }
    public void DeleteBuild(int destroyKey)
    {
        conect.RemoveBuildToBuildsDBDic(destroyKey);
        GameObject gameObjectToRemove = conect.InfoGOBuildDBDic[destroyKey];
        conect.RemoveGOToGOBuildDic(destroyKey);
        Destroy(gameObjectToRemove);

        if(_goStopDic[destroyKey] != null)
        {
            GameObject destroyGoStop = _goStopDic[destroyKey];
            _goStopDic.Remove(destroyKey);
            Destroy(destroyGoStop);
        }
    } 
}
