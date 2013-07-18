using UnityEngine;
using System.Collections;

public class ButtonNewGame : Button {
		
	void Update() {
		if (hover) {
			
		}
	}
	
	IEnumerator OnMouseDown() {
		SceneDirection director = GetComponent<SceneDirection>();
		director.FadeToBlack(1.0f);
		
		yield return new WaitForSeconds(1.0f);
		
		Application.LoadLevel("Kentta0Valmis");
	}
	
}
