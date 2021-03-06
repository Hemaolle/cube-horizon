/****************************************************
 * Movement script for the Nuotio game
 * 
 * Author: Mikko Jakonen, Oskari Lepp�aho
 * Version: 0.4
 ****************************************************/
using UnityEngine;
using System.Collections;
[RequireComponent(typeof(Rigidbody))]

public class NuotioMovement : MonoBehaviour 
{
    //jumping:
    public float jumpForce=40;

    //moving:
    public float acceleration=3;
    public float maxMoveSpeed=15;

    //gravity:
    public float gravity=40;
    public float terminalVelocity=100;

   
    //private Vector3 v = Vector3.zero;
    private bool grounded;
    private float distToGround;
    private Rigidbody body;

    void Start ()
    {
        body = GetComponent<Rigidbody>();
        distToGround = collider.bounds.extents.y;
    }

    void Update () 
    {
        HandleWalk();

        HandleJump();

        body.AddForce(transform.TransformDirection(Vector3.down) * gravity * body.mass);
    }


    /**********************************************************************
     * Walk: */

    void HandleWalk()
    {
        Vector3 force = transform.TransformDirection(Vector3.right) * Input.GetAxis("Horizontal") * acceleration;
        
        if (Vector3.Project(body.velocity, transform.TransformDirection(Vector3.right)).magnitude < maxMoveSpeed
            || Vector3.Angle(Vector3.Project(body.velocity, transform.TransformDirection(Vector3.right)), force) > 170)
        {
            body.AddForce(force, ForceMode.Impulse);
        }

    }



    /*********************************************************
     * JUMP: */

    void HandleJump()
    {       
        if (isGrounded())
        {
            if (Input.GetButtonDown("Jump")) 
            {
                body.velocity += transform.TransformDirection(Vector3.up) * jumpForce;
            }
        }
    }

    private bool isGrounded()
    {
        int layermask = 1; //Only check default layer
        return Physics.Raycast(transform.position, transform.TransformDirection(Vector3.down), distToGround + 0.1f, layermask);
    }


    // Stop movement and clear all forces.
    public void FullStop()
    {
        body.Sleep();
    }
}
