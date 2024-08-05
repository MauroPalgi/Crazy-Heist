using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneTrigger : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject roadSection;
    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("Trigger Entered by: " + other.gameObject.name);

        // Loguear la posición del objeto que entra en el trigger
        Debug.Log("Object Position: " + other.transform.position);

        // Loguear la rotación del objeto que entra en el trigger
        Debug.Log("Object Rotation: " + other.transform.rotation);

        // Loguear la escala del objeto que entra en el trigger
        Debug.Log("Object Scale: " + other.transform.localScale);

        // Loguear todos los componentes del objeto
        Component[] components = other.GetComponents<Component>();
        if (other.gameObject.CompareTag("Trigger"))
        {
            Instantiate(roadSection, new Vector3(0, 0.1f, 65), Quaternion.identity);
        }
    }
}
