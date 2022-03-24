using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DotMove : MonoBehaviour
{
    public bool gameover;
    public float moveSpeed = 300.0f;
    Vector3 transPos = new Vector3(0, 0, 0);

    void Start()
    {
        gameover = false;
    }
    void Update()
    {
        if(gameover == false)
            DotMovement();
    }
    void DotMovement()
    {
        float posX = Input.GetAxis("Mouse X");
        float posY = Input.GetAxis("Mouse Y");
        transPos.x = posX * moveSpeed;
        transPos.y = posY * moveSpeed;
        
        transform.Translate(transPos * Time.deltaTime, Space.World);
        transform.position = new Vector3(Mathf.Clamp(transform.position.x, -18.5f, 18.5f), Mathf.Clamp(transform.position.y, -28.5f, 28.5f), 88); 
    }
    public void StopPlay()
    {
        gameover = true;
    }

}
