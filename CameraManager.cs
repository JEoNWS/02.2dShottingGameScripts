using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CameraManager : MonoBehaviour
{
    public Camera zoomedCam;
    public Transform zoomCamTrans;
    public Camera mainCam;
    public GameObject dot;
    public GameObject zoomedDot;
    public static bool currentZoomed = false;
    void Update()
    {
        if(Input.GetMouseButtonDown(1))
            OnMouseClick();
    }
    void OnMouseClick()
    {
        if(currentZoomed)
        {
            zoomedCam.enabled = false;
            mainCam.enabled = true;
            zoomedDot.SetActive(false);
            dot.SetActive(true);
            zoomedCam.gameObject.GetComponent<CameraMove>().canMove = false;
            currentZoomed = false;
        }
        else
        {
            zoomCamTrans.LookAt(dot.transform);
            zoomedCam.enabled = true;
            mainCam.enabled = false;
            zoomedDot.SetActive(true);
            dot.SetActive(false);
            zoomedCam.gameObject.GetComponent<CameraMove>().canMove = true;
            currentZoomed = true;
        }
        
    }
}
