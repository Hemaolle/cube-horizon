/****************************************************
 * When player enters trigger a sound will be played
 * and a text displayed. Either one can be turned off.
 * 
 * Public properties:
 * Text to Display: Text that will be displayed.
 * Display Duration: Text will be shown for this many seconds.
 * Pause Between Displays: If Display Only Once is off the trigger
 * 						   will activate again this many seconds
 * 						   after the text disappears.
 * Display Only Once: If enabled, the trigger will be permanently
 * 					  disabled after it has triggered once.
 * Display Text: If enabled, Text to Display will be shown.
 * Play Audio: If audio file is attached to audio source component
 * 				in the game object and this setting is enabled, an
 * 				audio file will be played.
 * 
 * Author: Oskari Leppäaho
 * Version: 0.1
 ****************************************************/
using UnityEngine;
using System.Collections;

public class TextAndOrAudioTrigger : MonoBehaviour {
	
	public string textToDisplay = "Text";
	public float displayDuration = 4;
	public float pauseBetweenDisplays = 10;
	public bool displayOnlyOnce = false;
	public bool displayText = true;
	public bool playAudio = true;
	public static string latestText;
	
	private GameObject guiTextObject;
	private GameObject speachAudioSource;
	
	// Use this for initialization
	void Start () {
		guiTextObject = GameObject.Find("TextDisplay");
		speachAudioSource = GameObject.Find ("SpeachAudioSource");
		
	}
	
	IEnumerator OnTriggerEnter(Collider collider)
	{
		latestText = textToDisplay;
		
		gameObject.collider.enabled = false;
		if(playAudio && audio.clip != null)
			speachAudioSource.audio.clip = audio.clip;
			speachAudioSource.audio.Play();
				
		if (displayText)
		{
			guiTextObject.guiText.text = textToDisplay;
			guiTextObject.guiText.enabled = true;
		}
		
		yield return new WaitForSeconds(displayDuration);
		
		if(displayText && latestText == textToDisplay)			
		{
			guiTextObject.guiText.enabled = false;			
			//Debug.Log("Hiding text: " + textToDisplay);	
		}
				
		yield return new WaitForSeconds(pauseBetweenDisplays);
		
		if (!displayOnlyOnce)
			gameObject.collider.enabled = true;
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
