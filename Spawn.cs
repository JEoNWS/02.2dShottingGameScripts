using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawn : MonoBehaviour
{
    public float spawnTime;
    Transform[] points;
    int index;
    private GameObject[] mobs = new GameObject[3];
    public bool gameover;
    void Awake()
    {
        points = GetComponentsInChildren<Transform>();
        mobs = Resources.LoadAll<GameObject>("Prefebs");
    }
    void Start()
    {
        gameover = false;
        /*for(int i = 1; i < points.Length; i++)
        {
            points[i].gameObject.SetActive(false);
        }*/
            StartCoroutine("SpawnMob");
    }

    IEnumerator SpawnMob()
    { 
        while(gameover == false)   
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
            }
            spawnTime = Random.Range(0.5f, 1f);
            yield return new WaitForSeconds(spawnTime);
        }
    }
    public void StopPlay()
    {
        gameover = true;
    }
}
