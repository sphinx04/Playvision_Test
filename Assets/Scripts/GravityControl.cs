using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GravityControl : MonoBehaviour
{
    public Transform player;
    public float rotationSpeed = 100.0f;
    private float x;
    private float z;

    private Vector2 firstPressPos;
    private Vector2 secondPressPos;
    private Vector2 currentSwipe;
    private Vector3 currentEulerAngles;

    private void Start()
    {
        x = transform.eulerAngles.x;
        z = transform.eulerAngles.z;
    }

    float ClampAngle(float angle, float from, float to)
    {
        if (angle < 0f) angle = 360 + angle;
        if (angle > 180f)
            return Mathf.Max(angle, 360 + from);
        return Mathf.Min(angle, to);
    }

    private void Update()
    {
        float vertical = 0;
        float horizontal = 0;

        if (Input.GetMouseButtonDown(0) && Input.touchCount < 2)
        {
            currentEulerAngles = transform.eulerAngles;
            firstPressPos = new Vector2(Input.mousePosition.x, Input.mousePosition.y);
        }
        if (Input.GetMouseButton(0))
        {
            secondPressPos = new Vector2(Input.mousePosition.x, Input.mousePosition.y);
            //Debug.Log(secondPressPos);
            currentSwipe = new Vector2(secondPressPos.x - firstPressPos.x, secondPressPos.y - firstPressPos.y);
            currentSwipe.x /= Screen.width;
            currentSwipe.y /= Screen.height;

            vertical = currentSwipe.y;
            horizontal = currentSwipe.x;

            x = currentEulerAngles.x + vertical * rotationSpeed;
            z = currentEulerAngles.z - horizontal * rotationSpeed;

        }
        Vector3 lerpedVec = Vector3.Lerp(currentEulerAngles, new Vector3(x, 0, z), .1f);
        //transform.eulerAngles = lerpedVec;

        
        transform.RotateAround(player.position, Vector3.right, x - transform.eulerAngles.x);
        transform.RotateAround(player.position, Vector3.forward, z - transform.eulerAngles.z);


        transform.eulerAngles = new Vector3(ClampAngle(transform.eulerAngles.x, -45f, 45f), transform.eulerAngles.y, ClampAngle(transform.eulerAngles.z, -45f, 45f));

        transform.eulerAngles = new Vector3(transform.eulerAngles.x, 0, transform.eulerAngles.z);
    }
}

