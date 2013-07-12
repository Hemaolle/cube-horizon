/*********************************************************
 * Script for controlling scene directing effects on the
 * main camera.
 * 
 * Author: Mikko Jakonen
 * Version: 0.1
 *********************************************************/
using UnityEngine;
using System.Collections;

public class SceneDirection : MonoBehaviour {
    
    public Texture2D overlay;
    
    private bool fading = false;
    private float fadeOpacity = 1.0f;
    
    void Start() 
    {
        FadeFromBlack(2.0f);
    }
    
    void OnGUI() 
    {		
        Color c = GUI.color;
        c.a = fadeOpacity;
        GUI.color = c;
        GUI.DrawTexture(new Rect(0, 0, Screen.width, Screen.height), overlay);
    }
    
    public void FadeToBlack(float durationSeconds) 
    {
        if(!fading) StartCoroutine(DoFadeOut(durationSeconds));
    }
    
    public void FadeFromBlack(float durationSeconds)
    {
        if(!fading) StartCoroutine(DoFadeIn(durationSeconds));
    }
    
    //fade to black
    IEnumerator DoFadeOut(float durationSeconds) 
    {
        fading = true;
        float t = 0.0f;
        float o;
        while (t < durationSeconds) 
        {			
            o = (t / durationSeconds) * 1.0f;
            fadeOpacity = o;
            
            t += Time.deltaTime;
            yield return null;
        }
        
        fading = false;
    }
    
    //fade from black
    IEnumerator DoFadeIn(float durationSeconds) 
    {
        fading = true;
        float t = durationSeconds;
        float o;
        while (t > 0.0f) 
        {			
            o = (t / durationSeconds) * 1.0f;
            fadeOpacity = o;
            
            t -= Time.deltaTime;
            yield return null;
        }
        
        fading = false;
    }
}
