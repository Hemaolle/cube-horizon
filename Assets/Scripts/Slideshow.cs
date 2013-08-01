using UnityEngine;
using System.Collections;

public class Slideshow : MonoBehaviour {
	
	public Texture2D[] slides;
	public float slideDelay = 4.0f;
	
	private bool active = false;
	private GUITexture texture;
	
	// Use this for initialization
	void Start () {
		texture = GetComponent<GUITexture>();
	}
	
	public void Play(float startDelay) {
		
		StartCoroutine(DoSlideshow(startDelay));
	}
	
	bool breakCredits = false;
	
	void Update () {
		if(Input.GetButtonDown("PauseMenu")) {		
			breakCredits = true;
		}
	}
		
	IEnumerator DoSlideshow(float startDelay) {
		yield return new WaitForSeconds(startDelay);
		
		GameObject.Find("Main Camera").GetComponent<SceneDirection>().FadeFromBlack(1.1f);
		
		for(int i=0; i < slides.Length; i++) {
			if(breakCredits) break;
				
			texture.texture = slides[i];
			yield return new WaitForSeconds(slideDelay);
		}
		
		Application.LoadLevel("MainMenu");
	}
}
