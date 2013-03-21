/****************************************************
 * When player enters trigger a sound will be played
 * and a text displayed. Either one can be turned off.
 * 
 * Author: Oskari Leppäaho
 * Version: 0.1
 ****************************************************/
using UnityEngine;
using System.Collections;

public class TextAndOrAudioTrigger : MonoBehaviour {
	
	public string textToDisplay = "Text";
	public float displayDuration = 4;
	public bool displayOnlyOnce = false;
	public bool displayText = true;
	public bool playAudio = true;
	
	private GameObject guiTextObject;
	
	// Use this for initialization
	void Start () {
		guiTextObject = GameObject.Find("GUI Text");
	}
	
	IEnumerator OnTriggerEnter(Collider collider)
	{
		gameObject.collider.enabled = false;
		if(playAudio && audio.clip != null)
			audio.Play();
				
		if (displayText)
		{
			guiTextObject.guiText.text = textToDisplay;
			guiTextObject.guiText.enabled = true;
		}
		
		yield return new WaitForSeconds(displayDuration);
		
		if(displayText)			
			guiTextObject.guiText.enabled = false;
			
		if (!displayOnlyOnce)
			gameObject.collider.enabled = true;
		
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
