using System.Collections;
using System.Collections.Generic;
using UnityEngine;



[System.Serializable]
public class Build 
{
    public Res resursInstrument = Res.none;
    public int storageResursInstrument = 0;
    public Res resursProduct = Res.none;
    public float storageResursProduct = 0.0f;
    public Res resursNeed = Res.none;
    public float storageResursNeed = 0.0f;
    public int unit;
    public float spead = 0.0f;
    public string name;
}


