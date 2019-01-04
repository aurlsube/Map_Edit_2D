using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using System.IO;

public class ToolGeneric : MonoBehaviour
{
    public static string pathFolderSprite = "Path of your folder";

    public static List<string> imagePathList;
    public static List<Sprite> spriteFolderList;
    public static Sprite[] spriteFolderArray;

    public static List<Texture> textureFolderList;
    public static Texture[] textureFolderArray;

    public static int selectionSpriteDraw = -1;

    public static Vector2 scrollPos = Vector2.zero;

    public static Sprite spriteSelected = null;

    public static void CreateButonSearchSpriteFolder()
    {
        if (GUILayout.Button("Selection sprite folder"))
        {
            pathFolderSprite = EditorUtility.OpenFolderPanel("Folder sprite selection", "", "");
        }
    }

    public static void CreateButtonSearchSprite()
    {
        if (GUILayout.Button("Search Sprite"))
        {
            spriteFolderList = new List<Sprite>();
            textureFolderList = new List<Texture>();
            imagePathList = ToolGetSpriteInFolder.takeSpriteToFolder(ToolGeneric.pathFolderSprite);

            foreach (string _filePath in imagePathList)
            {
                Sprite newSprite;
                newSprite = IMG2Sprite.LoadNewSprite(_filePath);
                newSprite.name = Path.GetFileNameWithoutExtension(_filePath);
                spriteFolderList.Add(newSprite);

                Texture newTexture;
                newTexture = newSprite.texture;
                textureFolderList.Add(newTexture);
            }
            spriteFolderArray = spriteFolderList.ToArray();
            textureFolderArray = textureFolderList.ToArray();
            selectionSpriteDraw = 0;
        }
    }

    public static void CreateSpriteGridScrollView()
    {

        scrollPos = GUILayout.BeginScrollView(scrollPos, GUILayout.Width(Screen.width), GUILayout.Height(Screen.height / 1.5f));
        {
            if (selectionSpriteDraw != -1)
            {
                selectionSpriteDraw = GUILayout.SelectionGrid(selectionSpriteDraw, textureFolderArray, textureFolderArray.Length / 10, new GUILayoutOption[] { GUILayout.Width(Screen.width) });
                spriteSelected = spriteFolderArray[selectionSpriteDraw];
            }
        }

        GUILayout.EndScrollView();
    }

    public static void ChangeSpriteToClick()
    {
        if (Event.current.type == EventType.MouseDown && Event.current.button == 0)
        {
            Debug.Log("Je click");
            Ray worldRay = HandleUtility.GUIPointToWorldRay(Event.current.mousePosition);
            RaycastHit hitInfo;
            Debug.Log(Physics.Raycast(worldRay, out hitInfo, int.MaxValue));
            if (Physics.Raycast(worldRay, out hitInfo, int.MaxValue))
            {
                Debug.Log("Physics raycast");
                if (hitInfo.collider.gameObject != null)
                {
                    GameObject _hit = hitInfo.collider.gameObject;
                    List<GameObject> _tileSquareList = new List<GameObject>();
                    for (int i = 0; i < GridGenerator.paintSize; i++)
                    {
                        for (int j = 0; j < GridGenerator.paintSize; j++)
                        {
                            GameObject _tempTile = ToolGridGenerator.GetTileSquare(new Vector2(i + _hit.transform.position.x, j + _hit.transform.position.y));
                            if(_tempTile == null) continue;
                            _tileSquareList.Add(ToolGridGenerator.GetTileSquare(new Vector2(i + _hit.transform.position.x, j + _hit.transform.position.y)));
                        }
                    }
                    foreach (GameObject _tile in _tileSquareList)
                    {
                        _tile.GetComponentInChildren<SpriteRenderer>().sprite = spriteSelected;
                    }
                    Debug.Log("gameobject");
                    /* Debug.Log(spriteSelected.pixelsPerUnit);
                    hitInfo.collider.gameObject.GetComponentInChildren<SpriteRenderer>().sprite = spriteSelected;
                    Debug.Log(ToolGeneric.spriteSelected.texture.height);*/
                }
            }
        }
    }

}
