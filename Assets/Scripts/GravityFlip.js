/*********************************
 * Gravity flipping camera script.
 *
 * Authors: Mikko Jakonen, Oskari Leppäaho
 * Version: 0.3 
 *********************************/
#pragma strict

//how long it takes for the camera to do a 90-degree rotation:
public var rotateSpeed : float = 0.5;
public var rotateThreshold : float = 0.01;

//where to rotate:
private var rotateTo : float = 0;
private var rotating : boolean = false;

//These store the eulerAngles that represent rotation in character's own coordinates
private var rotationVariablez : float;
private var rotationVariabley : float;

function Start () {
	rotationVariablez = transform.eulerAngles.z;
	rotationVariabley = transform.eulerAngles.y;
}

function Update () {
	//RotateR/RotateL means rotation that changes gravity direction (around
	//character's z-axis)
	if ( Input.GetButtonDown("RotateR") ) {
		rotate(90, rotationVariablez);
		smoothRotate(rotateTo,rotationVariablez,true);	
	}
	else if ( Input.GetButtonDown("RotateL") ) {
		rotate(-90, rotationVariablez);
		smoothRotate(rotateTo,rotationVariablez,true);
	}
	
	//RotateR2/RotateL2 means rotation that doesn't change gravity direction. (around
	//character's y-axis)
	if ( Input.GetButtonDown("RotateR2") ) {
		rotate(-90, rotationVariabley);
		smoothRotate(rotateTo,rotationVariabley,false);
	}
	else if ( Input.GetButtonDown("RotateL2") ) {
		rotate(90, rotationVariabley);
		smoothRotate(rotateTo,rotationVariabley,false);
	}
	
	
	//Debug.Log(rotating);
}

/**
 * Set the camera as rotating to relativeAngle, an angle relative
 * to the current angle.
 */
function rotate(relativeAngle:float, rotationVariable:float) {
	if(!rotating) rotateTo = rotationVariable + relativeAngle;
	//Disabled multiple rotations at once since it was causing some glitches.
	//else rotateTo += relativeAngle;
	rotating = true;
}

/**
 * Use an easing function to rotate the camera a little bit 
 * towards the angle we want. If rotateTypeZ we are rotating around Z-axis,
 * otherwise around Y-axis.
 */
function smoothRotate(angle:float, rotationVariable:float, rotateTypeZ:boolean) {
	if(!rotating) return;
	
	var start = rotationVariable;
	var previousAngle = start;
	var end = angle;
	
	var t:float = 0.0;
	
	while (t < rotateSpeed) {
		var factor = easeInOutQuad(t, 0, 1, rotateSpeed);
		
		if(rotateTypeZ)
		{
			transform.Rotate(0,0,(start + (end - start) * factor) - previousAngle);
			previousAngle = start + (end - start) * factor;	
			rotationVariablez = start + (end - start) * factor;
		}
		else
		{
			transform.Rotate(0,(start + (end - start) * factor) - previousAngle,0);
			previousAngle = start + (end - start) * factor;	
			rotationVariabley = start + (end - start) * factor;		
		}
		t += Time.deltaTime;
		//print(t);
		yield;
	}
	
	rotating = false;
	flip();
}

/**
 * Once rotation is done, flips world gravity.
 */
function flip() {
	GlobalVariables.changeGravityDirection(transform);
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