using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    public GameObject PauseGame;
   public void Pause()
    {
        PauseGame.SetActive(true);
        Time.timeScale = 0;
    }
    public void Continue()
    {
        PauseGame.SetActive(false);
        Time.timeScale = 1;
    }
    public void Replay()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
