/************************************************
 * Main character controller for 2D platforming
 * with gravity alterations.
 *
 * Authors: Mikko Jakonen, Oskari Leppäaho
 * Version: 0.2
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
	
	//jumpDirection is opposite to gravity
	var jumpDirection = GlobalVariables.gravity;
	jumpDirection.Normalize();
	jumpDirection = -jumpDirection;
	
	//forwardDirection is jumpDirection rotated 90 degrees clockwise
	var quat : Quaternion = Quaternion.AngleAxis(-90,Vector3.forward);
	var forwardDirection = quat * jumpDirection;
	var force = forwardDirection * forward * forwardForce;
	print(forwardDirection.ToString());
	
	
	if (Mathf.Abs(body.velocity.x) < maxForwardVelocity)
		body.AddForce(force, ForceMode.Impulse);
	
	if (jump)
		body.AddForce(jumpDirection * jumpForce, ForceMode.Impulse);
		
	
	body.AddForce(GlobalVariables.gravity);
}

@script RequireComponent (Rigidbody)
@script AddComponentMenu ("Character/2D Platform Controller")