using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawn : MonoBehaviour
{
    public float spawnTime = 3.0f;
    Transform[] points;
    int index;
    private GameObject[] mobs = new GameObject[3];
    void Awake()
    {
        points = GetComponentsInChildren<Transform>();
        mobs = Resources.LoadAll<GameObject>("Prefebs");
    }
    void Start()
    {
        /*for(int i = 1; i < points.Length; i++)
        {
            points[i].gameObject.SetActive(false);
        }*/
            StartCoroutine("SpawnMob");
    }

    IEnumerator SpawnMob()
    { 
        while(true)   
        {
            if(GameManager.totMob < 9)
            {
                index = Random.Range(0, points.Length);
                while(points[index].childCount != 0)
                {
                    index = Random.Range(0, points.Length);
                }
                //points[index].gameObject.SetActive(true);
                Instantiate(mobs[Random.Range(0, mobs.Length)], points[index].position, points[index].rotation, points[index]);
                GameManager.totMob += 1;
                Debug.Log(GameManager.totMob);
            }
            spawnTime = Random.Range(1.0f, 2.5f);
            yield return new WaitForSeconds(spawnTime);
        }
    }
}
