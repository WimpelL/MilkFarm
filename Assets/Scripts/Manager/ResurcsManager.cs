using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResurcsManager : MonoBehaviour
{
    

    public static float Milk
    {
        get { return ResurcsBD.ResurcesDic[Res.milk]; }
        set { ResurcsBD.ResurcesDic[Res.milk] = value; } 
    }
    
    private void Update() {

        BarnResGreands();
    }

    private void BarnResGreands()
    {
       // ResurcsBD.ResurcesDic[Res.milk] = ResurcsBD.ResurcesDic[Res.milk] + 1; 
    }

}
