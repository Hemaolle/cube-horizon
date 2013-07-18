using UnityEngine;
using System.Collections;

public class ButtonReturn : Button {

	void OnMouseDown() {
		PauseMenu menu = gameObject.transform.parent.parent.gameObject.GetComponent<PauseMenu>();
		menu.Hide();
	}
}
