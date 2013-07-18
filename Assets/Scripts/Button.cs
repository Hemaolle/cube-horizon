using UnityEngine;
using System.Collections;

public class Button : MonoBehaviour {
	protected bool hover = false;
	
	void OnMouseEnter() {
		hover = true;
		GUITexture texture = GetComponent<GUITexture>();
		Color c = texture.color;
		c.a = 0.5f;
		texture.color = c;
	}
	
	void OnMouseExit() {
		hover = false;
		GUITexture texture = GetComponent<GUITexture>();
		Color c = texture.color;
		c.a = 0.25f;
		texture.color = c;
	}
}
