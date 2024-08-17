using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AICarController : MonoBehaviour
{
    [SerializeField] private float reacheadTargetDistance = 10f;
    private GameObject player;
    private Transform targetPositionTransform;
    private CarController carController;
    private Vector3 targetPosition;

    private float reverseTimer = 0f; // Temporizador para el tiempo en reversa
    private bool isReversing = false; // Estado para verificar si está en reversa
    private float reverseDuration = 1f; // Duración de tiempo en reversa antes de girar
    private bool isRotating = false; // Estado para verificar si está en proceso de rotación


    void Start()
    {
        carController = GetComponent<CarController>();
        carController.isAiPlayer = true;
    }

    void Update()
    {
        player = GameObject.FindGameObjectsWithTag("Player")[0];
        if (player != null)
        {

            // if (isRotating)
            // {
            //     RotateTowardsTarget();
            //     return;
            // }

            targetPositionTransform = player.transform;
            SetTargetPosition(targetPositionTransform.position);
            Vector3 dirToMoveForward = (targetPosition - transform.position).normalized;
            float dot = Vector3.Dot(transform.forward, dirToMoveForward);
            float angleToDir = Vector3.SignedAngle(transform.forward, dirToMoveForward, Vector3.up);

            float forwardAmount = dot > 0 ? 1f : -1f;
            float turnAmount = angleToDir > 0 ? 1f : -1f;
            float distanceToTarget = Vector3.Distance(transform.position, targetPosition);

            // Comprobar si el coche está en reversa
            if (forwardAmount < 0)
            {
                isReversing = true;
                reverseTimer += Time.deltaTime;

                if (reverseTimer >= reverseDuration)
                {
                    StartRotationTowardsTarget();
                    return;
                }
            }
            else
            {
                isReversing = false;
                reverseTimer = 0f;
            }

            // Si está muy cerca del objetivo, detenemos el movimiento
            if (distanceToTarget < reacheadTargetDistance)
            {
                forwardAmount = 0;
                turnAmount = 0;
            }
            carController.SetInput(forwardAmount, turnAmount);
        }


    }

    public void SetTargetTransform(Transform target)
    {
        targetPositionTransform = target;
        SetTargetPosition(target.position);
    }

    private void SetTargetPosition(Vector3 pos)
    {
        targetPosition = pos;
    }
    private void StartRotationTowardsTarget()
    {
        isRotating = true; // Indicamos que estamos en proceso de rotación
        carController.SetInput(0f, 0f); // Detenemos el coche mientras rota
    }

    private void RotateTowardsTarget()
    {

    }
}
