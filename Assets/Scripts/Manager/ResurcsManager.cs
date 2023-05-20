using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResurcsManager : MonoBehaviour
{

    public static float Milk
    {
        get { return milk; }
        set { milk = value; } 
    }
    private static float milk;


}
public enum Res
{
    none,
    hey,
    milk,
    cow,
    piple,
    gold
}
