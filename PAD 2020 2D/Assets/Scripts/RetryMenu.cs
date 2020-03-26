using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class RetryMenu : MonoBehaviour
{
    public void Retry()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 1);
    }
       
    public void QuitGame()
    {
        Debug.Log("QuitGame");
        Application.Quit();
    }
}
