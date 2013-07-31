using UnityEngine;
using System.Collections;

public class AlienEffects : MonoBehaviour {

	void PlayParticles() {
		GetComponent<ParticleSystem>().Play();		
	}
	
	void Disappear() {
		transform.parent.FindChild("AlienBody").gameObject.SetActive(false);
		GetComponent<ParticleSystem>().Stop();
	}
	
	void Appear() {
		transform.parent.FindChild("AlienBody").gameObject.SetActive(false);
		GetComponent<ParticleSystem>().Stop();
	}
}
