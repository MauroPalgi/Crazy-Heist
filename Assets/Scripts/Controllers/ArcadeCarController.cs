using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.PlayerLoop;

public class ArcadeCarController : MonoBehaviour
{


    [Header("References")]
    [SerializeField] private Rigidbody carRB;
    [SerializeField] private Transform[] rayPoints;
    [SerializeField] private LayerMask drivable;

    [Header("Suspension Settings")]
    [SerializeField] private float springStiffness;
    [SerializeField] private float restLength;
    [SerializeField] private float springTravel;
    [SerializeField] private float wheelRadius;

    private void Start()
    {
        carRB = GetComponent<Rigidbody>();
    }
    void FixedUpdate()
    {
        Suspension();
    }
    // Update is called once per frame
    private void Suspension()
    {
        // Recorre todos los puntos de rayos de la suspensión
        foreach (Transform rayPoint in rayPoints)
        {
            // Define la longitud máxima del rayo (la longitud en reposo más la capacidad de viaje de la suspensión)
            float maxLength = restLength + springTravel;

            // Variable para almacenar la información del rayo si impacta con algo
            RaycastHit hit;

            // Lanza un rayo desde el punto hacia abajo para detectar el suelo u otras superficies
            if (Physics.Raycast(rayPoint.position, -rayPoint.up, out hit, maxLength + wheelRadius, drivable))
            {
                // Calcula la longitud actual del resorte (distancia desde el punto de origen del rayo hasta la superficie)
                float currentSpringLength = hit.distance - wheelRadius;

                // Calcula la compresión del resorte en proporción al recorrido total
                float springCompression = (restLength - currentSpringLength) / springTravel;

                // Calcula la fuerza del resorte según la rigidez del resorte y la compresión
                float springForce = springStiffness * springCompression;

                // Aplica la fuerza en el punto de origen del rayo
                carRB.AddForceAtPosition(springForce * rayPoint.up, rayPoint.position);

                // Dibuja una línea roja en la escena para visualizar el rayo que impacta con la superficie
                Debug.DrawLine(rayPoint.position, hit.point, Color.red);
            }
            else
            {
                // Si el rayo no impacta con ninguna superficie, dibuja una línea verde que representa la longitud máxima del rayo
                Debug.DrawLine(rayPoint.position, rayPoint.position + (wheelRadius + maxLength) * -rayPoint.up, Color.green);
            }
        }
    }
}