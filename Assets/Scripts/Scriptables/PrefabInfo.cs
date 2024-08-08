using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class PrefabInfo
{
    public string prefabPath;
    public string prefabType;
    public bool isCharacterPresent;
    public Vector3 prefabPosition;

    public int prefabLenght;

    public PrefabInfo(string path, string type, bool characterPresent, Vector3 position, int lenght)
    {
        prefabPath = path;
        prefabType = type;
        isCharacterPresent = characterPresent;
        prefabPosition = position;
        prefabLenght = lenght;
    }
}


