using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.Events;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public enum gameState {Main, Play, GameOver, IDLE}
    public UnityEvent gameOver;
    public static int totMob;
    public static GameManager gameManager = null;
    public GameObject gameoverUI;
    public Canvas playSceneCanvus;
    public InputField enterName;
    public TMP_Text textScore;
    public TMP_Text textTimer;
    public static int intScore;
    int ranking;
    private int[] scores = new int[10];
    private int leftTime;
    public static gameState currentState;
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
        //playSceneCanvus.gameObject.SetActive(true);
        currentState = gameState.Play;
        intScore = 0;
        leftTime = 5;
        StartCoroutine(StartGame());
    }
    void Update()
    {
        /*if(currentState == gameState.GameOver)
        {
            gameOver.Invoke();
            gameoverUI.SetActive(true);
            IsHighScore();
            currentState = gameState.IDLE;
        }*/

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
                {
                    currentState = gameState.GameOver;
                    gameOver.Invoke();
                    gameoverUI.SetActive(true);
                    IsHighScore();
                    currentState = gameState.IDLE;
                }
        }
    }
    public void IsHighScore()
    {
        for(int i = 0; i < scores.Length; i++)
        {
            scores[i] = PlayerPrefs.GetInt($"Score{i}");

        }
        for(int i = 0; i < scores.Length; i++)
        {
            if(intScore > scores[i])
            {
                ranking = i;
                Debug.Log("IF");
                for(int j = scores.Length - 1; j == i; j--)
                {
                    scores[j] = scores[j - 1];
                }
                scores[i] = intScore;
                enterName.gameObject.SetActive(true);
                SetPlayerPrefs();
                return;
            }
        }
        StartCoroutine("LoadHighScore", LoadSceneMode.Additive);
    }
    private void SetPlayerPrefs()
    {
        for(int i = 0; i < scores.Length; i++)
        {
            PlayerPrefs.SetInt($"Score{i}", scores[i]);
        }
    }
    public void SetPlayerName()
    {
        PlayerPrefs.SetString(ranking.ToString(), enterName.text);
    }
    IEnumerator LoadHighScore()
    {
        yield return new WaitForSeconds(3f);
        SceneManager.LoadScene("HighScore", LoadSceneMode.Additive);
    }
}
