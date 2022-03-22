using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneManagement : MonoBehaviour
{
    public void LoadScenePlay()
    {
        SceneManager.LoadScene("Play", LoadSceneMode.Single);
    }

    public void LoadSceneHighScore()
    {
        SceneManager.LoadScene("HighScore", LoadSceneMode.Additive);
    }
    public void Quit()
    {
        Application.Quit();
    }
}
