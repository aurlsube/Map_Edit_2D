using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class ToolGridGenerator : MonoBehaviour
{
    
    public static GameObject tile;

    public static List<GameObject> listTile = new List<GameObject>();
    public static List<TileSquare> listTileScript = new List<TileSquare>();
    
    public static void GridGen(int width, int length)
    {
        tile = Resources.Load<GameObject>("MapEdit2D/_PREFAB/Carré");
        Debug.Log("je rentre dans gridgen");

        if (tile != null)
        {
            Debug.Log("youpi " + tile);
        }
        GameObject newTileParent = new GameObject();
        newTileParent.transform.name = GridGenerator.gridName;
        newTileParent.transform.position = new Vector3(0,0,0);
        for (int i = 0; i < length; i++)
        {

            for (int y = 0; y < width; y++)
            {
                GameObject newTile = Instantiate(tile, new Vector3(i, y, 0), Quaternion.identity);
                newTile.transform.parent = newTileParent.transform;
                listTileScript.Add(new TileSquare(new Vector2(i,y),newTile));
                listTile.Add(newTile);
            }

        }
        
    }
    public static GameObject GetTileSquare(Vector2 _positionSquare)
    {
        foreach(GameObject _tile in listTile)
        {
            if(_positionSquare == (Vector2)_tile.transform.position)
            {
                return _tile;
            }
        }
        return null;
    }
 
}
