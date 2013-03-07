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
