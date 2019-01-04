using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TileSquare
{

    public Vector2 positionTile;
    public GameObject myGameObject;

    public TileSquare(Vector2 _positionTile, GameObject _myGameObject)
    {
        positionTile = _positionTile;
        myGameObject = _myGameObject;
    }

}
