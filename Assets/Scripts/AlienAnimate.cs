using UnityEngine;
using System.Collections;

public class AlienAnimate : MonoBehaviour {
	
	private Transform outerBody;
	private Transform innerBody;
	private Transform mineral;
	
	void Start() {
		outerBody = transform.FindChild("AlienOuter");
		innerBody = transform.FindChild("AlienInner");
		mineral = transform.FindChild("AlienMineral");
	}
	
	// Update is called once per frame
	void Update () {
		Vector3 scale = outerBody.localScale;
		scale.z = 1.0f + Mathf.Sin(Time.timeSinceLevelLoad) * 0.05f;
		outerBody.localScale = scale;
		
		Vector3 position = innerBody.localPosition;
		position.y = 0.5f + Mathf.Sin(Time.timeSinceLevelLoad) * 0.1f;
		innerBody.localPosition = position;
		
		Vector3 mineralPosition = mineral.localPosition;
		mineralPosition.y = 2.3f + Mathf.Sin(Time.timeSinceLevelLoad) * 0.1f;
		mineral.localPosition = mineralPosition;
	}
}
