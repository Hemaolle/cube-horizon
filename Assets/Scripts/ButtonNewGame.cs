using UnityEngine;
using System.Collections;

public class ButtonNewGame : Button {
		
	void Update() {
		if (hover) {
			
		}
	}
	
	IEnumerator OnMouseDown() {
		Globals.currentMinerals = 0;
		Globals.maxMinerals = 0;
		
		SceneDirection director = GetComponent<SceneDirection>();
		director.FadeToBlack(1.0f);
		
		yield return new WaitForSeconds(1.0f);
		
		Application.LoadLevel("Kentta0Assy");
	}
	
}
