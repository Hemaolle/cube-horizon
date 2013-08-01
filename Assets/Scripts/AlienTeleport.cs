/***********************************************
 * Script for controlling the teleporting alien
 * in level 7.
 * 
 * Version: 0.5
 * Author: Mikko Jakonen
 ***********************************************/
using UnityEngine;
using System.Collections;

public class AlienTeleport : MonoBehaviour {

	void OnTriggerEnter(Collider other) {
		if (other.gameObject.tag == "Player") {
			
			//teleport away:
			transform.root.FindChild("AlienTeleportEffect").animation.Play();			
			
			//next alien teleport in:
			int nextAlienNum = int.Parse(transform.root.name.Substring(5)) + 1;
			GameObject nextAlien = GameObject.Find("Alien" + nextAlienNum);
			nextAlien.transform.FindChild("AlienTeleportEffectReverse").animation.Play();
		
			//set checkpoint: 
			GameObject respawn = new GameObject("Respawn");
			GameObject camFollow = GameObject.Find("CamFollow");
			
			respawn.transform.position = transform.position;
			respawn.transform.rotation = ChangeToNext90Degrees(camFollow.transform.rotation);
			Globals.respawnAt = respawn;
			
			//disable trigger:
			collider.enabled = false;
		}
	}
	
	private Quaternion ChangeToNext90Degrees(Quaternion rot) {
		Vector3 eulerAngles = rot.eulerAngles;
		
		eulerAngles.x = eulerAngles.x - eulerAngles.x % 90;
		eulerAngles.y = eulerAngles.y - eulerAngles.y % 90;
		eulerAngles.z = eulerAngles.z - eulerAngles.z % 90;
		
		return Quaternion.Euler(eulerAngles);
	}
}
