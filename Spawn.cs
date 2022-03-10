using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawn : MonoBehaviour
{
    public float spawnTime = 3.0f;
    Transform[] points;
    int index;
    void Awake()
    {
        points = GetComponentsInChildren<Transform>();
    }
    void Start()
    {
        for(int i = 1; i < points.Length; i++)
        {
            points[i].gameObject.SetActive(false);
        }
            StartCoroutine("SpawnMob");
    }

    IEnumerator SpawnMob()
    { 
        while(true)   
        {
            if(GameManager.totMob < 9)
            {
                index = Random.Range(0, points.Length);
                while(points[index].gameObject.activeSelf == true)
                {
                    index = Random.Range(0, points.Length);
                }
                
                points[index].gameObject.SetActive(true);
                GameManager.totMob += 1;
                Debug.Log(GameManager.totMob);
            }
            yield return new WaitForSeconds(spawnTime);
        }
    }
}
