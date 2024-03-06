using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class itemFollower : MonoBehaviour
{
    Rigidbody rb;
    public Transform controller;
    [Range(0.0f, 360.0f)]
    public float rotateBy = 200f;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();

    }

    private void FixedUpdate()
    {
        rb.MovePosition(controller.position);
        rb.MoveRotation(controller.rotation * Quaternion.Euler(rotateBy, 0, 0));
    }

    

}
