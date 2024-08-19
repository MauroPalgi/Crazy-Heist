using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.PlayerLoop;
using UnityEngine.UIElements;

public class RoadManager : Singleton<RoadManager>
{
    private List<ScriptableRoad> _roads;
    private Vector3 spawnPosition = Vector3.zero;
    private Quaternion spawnOrientation = Quaternion.identity;
    private Vector3 globalOrientation = Vector3.forward;
    private Dictionary<RoadType, ScriptableRoad> scriptableRoads;
    [SerializeField] private int numberOfRoads = 10;

    void Start()
    {
        scriptableRoads = ResourceSystem.Instance.GetAllRoad();
        _roads = new List<ScriptableRoad>();
        ScriptableRoad straightRoad = ResourceSystem.Instance.GetRoad(RoadType.Straight);
        ScriptableRoad cornerRoad = ResourceSystem.Instance.GetRoad(RoadType.Corner);
        _roads.Add(straightRoad);
        _roads.Add(straightRoad);
        _roads.Add(cornerRoad);
        _roads.Add(straightRoad);
        _roads.Add(straightRoad);
        _roads.Add(cornerRoad);
        _roads.Add(straightRoad);
        _roads.Add(straightRoad);
        _roads.Add(cornerRoad);
        _roads.Add(straightRoad);
        _roads.Add(straightRoad);
        _roads.Add(cornerRoad);
    }

    private void FillRoadListWithRandomValues()
    {
        List<RoadType> availableRoads = scriptableRoads.Keys.ToList();

        for (int i = 0; i < numberOfRoads; i++)
        {
            RoadType randomRoadType = availableRoads[Random.Range(0, availableRoads.Count)];
            _roads.Add(scriptableRoads[randomRoadType]);
            // Debug.Log(randomRoadType.ToString());
        }
    }


    public void SpawnRoads()
    {
        Debug.Log("Count " + _roads.Count);
        for (int i = 0; i < _roads.Count; i++)
        {
            ScriptableRoad road = _roads[i];
            ScriptableRoad nextRoad = null;
            if (i + 1 < _roads.Count)
            {
                nextRoad = _roads[i + 1];
                Debug.Log(nextRoad.RoadType);

            }
            Debug.Log(road.RoadType);

            Instantiate(road.Prefab, spawnPosition, spawnOrientation);

            switch (i)
            {
                case 0:
                    spawnPosition += globalOrientation * 20;
                    break;
                case 1:
                    spawnPosition += globalOrientation * 30;
                    // globalOrientation = Vector3.forward;
                    // spawnOrientation = Quaternion.identity;
                    break;
                case 2:
                    globalOrientation = Vector3.left;
                    spawnOrientation = Quaternion.Euler(0, -90, 0);
                    spawnPosition += globalOrientation * 30;
                    break;
                case 3:
                    spawnPosition += globalOrientation * 20;
                    break;
                case 4:
                    spawnPosition += globalOrientation * 30;
                    break;
                case 5:
                    globalOrientation = Vector3.back;
                    spawnOrientation = Quaternion.Euler(0, 180, 0);
                    spawnPosition += globalOrientation * 30;
                    break;
                case 6:
                    spawnPosition += globalOrientation * 20;
                    break;
                case 7:

                    spawnPosition += globalOrientation * 30;
                    break;
                case 8:
                    globalOrientation = Vector3.right;
                    spawnOrientation = Quaternion.Euler(0, 90, 0); ;
                    spawnPosition += globalOrientation * 30;
                    break;
                case 9:
                    spawnPosition += globalOrientation * 20;
                    break;
                case 10:

                    spawnPosition += globalOrientation * 30;
                    break;

                default:
                    break;
            }
            Debug.Log(globalOrientation);
            Debug.Log("spawn position " + spawnPosition);
            Debug.Log("spawn Lenght " + road.BaseStats.prefabLenght);
            // spawnPosition += globalOrientation * (road.RoadType.Equals(RoadType.Straight) ? 20 : 30);


        }
    }
}
