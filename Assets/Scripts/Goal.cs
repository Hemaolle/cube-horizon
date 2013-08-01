/*********************************
 * New level is loaded when player enters goal.
 *
 * Author: Oskari Leppäaho, Mikko Jakonen
 * Version: 0.4
 *********************************/

using UnityEngine;
using System.Collections;

public class Goal : MonoBehaviour {

    public string nextLevelName;
    /** Time to wait before loading the next level: */
    public float endDelay = 0.0f;
    public float fadeDuration = 3.0f;
    
    IEnumerator OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            if (Globals.currentMinerals < Globals.maxMinerals) yield break;
            other.gameObject.GetComponent<MeshMovement>().enabled = false;
            other.gameObject.GetComponent<CameraWorldControl>().enabled = false;
            other.gameObject.rigidbody.Sleep();
            if (endDelay > 0) yield return new WaitForSeconds(endDelay);
            StartCoroutine(DoTransition());			
        }
		if (other.gameObject.name == "AlienBody") {
			//other.gameObject.SetActive(false);
			other.gameObject.transform.FindChild("AlienTeleportEffect").animation.Play();
		}
    }
    
    IEnumerator DoTransition() 
    {
        GameObject camera = GameObject.Find("Main Camera");
        SceneDirection sd = camera.GetComponent<SceneDirection>();
        sd.FadeToBlack(fadeDuration);
        yield return new WaitForSeconds(fadeDuration);
        
        Globals.ResetMinerals();
        Application.LoadLevel(nextLevelName);
    }
}
