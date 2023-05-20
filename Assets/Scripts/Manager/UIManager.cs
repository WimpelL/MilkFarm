using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class UIManager : MonoBehaviour
{
    public TextMeshProUGUI milk;


    void Start()
    {
        milk.text = "Milk: " + ResurcsManager.Milk;
        
    }


    void Update()
    {
        milk.text = "Milk: " + ResurcsManager.Milk;
        
    }
}
