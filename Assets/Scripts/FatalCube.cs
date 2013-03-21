/****************************************************
 * When player touches a fatal cube he freezes in place
 * for a while and a sound is played. After that player
 * transfers to Start location.
 * 
 * Author: Oskari Leppäaho
 * Version: 0.1
 ****************************************************/
using UnityEngine;
using System.Collections;

public class FatalCube : MonoBehaviour {
	
	private GameObject respawnAt;
	private GameObject fatalAudio;
	
	void Start()
	{
		respawnAt = GameObject.Find("Start");	
		fatalAudio = GameObject.Find("FatalAudioSource");	
	}
	
	IEnumerator OnCollisionEnter(Collision collision)
	{
		//If some child of character collides we still want the whole character.
		GameObject rootObject = collision.collider.transform.root.gameObject;
		
		if (rootObject.tag == "Player")
        {
			rootObject.rigidbody.isKinematic = true;
			fatalAudio.audio.Play();
			
			yield return new WaitForSeconds(2);
			
			rootObject.rigidbody.isKinematic = false;
			
            rootObject.transform.position = respawnAt.transform.position;
            rootObject.transform.rotation = respawnAt.transform.rotation;
            rootObject.GetComponent<Rigidbody>().velocity = Vector3.zero;
        }
		
		
	}
}
