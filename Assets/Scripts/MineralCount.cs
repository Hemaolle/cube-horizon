using UnityEngine;
using System.Collections;

public class MineralCount : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		guiText.text = (Globals.currentMinerals.ToString() + "/" + Globals.maxMinerals.ToString());
	}
}
