using UnityEngine;
using System.Collections;

public class ButtonExit : Button {
	void OnMouseDown() {
		Application.Quit();
	}
	
}
