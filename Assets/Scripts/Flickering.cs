using UnityEngine;
using System.Collections;

public class Flickering : MonoBehaviour {
	public float flickerSpeed = 5;
	public float baseOpacity = 0.3f;
	public float flickerVariance = 0.1f;
	
	// Update is called once per frame
	void Update () {
		GUITexture texture = GetComponent<GUITexture>();
		Color c = texture.color;
		c.a = baseOpacity + Mathf.Sin(Time.realtimeSinceStartup * flickerSpeed) * flickerVariance;
		texture.color = c;
	}
}
