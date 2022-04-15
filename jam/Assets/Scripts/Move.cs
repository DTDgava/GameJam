using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Move : MonoBehaviour
{
    private Rigidbody rb;
    public float turnSpeed = 1000f;
    public float accellerateSpeed = 1000f;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        float h = Input.GetAxis("Horizontal");
        float v = Input.GetAxis("Vertical");

        rb.AddTorque(0f, h * turnSpeed * Time.deltaTime, 0f);
        rb.AddForce(transform.forward * accellerateSpeed * Time.deltaTime);
    }
}
