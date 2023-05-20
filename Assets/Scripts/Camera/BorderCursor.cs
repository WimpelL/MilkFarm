using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BorderCursor : MonoBehaviour
{
    /// <summary>
    /// Предотвращает выход игрового обьекта за границы екрана.
    /// 
    /// </summary>

    [Header ("Set in Inspector")]
    public float radius = 1f;
    public GameObject map;
    public float speadVelosityMouse = 1f;


    private float mapHeightT;
    private  float mapHeightD = 0f;
    private  float mapWidthR;
    private  float mapWidthL = 0f;



    [Header("Set Dynamically")]
    private  float camHeight;    
    private  float camWidth;
    private  Vector3 posMouse;

    private  float borderCamWidthRight;
    private  float borderMapWidthRight;

    private float borderCamWidthLeft;
    private  float borderMapWidthLeft;
    private  Vector3 pos;
    private  float borderCamHeightTop;
    private  float borderMapHeightTop;

    private  float borderCamHeightDown;
    private  float borderMapHeightDown;

    void Awake()
    {
        mapHeightT = map.transform.localScale.y;
        mapWidthR = map.transform.localScale.x;

        camHeight = Camera.main.orthographicSize;
        camWidth = camHeight * Camera.main.aspect;

        pos = transform.position;

        borderCamWidthRight = (pos.x + camWidth ) - radius;
        borderMapWidthRight = (mapWidthR - radius * 2);

        borderCamWidthLeft = (pos.x - camWidth ) + radius;
        borderMapWidthLeft = (mapWidthL + radius * 2);

        borderCamHeightTop = (pos.y + camHeight ) - radius;
        borderMapHeightTop = (mapHeightT - radius * 2);

        borderCamHeightDown = (pos.y - camHeight) + radius;
        borderMapHeightDown = (mapHeightD + radius * 2);

    }

    void LateUpdate() 
    {
        pos = transform.position;
        posMouse = Camera.main.ScreenToWorldPoint(Input.mousePosition);

        pos = transform.position;

        if(posMouse.x > borderCamWidthRight && posMouse.x < borderMapWidthRight) 
        {
            float spead = speadVelosityMouse * Time.deltaTime; 
            borderCamWidthRight += spead;
            borderCamWidthLeft += spead;
            pos.x += spead;
            transform.position = pos;
        }
        if(posMouse.x < borderCamWidthLeft && posMouse.x > borderMapWidthLeft) 
        {
            float spead = speadVelosityMouse * Time.deltaTime; 
            borderCamWidthLeft -= spead; 
            borderCamWidthRight -= spead; 
            pos.x -= spead;
            transform.position = pos;
        }

        if(posMouse.y > borderCamHeightTop && posMouse.y < borderMapHeightTop) 
        {
            float spead = speadVelosityMouse * Time.deltaTime; 
            borderCamHeightTop += spead; 
            borderCamHeightDown += spead; 
            pos.y += spead;
            transform.position = pos;
        }

        if(posMouse.y < borderCamHeightDown && posMouse.y > borderMapHeightDown) 
        {
            float spead = speadVelosityMouse * Time.deltaTime; 
            borderCamHeightDown -= spead; 
            borderCamHeightTop -= spead; 
            pos.y -= spead;
            transform.position = pos;
        }
    }
}


