using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager S;


    private int _weakNumber = 0;
    public  int WeakNumber
    {
        get{return _weakNumber;}
    }

    private void Start()
    {
        S = this;

        _weakNumber = 1;
    }

    public void GoToNextWeek()
    {
        if(ResurcsManager.S.ResursCvoteInNextWek())
        {
            ResurcsManager.S.toNextWekResursInDB();
            ResurcsManager.S.toNextWekResursTempDic(); 
        }
        _weakNumber += 1;

    }

}
