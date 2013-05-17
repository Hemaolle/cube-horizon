/****************************************************
 * Movement script for the Kaamos game.
 * 
 * Author: Mikko Jakonen, Oskari Leppäaho
 * Version: 0.5
 ****************************************************/
using UnityEngine;
using System.Collections;
[RequireComponent(typeof(Rigidbody))]

public class MeshMovement : MonoBehaviour 
{
     //jumping:
    public float jumpForce=40;

    //moving:
    public float acceleration=3;
    public float maxMoveSpeed=15;

    //gravity:
    public float gravity=40;
    public float terminalVelocity=100;
    
    
    public int goingForward = 1;
   
    //private Vector3 v = Vector3.zero;
    private bool grounded;
    private float distToGround;
    private float horizDist;
    private Rigidbody body;
    private bool jumping;
    private float jumpTime;
    private float groundHitTime;
    private bool falling;
    
    private Animator anim;
    
    
    void Start ()
    {
        body = GetComponent<Rigidbody>();
        anim = GetComponent<Animator>();
        distToGround = collider.bounds.extents.y;
        horizDist = collider.bounds.extents.z;
        groundHitTime = Time.timeSinceLevelLoad;
    }

    void Update () 
    {
        HandleWalk();//

        HandleJump();

        body.AddForce(transform.TransformDirection(Vector3.down) * gravity * body.mass);
        float v = transform.InverseTransformDirection(body.velocity).z;
        if(transform.InverseTransformDirection(body.velocity).z < 0 && Input.GetAxis("Horizontal") * goingForward < 0) {
            goingForward = goingForward * -1;
            transform.Rotate(0,180,0);
        }
        
        Mathf.Abs(v);
        
        anim.SetFloat("Speed", v);
        if (jumping == true && isGrounded() && Time.timeSinceLevelLoad - jumpTime > 0.5) {
            jumping = false;
            anim.SetBool("Jump",false);
            groundHitTime = Time.timeSinceLevelLoad;
        }
        //Debug.Log(!jumping + " " + !isGrounded() + " " + !falling + " " + (Time.timeSinceLevelLoad - groundHitTime > 0.1));
        if (!jumping && !isGrounded() && !falling && Time.timeSinceLevelLoad - groundHitTime > 0.1)
        {
            anim.SetBool("Falling", true);
            falling = true;
            //Debug.Log ("Falling");
            
        }
        if (falling == true && isGrounded())
        {
            anim.SetBool("Falling",false);
            falling = false;
            groundHitTime = Time.timeSinceLevelLoad;
        }
        
            
    }
    
    //This was supposed to fix sticking to objects
    /*void FixedUpdate()
    {
        RaycastHit hit;
        Vector3 horizontalMove = body.velocity;
        horizontalMove.y = 0;
        horizontalMove.Normalize();
        float distance =  horizontalMove.magnitude * Time.fixedDeltaTime; 
        if(body.SweepTest(transform.forward, out hit, collider.bounds.extents.x))
        {
            Debug.Log ("fixing update");
            body.velocity = new Vector3(0, body.velocity.y, 0);	
        }	
    }*/


    /**********************************************************************
     * Walk: */

    void HandleWalk()
    {
        Vector3 force = transform.TransformDirection(Vector3.forward) * Input.GetAxis("Horizontal") * acceleration * goingForward;
        
        if (Vector3.Project(body.velocity, transform.TransformDirection(Vector3.forward)).magnitude < maxMoveSpeed
            || Vector3.Angle(Vector3.Project(body.velocity, transform.TransformDirection(Vector3.forward)), force) > 170)
        {
            //no force forward if we are blocked that way:
            if (!(isBlocked() && Vector3.Angle(transform.TransformDirection(Vector3.forward), force) == 0)) 
                body.AddForce(force, ForceMode.Impulse);
        }

    }

    bool isBlocked()
    {
        int layermask = 1; //Only check default layer
        return Physics.Raycast(transform.position, transform.TransformDirection(Vector3.forward), horizDist, layermask);
    }


    /*********************************************************
     * JUMP: */

    void HandleJump()
    {       
        if (isGrounded())
        {
            if (Input.GetButtonDown("Jump")) 
            {
                anim.SetBool("Jump", true);
                jumping = true;				
                jumpTime = Time.timeSinceLevelLoad;
                body.velocity += transform.TransformDirection(Vector3.up) * jumpForce;
            }
        }
    }

    private bool isGrounded()
    {			
        int layermask = 1; //Only check default layer
        return Physics.Raycast(transform.position, transform.TransformDirection(Vector3.down), distToGround, layermask);
    }


    // Stop movement and clear all forces.
    public void FullStop()
    {
        body.Sleep();
    }
}
