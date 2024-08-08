using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneTrigger : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject roadSection;
    private bool isAlreadyTrigger = false;

    private void Start()
    {
    }
    private void OnTriggerEnter(Collider other)
    {


        // Loguear todos los componentes del objeto

        if (other.gameObject.CompareTag("Trigger") && !isAlreadyTrigger)
        {
            isAlreadyTrigger = true;
            // PrefabManager.Instance.AddRoadPrefab();
        }
    }
}
