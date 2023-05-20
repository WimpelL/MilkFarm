using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Reaction : MonoBehaviour
{
    public Canvas go;
    private void OnMouseDown() {
        HexTile hex = gameObject.GetComponent<HexTile>();
    }
}
