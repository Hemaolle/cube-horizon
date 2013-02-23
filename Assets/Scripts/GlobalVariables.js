#pragma strict
/**
 * A static class for keeping track of global variables.
 * 
 * Authors: Mikko Jakonen, Oskari Leppäaho
 * Version 0.3
 */
 
//Gravity strength.
private static var gravityMultiplier = 50;
static var gravity : Vector3 = Vector3.down * gravityMultiplier;
static var forwardDirection : Vector3 = Vector3.right;

static function changeGravityDirection(transform:Transform) {
	gravity = transform.TransformDirection(Vector3.down * gravityMultiplier);
	forwardDirection = transform.TransformDirection(Vector3.right);
	forwardDirection.Normalize();
}

