using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DotMove : MonoBehaviour
{
    public float moveSpeed = 100.0f;
    Vector3 transPos = new Vector3(0, 0, 0);

    void Update()
    {
        DotMovement();
    }
    void DotMovement()
    {
        float posX = Input.GetAxis("Mouse X");
        float posY = Input.GetAxis("Mouse Y");
        transPos.x = posX * moveSpeed;
        transPos.y = posY * moveSpeed;
        
        transform.Translate(transPos * Time.deltaTime, Space.World);
        transform.position = new Vector3(Mathf.Clamp(transform.position.x, -18.5f, 18.5f), Mathf.Clamp(transform.position.y, -28.5f, 28.5f), 89); 

    }

}
