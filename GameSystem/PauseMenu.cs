using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    [SerializeField] private GameObject pauseMenu;

    GameObject[] gameObjects;
    private float beforePauseSpeed;

    public void Menu()
    {
        Time.timeScale = 1f;
        SoundManager.Instance().ClickButton();
        SoundManager.Instance().ResumeBackGroundMusic();
        Invoke("LoadScence", 0.3f);
    }

    public void LoadScence()
    {
        SceneManager.LoadScene(0);
    }

    public void Pause()
    {
        gameObjects = GameObject.FindGameObjectsWithTag("Tower");
        SoundManager.Instance().PauseBackGroundMusic();
        foreach(GameObject g in gameObjects)
        {
            g.GetComponent<Collider2D>().enabled = false;
        }
        pauseMenu.SetActive(true);
        beforePauseSpeed = Time.timeScale;
        Time.timeScale = 0f;
        SoundManager.Instance().ClickButton();
    }

    public void Resume()
    {
        SoundManager.Instance().ResumeBackGroundMusic();
        foreach (GameObject g in gameObjects)
        {
            g.GetComponent<Collider2D>().enabled = true;
        }
        pauseMenu.SetActive(false);
        Time.timeScale = beforePauseSpeed;
        SoundManager.Instance().ClickButton();
    }

    public void QuitGame()
    {
        Debug.Log("Quit !!!");
        SoundManager.Instance().ClickButton();
        Application.Quit();
    }
}
