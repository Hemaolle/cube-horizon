/** 
 * Script for moving a rigid body in a third person style.
 */
#pragma strict

private var body : Rigidbody;

//force factor to use when moving forward (or backward at the moment).
public var forwardForce : float = 2.0;
//force factor to use when turning.
public var turnForce : float = 0.01;
//maximum speed, no acceleration after this.
public var maxForwardVelocity : float = 5.0;

function Awake() {
	body = GetComponent(Rigidbody);
}

function Update () {
	var forward = Input.GetAxis("Vertical") * forwardForce;
	var turn = Input.GetAxis("Horizontal") * turnForce; 
	
	var forwardForce = transform.TransformDirection(Vector3.forward) * forward;
	
	if (body.velocity.magnitude < maxForwardVelocity)
		body.AddForce(forwardForce, ForceMode.Impulse);
	body.AddTorque(new Vector3(0, turn, 0), ForceMode.VelocityChange);
	
}

@script RequireComponent (Rigidbody)
@script AddComponentMenu ("Character/3rd Person Input Controller")