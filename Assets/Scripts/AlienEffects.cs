using UnityEngine;
using System.Collections;

public class AlienEffects : MonoBehaviour {

	void PlayParticles() {
		ParticleSystem part = GetComponent<ParticleSystem>();
		if (part != null) part.Play();		
	}
	
	void Disappear() {
		transform.root.FindChild("AlienBody").gameObject.SetActive(false);
		GetComponent<ParticleSystem>().Stop();
	}
	
	void Appear() {
		transform.root.FindChild("AlienBody").gameObject.SetActive(true);
		GetComponent<ParticleSystem>().Stop();
	}
}
