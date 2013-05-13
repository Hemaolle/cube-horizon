/*****************************************************************
 * Script for turning off lights when nearby mineral is collected.
 * 
 * Author: Mikko Jakonen
 * Version: 0.6
 *****************************************************************/
using UnityEngine;
using System.Collections;

public class MineralLight : MonoBehaviour {
    
    public float flickerTime = 3.0f;
    public float flickerSpeed = 70.0f;
    public float flickerDelay = 1.0f;
    
    private GameObject mineral;
    private bool lightsOn = true;
    private Light[] lights;
    
    void OnTriggerEnter(Collider other) 
    {
        Debug.Log(other.gameObject.name);
        if (other.gameObject.name == "Mineral") 
        {
            mineral = other.gameObject;
        }
    }
    
    void Update() 
    {
        if (lightsOn && mineral == null) StartCoroutine(Flicker());
    }
    
    /** Turns off all lightbulbs on this object. */
    void LightsOut() 
    {	
        foreach(Light l in GetComponentsInChildren<Light>()) 
        {
            //disable light:
            l.enabled = false;

            //color material black:
            Color c = l.gameObject.transform.parent.gameObject.renderer.material.color;
            c.r = 0.1f; c.g = 0.1f; c.b = 0.1f;
            l.gameObject.transform.parent.gameObject.renderer.material.color = c;
        }
        lightsOn = false;
    }
    
    /** Flickers lightbulbs before turning off. */
    IEnumerator Flicker() 
    {
        yield return new WaitForSeconds(flickerDelay);
        float t = 0.0f;
        Light[] lights = GetComponentsInChildren<Light>();

        while (t < flickerTime) 
        {
            foreach (Light l in lights) 
            {                
                //randomize intensity of light:
                l.intensity = Random.Range(0, 8.0f);
                Color c = l.gameObject.transform.parent.renderer.material.color;
                
                //randomize "lightness" of material color on the lightbulb:
                float newColor = Random.Range(0, 1.0f);
                c.r = newColor; c.g = newColor; c.b = newColor;
                l.gameObject.transform.parent.renderer.material.color = c;
            }
            
            t += Time.deltaTime;

            yield return new WaitForSeconds(1/flickerSpeed);
        }
        
        LightsOut();
    }
}
    