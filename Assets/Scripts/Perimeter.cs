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
    public GameObject respawnAt;

    void OnTriggerExit(Collider other)
    {   
        if (other.tag == "Player")
        {
            other.gameObject.transform.position = respawnAt.transform.position;
            other.gameObject.transform.rotation = respawnAt.transform.rotation;
            other.GetComponent<Rigidbody>().velocity = Vector3.zero;
        }
    }
}
