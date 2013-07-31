/*****************************************************
 * Saves the player from falling to far into the void.
 * Player is returned to the gameobject indicated by
 * the property 'respawnAt'.
 *
 * Author: Mikko Jakonen
 * Version: 0.2
 *****************************************************/
using UnityEngine;
using System.Collections;

class Perimeter : MonoBehaviour 
{
    private GameObject respawnAt;
    private GameObject camFollow;
	private GameObject character;
	
    void Start()
    {
        Globals.respawnAt = GameObject.Find("Start");
		camFollow = GameObject.Find("CamFollow");
		character = GameObject.Find("AnimatedCharacter");
    }

    void OnTriggerExit(Collider other)
    {   
        //If some child of character collides we still want the whole character.
        //GameObject rootObject = other.transform.root.gameObject;
		GameObject rootObject = other.gameObject;
		
        if (rootObject.tag == "Player")
        {
			camFollow.GetComponent<CameraWorldControl>().CancelRotate();
			
            rootObject.transform.position = Globals.respawnAt.transform.position;
            rootObject.transform.rotation = Globals.respawnAt.transform.rotation;
			camFollow.transform.rotation = Globals.respawnAt.transform.rotation;
			MeshMovement movement = character.GetComponent<MeshMovement>();
			movement.goingForward = 1;
			rootObject.GetComponent<Rigidbody>().velocity = Vector3.zero;
        }
    }
}
