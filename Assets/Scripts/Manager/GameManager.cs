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
        if(ResurcsManager.S.ResursCvoteInNextWek())
        {
            ResurcsManager.S.toNextWekResursInDB();
            ResurcsManager.S.toNextWekResursTempDic(); 
        }


        
    }

}
