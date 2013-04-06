using UnityEngine;
using System.Collections;

public class MineralControl : MonoBehaviour {

	// Use this for initialization
	void Start () {
		Globals.maxMinerals++;
		Globals.currentMinerals++;
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	
	public void OnTriggerEnter(Collider collider)
	{
		if (collider.gameObject.tag.Equals("Player"))
		{
			Destroy(gameObject);
			Globals.currentMinerals--;	
		}
	}
}
