using UnityEngine;
using System.Collections;

public class CreditScroll : MonoBehaviour {
	
	public float scrollSpeed = 5;
	
	private bool scrolling = false;
	private GUIText text;
	
	void Start() {
		text = GetComponent<GUIText>();
		Vector2 of = text.pixelOffset;
		of.y = -Screen.currentResolution.height;
		text.pixelOffset = of;
		Debug.Log(of.y);
	}
	
	public void Play(float delay) {
		StartCoroutine(DoPlay(delay));
	}
	
	IEnumerator DoPlay(float delay) {
		yield return new WaitForSeconds(delay);
		
		scrolling = true;
		audio.Play();
	}
	
	// Update is called once per frame
	void Update () {
		if (scrolling) {
			Vector2 of = text.pixelOffset;
			of.y += scrollSpeed * Time.deltaTime;
			text.pixelOffset = of;
		}
	}
}
