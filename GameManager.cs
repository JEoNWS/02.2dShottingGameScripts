using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.Events;

public class GameManager : MonoBehaviour
{
    public enum gameState {Main, Play, GameOver}
    public UnityEvent gameOver;
    public static int totMob;
    public static GameManager gameManager = null;
    public TMP_Text textScore;
    public TMP_Text textTimer;
    public static int intScore;
    private int leftTime;
    gameState currentState;
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
        currentState = gameState.Play;
        intScore = 0;
        leftTime = 5;
        StartCoroutine(StartGame());
    }
    void Update()
    {
        if(currentState == gameState.GameOver)
            gameOver.Invoke();
    }
    IEnumerator StartGame()
    {
        textTimer.text = leftTime.ToString();
        while(currentState == gameState.Play)
        {  
            yield return new WaitForSeconds(1f);          
            leftTime -= 1;
            textTimer.text = leftTime.ToString();
            if(leftTime <= 0)
                currentState = gameState.GameOver;
        }
    }
}
