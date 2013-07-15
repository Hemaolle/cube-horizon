/******************************************************
 * Spins object around continually.
 * 
 * Author: Mikko Jakonen
 * Version: 1.0
 *****************************************************/
using UnityEngine;
using System.Collections;

public class Spinning : MonoBehaviour {
	
	//speeds of spinning: 
	public float xRate = 0;
	public float yRate = 0;
	public float zRate = 0;
	
	// Update is called once per frame
	void Update () {
		Vector3 spin = new Vector3(xRate, yRate, zRate);
		this.transform.Rotate(spin * Time.deltaTime);
	}
}
