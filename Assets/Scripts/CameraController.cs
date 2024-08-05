using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{

    public Transform target;
    private Rigidbody motorSphereRB;
    public Vector3 Offset;
    public float speed;
    // Start is called before the first frame update
    void Start()
    {
        motorSphereRB = target.GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void LateUpdate()
    {
        Vector3 playerForward = (motorSphereRB.velocity + target.transform.forward).normalized;
        transform.position = Vector3.Lerp(transform.position,
            target.position + target.transform.TransformVector(Offset)
            + playerForward * (-5f),
            speed * Time.deltaTime);
        transform.LookAt(target);
    }

}
