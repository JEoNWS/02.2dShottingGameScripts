using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CameraManager : MonoBehaviour
{
    public Camera zoomedCam;
    public Transform zoomCamTrans;
    public Camera mainCam;
    public GameObject zoomUI;
    //public GameObject zoomedDot;
    public static bool currentZoomed = false;
    void Update()
    {
        if(Input.GetMouseButtonDown(1) && GameManager.currentState != GameManager.gameState.GameOver)
            OnMouseClick();
    }
    void OnMouseClick()
    {
        if(currentZoomed)
        {
            zoomedCam.enabled = false;
            mainCam.enabled = true;
            zoomUI.SetActive(false);
            currentZoomed = false;
        }
        else
        {
            zoomedCam.enabled = true;
            mainCam.enabled = false;
            zoomUI.SetActive(true);
            currentZoomed = true;
        }
        
    }
}
