#pragma strict
/**
 * A static class for keeping track of world gravity.
 * 
 * Author: Mikko Jakonen
 * Version 0.1
 */
static var gravity : Vector3 = Vector3.down * 9.81;

static function change(transform:Transform) {
	gravity = transform.TransformDirection(Vector3.down * 9.81);
}