/************************************************
 * Main character controller for 2D platforming
 * with gravity alterations.
 *
 * Author: Mikko Jakonen
 * Version: 0.1
 ************************************************/
#pragma strict

private var body : Rigidbody;

//force factor to use when moving forward (or backward at the moment).
public var forwardForce : float = 2.0;
//force factor to use when turning.
public var jumpForce : float = 10.0;
//maximum speed, no acceleration after this.
public var maxForwardVelocity : float = 6.0;

function Awake() {
	body = GetComponent(Rigidbody);
}

function Update () {
	var forward = Input.GetAxis("Horizontal");
	var jump = Input.GetButtonDown("Jump");
	var force = Vector3.right * forward * forwardForce;
	
	if (Mathf.Abs(body.velocity.x) < maxForwardVelocity)
		body.AddForce(force, ForceMode.Impulse);
	
	if (jump)
		body.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
		
	
	body.AddForce(VariableGravity.gravity);
}

@script RequireComponent (Rigidbody)
@script AddComponentMenu ("Character/2D Platform Controller")