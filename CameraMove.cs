using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CameraMove : MonoBehaviour
{
    private Transform tr;
    public float rotateSpeed = 100f;
    public bool canMove = false;
    private float rx;
    private float ry;
    void Start()
    {
        tr = GetComponent<Transform>();
    }

    void Update()
    {
        if(canMove)
            CameraRotation();
    }

    void CameraRotation()
    {
        float mx = Input.GetAxis("Mouse X");
        float my = -Input.GetAxis("Mouse Y");

        rx += rotateSpeed * mx * Time.deltaTime;
        ry += rotateSpeed * my * Time.deltaTime;

        rx = Mathf.Clamp(rx, -8.5f, 8.5f);
        ry = Mathf.Clamp(ry, -10.5f, 10.5f);

        tr.eulerAngles = new Vector3(ry, rx, 0);
    }
}
