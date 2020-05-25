using System.Collections;
using System.Collections.Generic;
using System.Security.Policy;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartGame : MonoBehaviour
{
    public void LoadMainScene()
    {
        SceneManager.LoadScene("MainScene");
        GetComponent<AudioSource>().Play();
    }

    public void ExitGame()
    {
        Application.Quit();
    }
}
