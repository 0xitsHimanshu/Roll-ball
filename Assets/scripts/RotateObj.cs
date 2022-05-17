using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateObj : MonoBehaviour
{

    //public float Rotspeed;

    //private void OnMouseDrag()
    //{
    //    float rotX = Input.GetAxis("Mouse X") * Rotspeed * Mathf.Deg2Rad;
    //    float rotY = Input.GetAxis("Mouse Y") * Rotspeed * Mathf.Deg2Rad;


    //    transform.RotateAround(Vector3.up, -rotX);
    //    transform.RotateAround(Vector3.right, rotY);
    //}
    



    public float speedH = 2.0f;
    public float speedV = 2.0f;

    private float yaw = 0.0f;
    private float pitch = 0.0f;

    void Update()
    {
        yaw += speedH * Input.GetAxis("Mouse X");
        pitch -= speedV * Input.GetAxis("Mouse Y");

        transform.eulerAngles = new Vector3(pitch, yaw, 0.0f);
    }
}


