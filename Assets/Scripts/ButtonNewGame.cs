using UnityEngine;
using System.Collections;

public class ButtonNewGame : MonoBehaviour {

	IEnumerator OnMouseDown() {
		SceneDirection director = GetComponent<SceneDirection>();
		director.FadeToBlack(1.0f);
		
		yield return new WaitForSeconds(1.0f);
		
		Application.LoadLevel("Kentta0Valmis");
	}
}
