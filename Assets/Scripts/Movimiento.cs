using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movimiento : MonoBehaviour
{

    public float moveSpeed = 10f;
    public float rotationSpeed = 100f;
    private Rigidbody rb;

    public Animator anima;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        anima = rb.GetComponent<Animator>();
    }

    void FixedUpdate()
    {
        float horizontalInput = Input.GetAxis("Horizontal");
        float VerticalInput = Input.GetAxis("Vertical");

        Vector3 movement = transform.forward * moveSpeed * VerticalInput;
        Quaternion rotation = Quaternion.Euler(0f, horizontalInput * rotationSpeed * Time.deltaTime, 0f);

        rb.MovePosition(rb.position + movement * Time.fixedDeltaTime);
        rb.MoveRotation(rb.rotation * rotation);

        if (VerticalInput > 0 || VerticalInput < 0)
        {
            anima.SetFloat("Walk", Mathf.Abs(VerticalInput));
        }
        else
        {
            anima.SetFloat("Walk", 0);
        }
    }
}
