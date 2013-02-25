/**********************************************************************
 * Camera controlling and gravity flippnig script
 * 
 * Author: Mikko Jakonen, Oskari Leppäaho
 * Version: 0.4 
 **********************************************************************/
using UnityEngine;
using System.Collections;

public class CameraWorldControl : MonoBehaviour
{
    public AnimationCurve rotationCurve;
    public float rotationSeconds = 1.0f;

    //direction of rotation: 1 = clockwise, -1 = counter-clockwise, 0 = no rotation
    private int rotating = 0;
    //when set to true, DoRotate() rotates y-axis
    private bool rotateY = false;

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
}
