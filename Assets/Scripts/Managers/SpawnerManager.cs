using System.Collections;
using UnityEngine;

public class SpawnerManager : Singleton<SpawnerManager>
{
    [SerializeField] private GameObject aiPrefab;


    public void SpawningEnemies()
    {
        if (aiPrefab != null)
        {
            Vector3 pos = new Vector3(10, 1, 10); // Posición de instanciación
            Instantiate(aiPrefab, pos, Quaternion.identity);


        }

    }
}
