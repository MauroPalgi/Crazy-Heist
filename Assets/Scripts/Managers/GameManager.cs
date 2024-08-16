using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class GameManager : Singleton<GameManager>
{

    public GameState State { get; private set; }

    private GameObject currentPlayer;

    void Start() => ChangeState(GameState.Starting);

    public void ChangeState(GameState newState)
    {

        State = newState;
        switch (newState)
        {
            case GameState.Starting:
                HandleStarting();
                break;
            case GameState.SpawningRoads:
                HandleSpawningRoads();
                break;
            case GameState.SpawningPlayer:
                HandleSpawningPlayer();
                break;
            case GameState.SpawningEnemies:
                HandleSpawningEnemies();
                break;
            default:
                throw new ArgumentOutOfRangeException(nameof(newState), newState, null);

        }
    }

    private void HandleSpawningEnemies()
    {
        SpawnerManager.Instance.SpawningEnemies();
    }

    private void HandleSpawningPlayer()
    {
        currentPlayer = PlayerManager.Instance.SpawnPlayer();
        ChangeState(GameState.SpawningEnemies);

    }

    private void HandleSpawningRoads()
    {
        RoadManager.Instance.SpawnRoads();
        ChangeState(GameState.SpawningPlayer);

    }

    private void HandleStarting()
    {
        //ChangeState(GameState.SpawningRoads);
    }

    // void InitializePrefabMatrix()
    // {
    //     Vector3 prefabPosition = new Vector3(0, 0, 0);
    //     prefabMatrix.Add(new PrefabInfo("BasicRoadChunk", "Road", true, prefabPosition, 60));
    // }

    // public void AddRoadPrefab()
    // {
    //     PrefabInfo lastPrefab = prefabMatrix.LastOrDefault();
    //     Vector3 prefabPosition = new Vector3(0, 0, lastPrefab.prefabPosition.z + lastPrefab.prefabLenght);
    //     PrefabInfo prefabInfo = new PrefabInfo("BasicRoadChunk", "Road", true, prefabPosition, 60);
    //     prefabMatrix.Add(prefabInfo);
    //     LoadLastPrefab();
    // }


    // void DrawPrefabMatrix()
    // {

    //     for (int i = 0; i < prefabMatrix.Count; i++)
    //     {

    //         PrefabInfo prefabInfo = prefabMatrix[i];
    //         GameObject prefab = Resources.Load<GameObject>(prefabInfo.prefabPath);

    //         if (prefabInfo != null && prefab != null)
    //         {

    //             Instantiate(prefab, prefabInfo.prefabPosition, Quaternion.identity);
    //         }
    //         else
    //         {
    //             Debug.Log("Error");
    //         }


    //     }

    // }

    // void LoadLastPrefab()
    // {
    //     PrefabInfo lastPrefab = prefabMatrix.LastOrDefault();
    //     GameObject prefab = Resources.Load<GameObject>(lastPrefab.prefabPath);
    //     Instantiate(prefab, lastPrefab.prefabPosition, Quaternion.identity);
    // }


}


[Serializable]
public enum GameState
{
    Starting = 0,
    SpawningRoads = 1,
    SpawningPlayer = 2,
    SpawningEnemies = 3,
}