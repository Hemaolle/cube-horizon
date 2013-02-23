/************************************************
 * Main character controller for 2D platforming
 * with gravity alterations.
 *
 * Authors: Mikko Jakonen, Oskari Leppäaho
 * Version: 0.3
 *	 
 ************************************************/
#pragma strict

private var body : Rigidbody;

//force factor to use when moving forward (or backward at the moment).
public var forwardForce : float = 2.0;
//force factor to use when turning.
public var jumpForce : float = 10.0;
//maximum speed, no acceleration after this.
public var maxForwardVelocity : float = 6.0;

// for grounded checking
private var distToGround: float;

//Changed from Awake() to Start() because Unity guys told Awake without no reason could cause bugs.
function Start() {
	body = GetComponent(Rigidbody);
	// get the distance to ground
  	distToGround = collider.bounds.extents.y;
}

function Update () {
	var forward = Input.GetAxis("Horizontal");
	var jump = Input.GetButtonDown("Jump");
	
	//jumpDirection is opposite to gravity
	var jumpDirection = GlobalVariables.gravity;
	jumpDirection.Normalize();
	jumpDirection = -jumpDirection;
	
	var forwardDirection = GlobalVariables.forwardDirection;
	var force = forwardDirection * forward * forwardForce;	
	
	//By projecting body.velocity to forwardDirection, we get the component
	//of velocity that is parallel to forwardDirection.
	//We also want to apply the force if it's direction is opposite to current speed.
	if (Vector3.Project(body.velocity,forwardDirection).magnitude < maxForwardVelocity
	|| Vector3.Angle(Vector3.Project(body.velocity,forwardDirection),force) > 170 )
		body.AddForce(force, ForceMode.Impulse);
	
	if (jump && IsGrounded())
		body.AddForce(jumpDirection * jumpForce, ForceMode.Impulse);		
	
	body.AddForce(GlobalVariables.gravity * body.mass);
}

function IsGrounded(): boolean {
	var gravityDirection = GlobalVariables.gravity;
	gravityDirection.Normalize();
  	return Physics.Raycast(transform.position, gravityDirection, distToGround + 0.1);
}

@script RequireComponent (Rigidbody)
@script AddComponentMenu ("Character/2D Platform Controller")