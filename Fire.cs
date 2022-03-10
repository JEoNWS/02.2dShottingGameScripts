using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fire : MonoBehaviour
{ 
    private Transform tr;
    RaycastHit rayHit;
    void Start()
    {
        tr = GetComponent<Transform>();
    }
    void Update()
    {
        if(Input.GetMouseButtonDown(0))
            Shoot();
    }
    void Shoot()
    {
        if(Physics.Raycast(tr.position, tr.forward, out rayHit))
        {
           if(rayHit.collider.CompareTag("Mob"))
           {
               rayHit.transform.GetComponent<Hit>().OnHit();
           }
        }
    }
}
