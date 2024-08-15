using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnerManager : Singleton<SpawnerManager>
{
    // Start is called before the first frame update
    [SerializeField] private GameObject ai;
    private AICarController aiCarController;
    private GameObject player;
    protected override void Awake()
    {
        base.Awake(); // Llama al Awake de la clase base

        // Aquí puedes añadir la lógica específica para la clase derivada
        StartCoroutine(FindCarControllerWhenAvailable());
        Debug.Log("DerivedSingleton Awake");
    }


    private IEnumerator FindCarControllerWhenAvailable()
    {
        while (FindObjectOfType<CarController>() == null)
        {
            yield return null; // Esperar un frame
        }

        player = FindObjectOfType<CarController>().transform.parent.gameObject;
        Debug.Log("Player found after waiting: " + player);

        if (ai != null)
        {
            aiCarController = ai.GetComponent<AICarController>();
            Debug.Log("AI Car Controller found: " + aiCarController);
        }

    }

    public void SpawningEnemies(GameObject currentPlayer) 
    {
        if (ai != null && aiCarController != null && player != null)
        {
            Vector3 pos = new Vector3(10, 1, 10);
            aiCarController.SetTargetPosition(currentPlayer.transform.position);
            var currentEnemy = Instantiate(ai, pos, Quaternion.identity);
            Debug.Log(currentEnemy.name);
        }

    }
}
