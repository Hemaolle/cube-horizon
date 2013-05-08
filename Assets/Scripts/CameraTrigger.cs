/**************************************************
 * Used for trigger that detects if something comes
 * between the player and the camera.
 * 
 * Version: 0.5
 *************************************************/
using UnityEngine;
using System.Collections;

public class CameraTrigger : MonoBehaviour {

    void OnTriggerEnter(Collider other)
    {
		if (other.renderer != null) {			
	        Color color = other.gameObject.renderer.material.color;
	        color.a = 0.5f;
	        other.gameObject.renderer.material.color = color;
		}
    }

    void OnTriggerExit(Collider other)
    {
		if (other.renderer != null) {		
	        Color color = other.gameObject.renderer.material.color;
	        color.a = 1f;
	        other.gameObject.renderer.material.color = color;
		}
    }
}
