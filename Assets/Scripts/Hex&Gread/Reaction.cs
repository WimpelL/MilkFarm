using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Reaction : MonoBehaviour
{
    
    private void OnMouseDown()
    {
        HexTile hex = gameObject.GetComponent<HexTile>();

        UIManager.S.InicialUIReaction(hex);
    }
}
