using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameManager : MonoBehaviour
{
    public static int totMob;
    public static GameManager gameManager = null;
    public TMP_Text textScore;
    public static int intScore;
    void Awake()
    {
        if(gameManager == null)
        {
            gameManager = this;
        }
        else if(gameManager != this)
        {
            Destroy(this);
        }
        totMob = 0;
    }
    void Start()
    {
        intScore = 0;
    }
}
