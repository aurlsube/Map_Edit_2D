using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System.Linq;
public class ToolGetSpriteInFolder : MonoBehaviour
{

    public static List<string> takeSpriteToFolder(string _pathFolder)
    {
        List<string> filePathList = Directory.GetFiles(_pathFolder, "*.*", SearchOption.AllDirectories)
                        .Where(file => file.ToLower().EndsWith("png") || file.ToLower().EndsWith("jpg")|| file.ToLower().EndsWith("jpeg"))
                        .ToList();
        return filePathList;
    }

}
