using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GetScores : MonoBehaviour
{
    public GameObject scorePannel;
    public GameObject namePannel;
    private Text[] scores;
    private Text[] names;
    void Start()
    {
        scores = scorePannel.GetComponentsInChildren<Text>();

        names = namePannel.GetComponentsInChildren<Text>();
        for(int i = 0; i < 10; i++)
        {
            Debug.Log(scores.Length);
            scores[i].text = PlayerPrefs.GetInt($"Score{i}", 0).ToString();
            names[i].text = PlayerPrefs.GetString(i.ToString(), "--");
        }
    }
    void Update()
    {
        if(Input.GetMouseButtonDown(0))
            SceneManager.LoadScene("Main");
    }
}
