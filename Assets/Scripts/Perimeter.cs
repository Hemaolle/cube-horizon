/*****************************************************
 * Saves the player from falling to far into the void.
 * Player is returned to the gameobject indicated by
 * the property 'respawnAt'.
 *
 * Author: Mikko Jakonen
 * Version: 0.1
 *****************************************************/
using UnityEngine;
using System.Collections;

class Perimeter : MonoBehaviour 
{
    private GameObject respawnAt;
    
    void Start()
    {
        respawnAt = GameObject.Find("Start");	
    }

    void OnTriggerExit(Collider other)
    {   
       //If some child of character collides we still want the whole character.
        GameObject rootObject = other.transform.root.gameObject;
        
        if (rootObject.tag == "Player")
        {
            rootObject.transform.position = respawnAt.transform.position;
            rootObject.transform.rotation = respawnAt.transform.rotation;
            rootObject.GetComponent<Rigidbody>().velocity = Vector3.zero;
        }
    }
}
