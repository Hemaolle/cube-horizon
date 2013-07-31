/************************************
 * Simple script to play a particle
 * effect.
 ************************************/ 

using UnityEngine;
using System.Collections;

public class ParticleTrigger : MonoBehaviour {

	void PlayParticles() {
		GetComponent<ParticleSystem>().Play();		
	}
}
