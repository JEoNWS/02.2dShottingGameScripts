using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Hit : MonoBehaviour
{
    public Animator anim;
    public float stayTime = 100.0f;
    public void OnHit()
    {
        GameManager.intScore += 10;
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
        anim.SetTrigger("Down");
        StartCoroutine("Disable");
    }
    IEnumerator Disable()
    {
        yield return new WaitForSeconds(1.0f);
        GameManager.totMob -= 1;
        this.gameObject.SetActive(false);
        
    }
}
