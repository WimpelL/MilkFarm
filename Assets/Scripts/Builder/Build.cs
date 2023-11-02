using System.Collections;
using System.Collections.Generic;
using UnityEngine;



[System.Serializable]
public class Build 
{
    public string name;
    public int cinaBuild = 0;
    public int cinaOborud = 0;
    public int cinaRes = 0;
    public int oborud = 1;
    public int maxOborud = 0;
    public Res resursProduct = Res.none;
    public int storageResursProduct = 0;
    public Dictionary<Res,int> resursNeedDic = new Dictionary<Res, int>();
    public bool work = true;
    public List<ResNead> resNeedDic = new List<ResNead>();
}


