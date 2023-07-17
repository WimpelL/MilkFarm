using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum EmployStatusType
{
    none, busy
}

public class HexTile : MonoBehaviour
{
    public EmployStatusType statusType = EmployStatusType.none;
    public Vector2 posOnMap;
    public int posGoOnMapX;
    public int posGoOnMapY;
    public int keyBuild;

}
