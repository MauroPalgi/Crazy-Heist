using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarController : MonoBehaviour
{

    [SerializeField]    // Start is called before the first frame update
    public float fwdSpeed;
    [SerializeField]    // Start is called before the first frame update
    public float turnSpeed;
    [SerializeField]    // Start is called before the first frame update
    public float revSpeed;
    public float airDrag;
    public float groundDrag;
    public LayerMask groundLayer;
    private float moveInput;
    private float turnInput;
    private bool isCarGrounded;

    public Rigidbody sphereRB;

    public bool isAiPlayer = false;
    void Start()
    {
        sphereRB.transform.parent = null;
    }


    public void SetInput(float externalMoveInput, float externalTurnInput)
    {

        if (isAiPlayer)
        {
            moveInput = externalMoveInput;
            turnInput = externalTurnInput;


            moveInput *= moveInput > 0 ? fwdSpeed : revSpeed;


            transform.position = sphereRB.position;
            float newRotation = turnInput * turnSpeed * Time.deltaTime * externalMoveInput;
            transform.Rotate(0, newRotation, 0, Space.World);

            RaycastHit hit;
            isCarGrounded = Physics.Raycast(transform.position, -transform.up, out hit, 1f, groundLayer);
            transform.rotation = Quaternion.FromToRotation(transform.up, hit.normal) * transform.rotation;
            if (isCarGrounded)
            {
                sphereRB.drag = groundDrag;
            }
            else
            {

                sphereRB.drag = airDrag;

            }
        }

    }

    // Update is called once per frame
    void Update()
    {

        if (!isAiPlayer)
        {
            moveInput = Input.GetAxisRaw("Vertical");
            turnInput = Input.GetAxisRaw("Horizontal");


            moveInput *= moveInput > 0 ? fwdSpeed : revSpeed;


            transform.position = sphereRB.position;
            float newRotation = turnInput * turnSpeed * Time.deltaTime * Input.GetAxisRaw("Vertical");
            transform.Rotate(0, newRotation, 0, Space.World);

            RaycastHit hit;
            isCarGrounded = Physics.Raycast(transform.position, -transform.up, out hit, 1f, groundLayer);
            transform.rotation = Quaternion.FromToRotation(transform.up, hit.normal) * transform.rotation;
            if (isCarGrounded)
            {
                sphereRB.drag = groundDrag;
            }
            else
            {

                sphereRB.drag = airDrag;

            }
        }

    }

    private void FixedUpdate()
    {

        if (isCarGrounded)
        {
            sphereRB.AddForce(transform.forward * moveInput, ForceMode.Acceleration);
        }
        else
        {
            sphereRB.AddForce(transform.up * -9.8f);

        }
    }
}
