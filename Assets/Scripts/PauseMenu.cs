using UnityEngine;
using System.Collections;

public class PauseMenu : MonoBehaviour {
	
	GameObject contents;
	bool visible = false;
	
	void Start() {
		contents = transform.GetChild(0).gameObject;	
	}
	
	public void Hide() {
		contents.SetActive(false);
		visible = false;
	}
	
	public void Show() {
		contents.SetActive(true);
		visible = true;
	}
	
	void Update () {
		if(Input.GetButtonDown("PauseMenu")) {	
			
			Debug.Log("YES");
			if (!visible) Show();
			else Hide();
		}
	}
}
