using UnityEngine;
using System.Collections;

public class ButtonRestart : Button {

	void OnMouseDown() {
		Application.LoadLevel(Application.loadedLevel);		
	}
}
