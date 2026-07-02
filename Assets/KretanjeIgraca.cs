using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KretanjeIgraca : MonoBehaviour
{
    private float horizontalInput;
    private float verticalInput;
    private bool isGrounded;
    private bool spacePressed;
    private Rigidbody rigidbodyComponent;

    void Start()
    {
        rigidbodyComponent = GetComponent<Rigidbody>();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            spacePressed = true;
        }
        horizontalInput = Input.GetAxis("Horizontal");
        verticalInput = Input.GetAxis("Vertical");
    }

    private void FixedUpdate()
    {
        if (horizontalInput != 0f)
            rigidbodyComponent.linearVelocity = new Vector3(horizontalInput * 2, rigidbodyComponent.linearVelocity.y, rigidbodyComponent.linearVelocity.z);

        if (verticalInput != 0f)
            rigidbodyComponent.linearVelocity = new Vector3(rigidbodyComponent.linearVelocity.x, rigidbodyComponent.linearVelocity.y, verticalInput * 2);

        if (!isGrounded)
        {
            return;
        }

        if (spacePressed)
        {
            rigidbodyComponent.AddForce(Vector3.up * 10, ForceMode.VelocityChange);
            spacePressed = false;
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        isGrounded = true;
    }

    private void OnCollisionExit(Collision collision)
    {
        isGrounded = false;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.layer == 6)
        {
            Destroy(other.gameObject);
        }
    }
}