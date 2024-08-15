using System.Collections;
using UnityEngine;

public class SpawnerManager : Singleton<SpawnerManager>
{
    [SerializeField] private GameObject aiPrefab;
    private GameObject player;

    protected override void Awake()
    {
        base.Awake(); // Llama al Awake de la clase base
        StartCoroutine(FindCarControllerWhenAvailable());
        Debug.Log("SpawnerManager Awake");
    }

    private IEnumerator FindCarControllerWhenAvailable()
    {
        while (FindObjectOfType<CarController>() == null)
        {
            yield return null; // Esperar un frame
        }

        player = FindObjectOfType<CarController>().transform.parent.gameObject;
        Debug.Log("Player found after waiting: " + player);
    }

    public void SpawningEnemies()
    {
        if (aiPrefab != null && player != null)
        {
            Vector3 pos = new Vector3(10, 1, 10); // Posición de instanciación
            var currentEnemy = Instantiate(aiPrefab, pos, Quaternion.identity);

            var aiCarController = currentEnemy.GetComponent<AICarController>();
            if (aiCarController != null)
            {
                aiCarController.SetTargetTransform(player.transform);
                Debug.Log("Enemy spawned and target set.");
            }
            else
            {
                Debug.LogWarning("AICarController component not found on spawned enemy.");
            }
        }
        else
        {
            Debug.LogError("Cannot spawn enemy. Ensure aiPrefab and player are initialized.");
        }
    }
}
