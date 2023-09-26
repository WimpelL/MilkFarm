using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager S;

    private Conector conect;

    private void Start()
    {
        S = this;
        GameObject connectorObject = GameObject.Find("Conector");
        conect = connectorObject.AddComponent<Conector>(); 
    }

    public void GoToNextWeek()
    {
        conect.ResToResurcsBD(Res.power,2);
        conect.ResToResurcsBD(Res.piple,2);
        foreach (var build in conect.InfoBuildsDBDic)
        {
            ResurcsManager.S.CurrentReceiptsOfResources(build.Value);
        }
        ResurcsManager.S.ObnulenniaResurcesTempDic();       
        ResurcsManager.S.ZanesenniaResurcesTempDic();

        
    }

}
