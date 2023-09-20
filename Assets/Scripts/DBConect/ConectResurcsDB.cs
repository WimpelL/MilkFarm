using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ConectResurcsDB 
{
    public void AddResToResurcsBD(Res res, int quantity)
    {
        ResurcsBD.ResurcesDic[res] += quantity;
    }
    public void RemoveResToResurcsBD(Res res, int quantity)
    {
        ResurcsBD.ResurcesDic[res] -= quantity;
    }
    public Dictionary<Res,float> InfoResurcesDic
    {
        get{return  ResurcsBD.ResurcesDic;}
    }
    
}
