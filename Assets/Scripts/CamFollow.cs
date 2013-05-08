using UnityEngine;
using System.Collections;

public class CamFollow : MonoBehaviour {

	public GameObject character;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		transform.position = character.transform.position;
	}
}
