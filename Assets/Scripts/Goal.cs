/*********************************
 * New level is loaded when player enters goal.
 *
 * Author: Oskari Leppäaho
 * Version: 0.1
 *********************************/

using UnityEngine;
using System.Collections;

public class Goal : MonoBehaviour {

	public string nextLevelName;
	
	void OnTriggerEnter(Collider other)
    {
		if (other.tag == "Player")
		{
	        Application.LoadLevel(nextLevelName);
		}
    }
}
