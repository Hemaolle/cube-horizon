/*********************************
 * Gravity flipping camera script.
 *
 * Authors: Mikko Jakonen, Oskari Leppäaho
 * Version: 0.2
 *********************************/
#pragma strict

//how long it takes for the camera to do a 90-degree rotation:
public var rotateSpeed : float = 0.5;
public var rotateThreshold : float = 0.01;

//where to rotate:
private var rotateTo : float = 0;
private var rotating : boolean = false;

//character's transform component
public var characterTrasform : Transform;

function Update () {
	//var rotate = Input.GetAxis("Rotate");
	
	if ( Input.GetButtonDown("RotateR") ) {
		rotate(90);	
	}
	else if ( Input.GetButtonDown("RotateL") ) {
		rotate(-90);
	}
	
	smoothRotate(rotateTo);
}

/**
 * Set the camera as rotating to relativeAngle, an angle relative
 * to the current angle.
 */
function rotate(relativeAngle:float) {
	if(!rotating) rotateTo = transform.eulerAngles.z + relativeAngle;
	else rotateTo += relativeAngle;
	rotating = true;
}

/**
 * Use an easing function to rotate the camera a little bit 
 * towards the angle we want.
 * Also rotate character.
 */
function smoothRotate(angle:float) {
	if(!rotating) return;
	
	var start = transform.eulerAngles.z;
	var end = angle;
	
	var t:float = 0.0;
	
	while (t < rotateSpeed) {
		var factor = easeInOutQuad(t, 0, 1, rotateSpeed);
		
		transform.eulerAngles.z = start + (end - start) * factor;
		characterTrasform.eulerAngles.z = start + (end - start) * factor;
		
		t += Time.deltaTime;
		print(t);
		yield;
	}
	
	rotating = false;
	flip();
}

/**
 * Once rotation is done, flips world gravity.
 */
function flip() {
	GlobalVariables.change(transform);
}

/**
 * Easing function for smoother rotation.
 */
function easeInOutQuad(t:float, b:float, c:float, d:float) {
	t /= d/2;	
	if (t < 1) return c/2*t*t + b;
	t--;
	return -c/2 * (t*(t-2) - 1) + b;
}