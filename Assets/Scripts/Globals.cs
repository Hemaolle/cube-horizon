/****************************************
 * Global variables for the Nuotio game
 * 
 * Author: Mikko Jakonen, Oskari Leppäaho
 * Version: 0.2 
 ***************************************/
using UnityEngine;
using System.Collections;

public class Globals : MonoBehaviour {

    //private static float gravityMultiplier = 50;
    private static Vector3 gravity = Vector3.down;
    private static Vector3 forwardDirection = Vector3.right;
    public static int maxMinerals = 0;
    public static int currentMinerals = 0;
	public static GameObject respawnAt;

    public static Vector3 GravityDirection
    {
        get { return gravity; }
    }
    public static Vector3 ForwardDirection
    {
        get { return forwardDirection;  }
    }
    
    public static void ChangeGravity(Transform transform)
    {
        gravity = transform.TransformDirection(Vector3.down);
        forwardDirection = transform.TransformDirection(Vector3.right);
        forwardDirection.Normalize();
    }
	
	public static void ResetMinerals() 
	{
		maxMinerals = 0;
		currentMinerals = 0;
	}
	
	public static void FadeToBlack(float durationSeconds) 
	{
		GameObject camera = GameObject.Find("Camera");
		SceneDirection sd = camera.GetComponent<SceneDirection>();
		sd.FadeToBlack(durationSeconds);
	}
	
	public static void FadeFromBlack(float durationSeconds) 
	{
		GameObject camera = GameObject.Find("Camera");
		SceneDirection sd = camera.GetComponent<SceneDirection>();
		sd.FadeFromBlack(durationSeconds);
	}
}
