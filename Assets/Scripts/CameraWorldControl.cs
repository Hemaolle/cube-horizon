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

        //if (rotating != 0) DoRotate();
    }

    IEnumerator DoRotate()
    {
        float rotationAmount = rotating * 90;
        float t = 0.0f;
        float rate = 1 / rotationSeconds;

        Quaternion originalAngle = transform.rotation;
        Quaternion targetAngle;

        if (!rotateY) targetAngle = originalAngle * Quaternion.Euler(0, 0, rotationAmount);
        else targetAngle = originalAngle * Quaternion.Euler(0, rotationAmount, 0);

        while (true)
        {            
            Vector3 angles = transform.eulerAngles;

            if (!rotateY)
            {
                angles.z = originalAngle.eulerAngles.z + rotationCurve.Evaluate(t) * rotationAmount;
            }
            else
            {
                angles.y = originalAngle.eulerAngles.y + rotationCurve.Evaluate(t) * rotationAmount;
            }

            if (!rotateY)
            {
                if (Mathf.Abs(transform.eulerAngles.z - targetAngle.eulerAngles.z) < 0.001) break;
            }
            else if (Mathf.Abs(transform.eulerAngles.y - targetAngle.eulerAngles.y) < 0.001) break;
          

            transform.eulerAngles = angles;
            t += rate * Time.deltaTime;

            Globals.ChangeGravity(transform);
            yield return null;
        }

        rotating = 0;
    }
}
