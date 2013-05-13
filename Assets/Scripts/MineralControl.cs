using UnityEngine;
using System.Collections;

public class MineralControl : MonoBehaviour {

	// Use this for initialization
	void Start () {
		Globals.maxMinerals++;		
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	
	public void OnTriggerEnter(Collider collider)
	{
		if (collider.gameObject.tag.Equals("Player"))
		{
			/*foreach(Transform child in transform.parent) {
				if (child.gameObject.name == "RespawnLocation")
					child.transform.rotation = ChangeToNext90Degrees(collider.transform.rotation);
					Globals.respawnAt = child.gameObject;
			}*/
			GameObject respawn = new GameObject("Respawn");
			respawn.transform.position = transform.position;
			respawn.transform.rotation = ChangeToNext90Degrees(collider.gameObject.transform.rotation);
			Globals.respawnAt = respawn;
			
			Destroy(gameObject);
			Globals.currentMinerals++;	
		}
	}
						
	private Quaternion ChangeToNext90Degrees(Quaternion rot) {
		Vector3 eulerAngles = rot.eulerAngles;
		
		eulerAngles.x = eulerAngles.x - eulerAngles.x % 90;
		eulerAngles.y = eulerAngles.y - eulerAngles.y % 90;
		eulerAngles.z = eulerAngles.z - eulerAngles.z % 90;
		
		return Quaternion.Euler(eulerAngles);
	}
}
