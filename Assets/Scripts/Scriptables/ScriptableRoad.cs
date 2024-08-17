using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(fileName = "New Scriptable Road")]
public class ScriptableRoad : ScriptableObject
{
    [SerializeField] private Stats _stats;
    private Stats BaseStats => _stats;
    public RoadType RoadType;
    public GameObject Prefab;
    public int PrefabLenght;

    private Quaternion nextPrefabOrientation;

    // private Dictionary<Vector3, Quaternion> getNextPositionAndOrientation(Vector3 currenPosition, Quaternion currentOrientation);


}

[Serializable]
public enum RoadType
{
    Straight = 0,
    Corner = 1,
    Right = 2
}



[Serializable]
public struct Stats
{
    public string PrefabPath;
    public RoadType RoadType;
    public bool isCharacterPresent;
    public Vector3 prefabPosition;
    public int prefabLenght;

}