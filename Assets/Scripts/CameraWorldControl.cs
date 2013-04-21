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
    public float zoomedZ = -120.0f;
    public float zoomSeconds = 1.0f;

    //direction of rotation: 1 = clockwise, -1 = counter-clockwise, 0 = no rotation
    private int rotating = 0;
    //when set to true, DoRotate() rotates y-axis
    private bool rotateY = false;
    //zooming: 1 = in, -1 = out, 0 = no zoom
    private bool zooming = false;

    private float initialZ;
    private bool zoomedOut = false;

    void Start()
    {
        initialZ = GetComponentInChildren<Camera>().transform.position.z;
    }

    void Update () 
    {
        if (Input.GetButtonDown("RotateR") && rotating == 0)
        {
            rotating = -1;
            rotateY = false;
            StartCoroutine(DoRotate());
        }
        if (Input.GetButtonDown("RotateL") && rotating == 0)
        {
            rotating = 1;
            rotateY = false;
            StartCoroutine(DoRotate());
        }
        if (Input.GetButtonDown("RotateR2") && rotating == 0)
        {
            rotating = -1;
            rotateY = true;
            StartCoroutine(DoRotate());
        }
        if (Input.GetButtonDown("RotateL2") && rotating == 0)
        {
            rotating = 1;
            rotateY = true;
            StartCoroutine(DoRotate());
        }

        if (Input.GetButtonDown("Zoom") && !zooming)
        {
            zooming = true;
            StartCoroutine(DoZoom());
        } 
    }

    IEnumerator DoRotate()
    {
        float rotationAmount = rotating * 90;
        float t = 0.0f;
        float rate = 1 / rotationSeconds;
        float start, end, previous;

        if (!rotateY) start = transform.eulerAngles.z;
        else start = transform.eulerAngles.y;
        end = start + rotationAmount;
        previous = start;

        while (true)
        {
            float factor = rotationCurve.Evaluate(t);

            if (!rotateY)
            {
                transform.Rotate(0, 0, start + (end - start) * factor - previous);
                previous = start + (end - start) * factor;
            }
            else
            {
                transform.Rotate(0, start + (end - start) * factor - previous, 0);
                previous = start + (end - start) * factor;
            }

            if (Mathf.Abs(previous - end) < 0.001f) break; //stop when we reach target angle
          
            t += rate * Time.deltaTime;

            Globals.ChangeGravity(transform);
            yield return null;
        }

        rotating = 0;
    }

    IEnumerator DoZoom()
    {
        Camera camera = GetComponentInChildren<Camera>();
        float start = camera.transform.position.z;
        float end = zoomedOut ? zoomedZ : initialZ;
        float t = 0.0f;
        float rate = 1 / zoomSeconds;

        while (true)
        {
            float factor = rotationCurve.Evaluate(t);
            Vector3 pos = camera.transform.position;
            pos.z = start + (end - start) * factor;

            camera.transform.position = pos;
            if (Mathf.Abs(pos.z - end) < 0.001f) break;

            t += Time.deltaTime * rate;
            yield return null;
        }
        if (!zoomedOut) zoomedOut = true;
        else zoomedOut = false;
        zooming = false;
    }

}
