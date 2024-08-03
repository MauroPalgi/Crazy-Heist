using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarController : MonoBehaviour
{
    // Start is called before the first frame update


    [SerializeField]
    public float fwdSpeed;
    [SerializeField]
    public float turnSpeed;
    [SerializeField]
    public float revSpeed;

    private float moveInput;
    private float turnInput;

    public Rigidbody sphereRB;
    void Start()
    {
        sphereRB.transform.parent = null;
    }

    // Update is called once per frame
    void Update()
    {

        moveInput = Input.GetAxisRaw("Vertical");
        turnInput = Input.GetAxisRaw("Horizontal");


        moveInput *= moveInput > 0 ? fwdSpeed : revSpeed;


        transform.position = sphereRB.position;
        float newRotation = turnInput * turnSpeed * Time.deltaTime * Input.GetAxisRaw("Vertical");
        transform.Rotate(0, newRotation, 0, Space.World);
    }

    private void FixedUpdate()
    {
        sphereRB.AddForce(transform.forward * moveInput, ForceMode.Acceleration);
    }
}
