using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class  MakeGreadBuilder : MonoBehaviour
{
    [Header("Setting MakeGreadBuilder")]
    public GameObject greadBuilderPrefab;  

    private Vector3 mousePosition, worldPosition;
    public static GameObject greadBuilder;

    public void MGB()
    {
        if(greadBuilder == null)
        {
            //if 'Builder' battum
            greadBuilder = Instantiate<GameObject>(greadBuilderPrefab);
            mousePosition = Input.mousePosition;
            mousePosition.z = 10.0f; // встановлюємо зміщення по осі Z для перетворення в координати світу
            greadBuilder.transform.position = Camera.main.ScreenToWorldPoint(mousePosition);
        }
        
    } 

}

