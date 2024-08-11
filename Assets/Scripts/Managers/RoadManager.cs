using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoadManager : Singleton<RoadManager>
{
    public void SpawnRoads()
    {
        SpawnLongRoad();
    }


    public void SpawnLongRoad()
    {
        var straigRoadObject = ResourceSystem.Instance.GetRoad(RoadType.Straight);
        var cornerRoadObject = ResourceSystem.Instance.GetRoad(RoadType.Corner);

        var straigRoadPrefab = straigRoadObject.Prefab;
        var cornerRoadPrefab = cornerRoadObject.Prefab;

        var straigRoadRenderer = straigRoadPrefab.GetComponent<Renderer>();

        var enviroment = GameObject.Find("Enviroment");
        Vector3 currentPosition = Vector3.zero;
        for (int i = 0; i < 2; i++)
        {
            currentPosition = new Vector3(currentPosition.x + (i == 0 ? 0 : 20), 0, 0);
            var roadInstance = Instantiate(straigRoadPrefab, currentPosition, Quaternion.identity);
            roadInstance.transform.SetParent(enviroment.transform);
        }
        var cornerLenght = GetTotalLength(cornerRoadPrefab);
        currentPosition = new Vector3(currentPosition.x + 30, 0, 0);
        Quaternion rotation = Quaternion.Euler(0, -90, 0);
        var cornerInstance = Instantiate(cornerRoadPrefab, currentPosition, rotation);
        for (int i = 0; i < 1; i++)
        {
            currentPosition = new Vector3(currentPosition.x, currentPosition.y, -(currentPosition.z + 30));
            var roadInstance = Instantiate(straigRoadPrefab, currentPosition, rotation);
            roadInstance.transform.SetParent(enviroment.transform);
        }

        for (int i = 1; i < 3; i++)
        {
            currentPosition = new Vector3(currentPosition.x, currentPosition.y, (currentPosition.z - 20));
            var roadInstance = Instantiate(straigRoadPrefab, currentPosition, rotation);
            // roadInstance.transform.SetParent(enviroment.transform);
        }
        // cornerInstance.transform.SetParent(enviroment.transform);


    }

    float GetTotalLength(GameObject prefabInstance)
    {
        float totalLength = 0f;

        // Recorre todos los hijos del prefab
        foreach (Transform child in prefabInstance.transform)
        {
            Renderer renderer = child.GetComponent<Renderer>();

            // Si el hijo tiene un Renderer, añade su tamaño al largo total
            if (renderer != null)
            {
                totalLength += renderer.bounds.size.x;
            }
        }

        return totalLength;
    }

}
