using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CameraMove : MonoBehaviour
{
    private Transform tr;
    public GameObject dot;
    public float rotateSpeed = 100f;
    private float rx;
    private float ry;
    void Start()
    {
        tr = GetComponent<Transform>();
    }

    void Update()
    {
        transform.LookAt(dot.transform);
    }
}
