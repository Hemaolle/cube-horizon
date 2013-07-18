using UnityEngine;
using System.Collections;

public class ButtonQuit : Button {

	void OnMouseDown() {
		Application.LoadLevel("MainMenu");	
	}
}
