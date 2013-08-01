using UnityEngine;
using System.Collections;

public class AlienFlee : MonoBehaviour {
	
	Rigidbody body;
	
	void Start() {
		body = transform.parent.FindChild("AlienBody").GetComponent<Rigidbody>();			
	}
	
	void OnTriggerEnter(Collider other) {
		if(other.tag == "Player") {
			
			alienMoving = true;
		}
	
	}
	
	bool alienMoving = false;
	
	void Update() {
		if(!alienMoving) return;
		body.AddForce(Vector3.left * 20);
	}
}
