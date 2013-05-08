/*****************************************************
 * Script for turning off lights when mineral is collected.
 * 
 * Author: Mikko Jakonen
 * Version: 0.5
 *****************************************************/

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
    
    //turn of all lights 
    void LightsOut() 
    {	
        foreach(Light l in GetComponentsInChildren<Light>()) 
        {
            l.enabled = false;
            //l.gameObject.GetComponent<LensFlare>().enabled = false;
			//if(l.gameObject.GetComponent<Halo>() != null) l.gameObject.GetComponent<Halo>().enabled = false;
            Color c = l.gameObject.transform.parent.gameObject.renderer.material.color;
            c.r = 0.1f; c.g = 0.1f; c.b = 0.1f;
            l.gameObject.transform.parent.gameObject.renderer.material.color = c;
        }
        lightsOn = false;
    }
    
    IEnumerator Flicker() 
    {
        yield return new WaitForSeconds(flickerDelay);
        float t = 0.0f;
        Light[] lights = GetComponentsInChildren<Light>();
        LensFlare[] flares = GetComponentsInChildren<LensFlare>();
		//Halo[] halos = GetComponentsInChildren<Halo>();

        while (t < flickerTime) 
        {
            foreach (Light l in lights) 
            {
                l.intensity = Mathf.Sin(t * flickerSpeed) * 8.0f;
            }
            foreach (LensFlare f in flares)
            {
                f.brightness = Mathf.Sin(t * flickerSpeed) * 1.0f;
            }
			/*foreach (Halo h in flares)
            {
                h.size = Mathf.Sin(t * flickerSpeed) * 1.0f;
            }*/
            
            t += Time.deltaTime;
            
            yield return null;
        }
        
        LightsOut();
    }
}
    