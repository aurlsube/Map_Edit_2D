using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

class GridGenerator : EditorWindow
{

    public static string gridName;
    public Texture[] arrayIconeTool;
    Vector2Int gridSize;
    int windowToolSelected;
    int toolsSelected = 0;
    int tilesType = 0;
    public static int paintSize = 1;

    Vector3 mousePosition;

    // Window has been selected
    void OnFocus()
    {
        // Remove delegate listener if it has previously
        // been assigned.
        SceneView.onSceneGUIDelegate -= OnSceneGUI;
        // Add (or re-add) the delegate.
        SceneView.onSceneGUIDelegate += OnSceneGUI;
    }

    void OnDestroy()
    {
        // When the window is destroyed, remove the delegate
        // so that it will no longer do any drawing.
        SceneView.onSceneGUIDelegate -= OnSceneGUI;
    }
    void OnSceneGUI(SceneView sceneView)
    {

        if (toolsSelected == 0)
        {
            ToolGeneric.ChangeSpriteToClick();
        }
        if (toolsSelected == 1)
        {

        }
        if (toolsSelected == 2)
        {

        }

    }


    [MenuItem("Tools/Map Edit2D/Grid Generator")]

    public static void ShowWindow()
    {
        EditorWindow.GetWindow(typeof(GridGenerator));
    }

    void OnGUI()
    {
        arrayIconeTool = Resources.LoadAll<Texture>("Resources/MapEdit2D/_SPRITE/IconeTools");
        windowToolSelected = GUILayout.Toolbar(windowToolSelected, new string[] { "Generator", "Tools" });
        switch (windowToolSelected)
        {
            case 1:
                EditorGUILayout.Space();

                ToolGeneric.CreateButonSearchSpriteFolder();

                GUILayout.BeginHorizontal();

                GUILayout.TextField(ToolGeneric.pathFolderSprite);

                ToolGeneric.CreateButtonSearchSprite();

                GUILayout.EndHorizontal();
                toolsSelected = GUILayout.Toolbar(toolsSelected, new string[] { "1", "2", "3" });
                switch (toolsSelected)
                {
                    default:
                        paintSize = EditorGUILayout.IntSlider("Paint size : ", paintSize, 1, 10, new GUILayoutOption[] { });

                        EditorGUILayout.Space();

                        ToolGeneric.CreateSpriteGridScrollView();
                        break;

                    case 1:


                        break;

                    case 2:
                        break;
                }



                break;


            default:

                EditorGUILayout.Space();

                gridName = EditorGUILayout.TextField("Grid Name : ", gridName);

                gridSize = EditorGUILayout.Vector2IntField("Grid size :", gridSize);

                tilesType = EditorGUILayout.Popup("Type", tilesType, new string[] { "Square", "Isometric", "Hexagonal" });

                EditorGUILayout.Space();

                if (GUILayout.Button("Generate Grid"))
                {
                    ToolGridGenerator.GridGen(gridSize.y, gridSize.x);
                }

                break;
        }

    }

}
