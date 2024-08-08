using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoadManager : Singleton<RoadManager>
{
    public void SpawnRoads()
    {
        SpawnRoad(RoadType.Straight, new Vector3(0, 0, 0));
    }

    private void SpawnRoad(RoadType t, Vector3 pos)
    {
        var roadScriptable = ResourceSystem.Instance.GetRoad(t);
        var spawned = Instantiate(roadScriptable.Prefab, pos, Quaternion.identity);

        var enviroment = GameObject.Find("Enviroment");
        spawned.transform.SetParent(enviroment.transform);
        /* puedo modificar spawned aca*/
    }
}
