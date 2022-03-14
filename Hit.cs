using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Hit : MonoBehaviour
{
    public Animator anim;
    public float stayTime = 5.0f;
    public int socre = 0;
    private bool hit = false;
    public void OnHit()
    {
        hit = true;
        GameManager.intScore += socre;
        Debug.Log("hit");
        GameManager.gameManager.textScore.text = string.Format("{0}", GameManager.intScore);
        anim.SetTrigger("Down");
        StartCoroutine("Disable");
    }
    void OnEnable()
    {
        anim.SetTrigger("Up");
        StartCoroutine("StayTime");
    }

    IEnumerator StayTime()
    {
        yield return new WaitForSeconds(stayTime);
        if(hit == false)
        {
            anim.SetTrigger("Down");
            StartCoroutine("Disable");
        }
    }
    IEnumerator Disable()
    {
        yield return new WaitForSeconds(1.0f);
        GameManager.totMob -= 1;
        Debug.Log(GameManager.totMob);
        Destroy(this.gameObject);
        
    }
}
