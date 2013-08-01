using UnityEngine;
using System.Collections;

public class YesNoQuestion : Button {
	
	public bool answerYes = false;
	
	void OnMouseDown() {
		transform.parent.gameObject.SetActive(false);
		
		string answer = "No";
		if(answerYes) answer = "Yes";
		
		//play the sound that comes with the answer:
		GameObject.Find("EndSounds").transform.FindChild(answer).gameObject.audio.Play();
		
		float creditsDelay = 7.0f;
		float slideDelay = 10.0f;
		if (answer == "No") {
			creditsDelay += 4.5f;
			slideDelay += 4.5f;
		}
		
		GameObject.Find("Main Camera").GetComponent<SceneDirection>().FadeToBlack(0.1f);
		GameObject.Find("EndCredits").GetComponent<CreditScroll>().Play(creditsDelay);
		GameObject.Find("SlideShow" + answer).GetComponent<Slideshow>().Play(slideDelay);
	}
}
