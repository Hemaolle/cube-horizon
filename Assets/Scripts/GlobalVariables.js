#pragma strict
/**
 * A static class for keeping track of world gravity.
 * 
 * Authors: Mikko Jakonen, Oskari Leppäaho
 * Version 0.2
 */
static var gravity : Vector3 = Vector3.down * 9.81;

static function change(transform:Transform) {
	gravity = transform.TransformDirection(Vector3.down * 9.81);
}