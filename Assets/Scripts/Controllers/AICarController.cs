using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AICarController : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] private Transform targetPositionTransform;
    private CarController carController;
    private Vector3 targetPosition;
    void Start()
    {
        carController = GetComponent<CarController>();
        carController.isAiPlayer = true;
    }

    // Update is called once per frame
    void Update()
    {
        SetTargetPosition(targetPositionTransform.position);
        Vector3 dirToMoveForward = (targetPosition - transform.position).normalized;
        float dot = Vector3.Dot(transform.forward, dirToMoveForward);
        float angleToDir = Vector3.SignedAngle(transform.forward, dirToMoveForward, Vector3.up);

        float forwardAmount = dot > 0 ? 1f : -1f;
        float turnAmount = angleToDir > 0 ? 1f : -1f;
        float reacheadTargetDistance = 10f;
        float distanceToTarget = Vector3.Distance(transform.position, targetPosition);
        if (distanceToTarget < reacheadTargetDistance)
        {
            forwardAmount = 0;
            turnAmount = 0;
        }

        carController.SetInput(forwardAmount, turnAmount);
    }

    public void SetTargetPosition(Vector3 pos)
    {
        Debug.Log(pos);
        targetPosition = pos;
    }
}
