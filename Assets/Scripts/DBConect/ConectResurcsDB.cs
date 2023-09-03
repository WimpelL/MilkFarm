using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ConectResurcsDB : MonoBehaviour
{
    public void SaveResurcsBD(Res res, Build build)
    {
        ResurcsBD.ResurcesDic[res] += build.storageResursProduct;
    }
    
}
