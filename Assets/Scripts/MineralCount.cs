using UnityEngine;
using System.Collections;

public class MineralCount : MonoBehaviour {

	public Texture2D mineralEmpty;
	public Texture2D mineralFilled;
	public int iconSize = 50;
	public int iconPadding = 25;
	
	// Update is called once per frame
	void Update () 
	{
	//	guiText.text = (Globals.currentMinerals.ToString() + "/" + Globals.maxMinerals.ToString());
	//	Debug.Log(Globals.currentMinerals);
	}
	
	void OnGUI() 
	{
		GUILayout.BeginArea(new Rect(10, 10, 800, iconSize*2));
		GUILayout.BeginHorizontal();
		
		Texture2D mineral;
		for(int i=0; i<Globals.maxMinerals; i++) 
		{	
			if( i < Globals.currentMinerals ) { mineral = mineralFilled; }
			else mineral = mineralEmpty;
			GUILayout.Box(mineral, GUIStyle.none, GUILayout.Height(iconSize), GUILayout.Width(iconSize + iconPadding));
		}
		
		GUILayout.EndHorizontal();
		GUILayout.EndArea();
	}
}
