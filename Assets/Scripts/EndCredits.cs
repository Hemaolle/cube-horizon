using UnityEngine;
using System.Collections;

public class EndCredits : MonoBehaviour {

    public float creditDuration = 13.0f;
    public float creditBeginDelay = 5.0f;
    public float creditDelay = 2.0f;
    public int barSize = 100;
    public Texture2D texScreen;
    public GUIStyle creditstyle;

    private string[] credits = {
                                  "Cube Horizon",
                                  "Created by:",
                                  "Kai Ylinen \n <color=\"#999\">Producer, project manager</color>",
                                  "Eetu Vilhunen \n <color=\"#999\">Game designer, level designer</color>",
                                  "Katariina Pesonen \n <color=\"#999\">Game designer, level designer, writer</color>",
                                  "Mikko Jakonen \n <color=\"#999\">Programmer, graphic designer, modeler, texturer</color>",
                                  "Oskari Leppäaho \n <color=\"#999\">Programmer, modeler</color>",
                                  "Santeri Hämäläinen \n <color=\"#999\">Sound designer, composer</color>",
                                  "Tapio Hänninen \n <color=\"#999\">Voice actor</color>",
                                  "Cube Horizon",
                                  "Thank you for playing!"
                               };

    private string activeCredit = null;
    private float activeAlpha = 0.0f;

    // Use this for initialization
    void Start () {
        StartCoroutine(RunCredit(0));
    }

    //show the i:th credit, and then show the next one.
    IEnumerator RunCredit(int i)
    {
        activeCredit = credits[i];
        float t = 0.0f;
        float o;

        yield return new WaitForSeconds(creditDelay);

        //fade in:
        while (t < creditDuration / 3)
        {
            o = (t / (creditDuration/3)) * 1.0f;
            activeAlpha = o;

            t += Time.deltaTime;
            yield return null;
        }

        yield return new WaitForSeconds(creditDuration / 3);

        //fade out:
        while (t > 0.0f)
        {
            o = (t / (creditDuration / 3)) * 1.0f;
            activeAlpha = o;

            t -= Time.deltaTime;
            yield return null;
        }

        if (i < credits.Length) StartCoroutine(RunCredit(i + 1));
    }

    void OnGUI()
    {
        GUI.DrawTexture(new Rect(0, 0, Screen.width, barSize), texScreen);
        GUI.DrawTexture(new Rect(0, Screen.height - barSize, Screen.width, barSize), texScreen);

        Color c = GUI.color;
        c.a = activeAlpha;
        GUI.color = c;

        
        GUI.Label(new Rect(0, 50, Screen.width, Screen.height), activeCredit, creditstyle);
    }
}
