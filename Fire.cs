using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Fire : MonoBehaviour
{ 
    private Transform tr;
    RaycastHit rayHit;
    private int relodeBulletCount;
    public float relodeTime;
    private GameObject[] bullets;
    void Start()
    {
        relodeBulletCount = -1;
        relodeTime = 1.5f;
        bullets = GameObject.FindGameObjectsWithTag("Bullet");
        tr = GetComponent<Transform>();
    }
    void Update()
    {
        if(Input.GetMouseButtonDown(0) && relodeBulletCount < 4 && GameManager.currentState != GameManager.gameState.GameOver)
            {Shoot(); Debug.Log("FIre"); Debug.Log(relodeBulletCount);}
    }
    void Shoot()
    {
        if(Physics.Raycast(tr.position, tr.forward, out rayHit))
        {
            relodeBulletCount++;
            StartCoroutine("Reload");
           if(rayHit.collider.CompareTag("Mob"))
           {
               rayHit.transform.GetComponent<Hit>().OnHit();
           }
        }
    }
    IEnumerator Reload()
    {
        bullets[relodeBulletCount].SetActive(false);
        yield return new WaitForSeconds(relodeTime);
        FillBullet();
        relodeBulletCount--;
    }
    void FillBullet()
    {
        bullets[relodeBulletCount].SetActive(true);
    }
}
