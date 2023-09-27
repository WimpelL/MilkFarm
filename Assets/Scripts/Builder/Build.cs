using System.Collections;
using System.Collections.Generic;
using UnityEngine;



[System.Serializable]
public class Build 
{
    public int cinaBuild = 0;
    public int cinaOborud = 0;
    public int cinaRes = 0;
    public int oborud = 0;
    public int maxOborud = 0;
    public Res resursProduct = Res.none;
    public int storageResursProduct = 0;
    public Dictionary<Res,int> resursNeedDic = new Dictionary<Res, int>();
    public string name;
    public bool work = true;
}


