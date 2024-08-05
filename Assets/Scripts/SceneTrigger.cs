using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneTrigger : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject roadSection;
    public int roadLenght;

    private void Start()
    {
    }
    private void OnTriggerEnter(Collider other)
    {


        // Loguear todos los componentes del objeto
        Debug.Log("Tag: " + other.gameObject.tag);
        if (other.gameObject.CompareTag("Trigger"))
        {
            Vector3 roadPosition = new Vector3(roadSection.transform.position.x + roadLenght, roadSection.transform.position.y, roadSection.transform.position.z );
                    Debug.Log("here");


            Instantiate(roadSection, roadPosition, roadSection.transform.rotation);
        }
    }
}
