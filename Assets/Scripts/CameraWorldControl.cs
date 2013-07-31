/**********************************************************************
 * Camera controlling and gravity flippnig script. Also includes
 * zooming out.
 * 
 * Author: Mikko Jakonen, Oskari Leppäaho
 * Version: 0.5
 **********************************************************************/
using UnityEngine;
using System.Collections;

public class CameraWorldControl : MonoBehaviour
{
    public AnimationCurve rotationCurve;
    public float rotationSeconds = 1.0f;
    public float zoomAmount = 100.0f;
    public float zoomSeconds = 1.0f;
	private GameObject character;
    //direction of rotation: 1 = clockwise, -1 = counter-clockwise, 0 = no rotation
    private int rotating = 0;
    //when set to true, DoRotate() rotates y-axis
    private bool rotateY = false;
    //zooming: 
    private bool zooming = false;

    private float returnZ;
    private bool zoomedOut = false;
	
	void Start() 
	{
		character = GameObject.FindGameObjectWithTag("Player");
	}

    void Update () 
    {
        if (Input.GetButtonDown("RotateR") && rotating == 0 && !zoomedOut && !zooming)
        {
            rotating = -1;
            rotateY = false;
            StartCoroutine(DoRotate());
        }
        if (Input.GetButtonDown("RotateL") && rotating == 0 && !zoomedOut && !zooming)
        {
            rotating = 1;
            rotateY = false;
            StartCoroutine(DoRotate());
        }
        if (Input.GetButtonDown("RotateR2") && rotating == 0 && !zoomedOut && !zooming)
        {
            rotating = -1;
            rotateY = true;
            StartCoroutine(DoRotate());
        }
        if (Input.GetButtonDown("RotateL2") && rotating == 0 && !zoomedOut && !zooming)
        {
            rotating = 1;
            rotateY = true;
            StartCoroutine(DoRotate());
        }

        if (Input.GetButtonDown("Zoom") && !zooming && gameObject.name == "CamFollow")
        {
            zooming = true;
            StartCoroutine(DoZoom());
        } 
    }
	
	bool cancelRotate = false;
	
	public void CancelRotate() {
		cancelRotate = true;
	}

    IEnumerator DoRotate()
    {
        float rotationAmount = rotating * 90;
        float t = 0.0f;
        float rate = 1 / rotationSeconds;
        float start, end, previous;
		MeshMovement movement = character.GetComponent<MeshMovement>();
		
        if (!rotateY) start = transform.eulerAngles.z;
        else start = transform.eulerAngles.y;
        end = start + rotationAmount;
        previous = start;

		if(!rotateY)
			character.GetComponent<Animator>().SetBool("Turning", true);
        while (true)
        {
			if (cancelRotate) { cancelRotate = false; break; }
			
            float factor = rotationCurve.Evaluate(t);

            if (!rotateY)
            {
				transform.Rotate(-(start + (end - start) * factor - previous),0,0);
				character.transform.Rotate(movement.goingForward * -(start + (end - start) * factor - previous),0,0);
                previous = start + (end - start) * factor;
            }
            else
            {
                transform.Rotate(0, start + (end - start) * factor - previous, 0);
				character.transform.Rotate(0, start + (end - start) * factor - previous, 0);
                previous = start + (end - start) * factor;
            }

            if (Mathf.Abs(previous - end) < 0.001f) break; //stop when we reach target angle
          
            t += rate * Time.deltaTime;

            Globals.ChangeGravity(transform);
            yield return null;
        }
		
		if(!rotateY)
			character.GetComponent<Animator>().SetBool("Turning", false);
        rotating = 0;
    }

    IEnumerator DoZoom()
    {
        Camera camera = GetComponentInChildren<Camera>();
        Vector3 start = camera.transform.position;
        Vector3 end = start + camera.transform.TransformDirection(Vector3.back) * zoomAmount;
        if (zoomedOut) end = start - camera.transform.TransformDirection(Vector3.back) * zoomAmount;
        float t = 0.0f;
        float rate = 1 / zoomSeconds;
		
		
        MeshMovement movement = character.GetComponent<MeshMovement>();
        movement.enabled = false;
        movement.FullStop();

        while (true)
        {
            float factor = rotationCurve.Evaluate(t);
            Vector3 current = camera.transform.position;
            current = start + (end - start) * factor;

            camera.transform.position = current;
            if (t > 1.0f) break;

            t += Time.deltaTime * rate;
            yield return null;
        }
        if (!zoomedOut) zoomedOut = true;
        else
        {
            zoomedOut = false;
            movement.enabled = true;
        }
        zooming = false;
    }

}
