using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


public class ReportMenu : MonoBehaviour
{
    [SerializeField] private GameObject gameoverMenu;
    [SerializeField] private GameObject victoryMenu;
    [SerializeField] Sprite[] stars;

    public void Restart()
    {
        SoundManager.Instance().ResumeBackGroundMusic();
        SoundManager.Instance().ClickButton();
        Time.timeScale = 1f;
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void Menu(int sceneID)
    {
        SoundManager.Instance().ResumeBackGroundMusic();
        SoundManager.Instance().ClickButton();
        Time.timeScale = 1f;
        SceneManager.LoadScene(sceneID);
    }

    public void Gameover()
    {
        gameoverMenu.SetActive(true);
        SoundManager.Instance().PauseBackGroundMusic();
        SoundManager.PlaySound(SoundManager.SoundEffect.GameoverEffect);
        Time.timeScale = 0f;
        SoundManager.Instance().ClickButton();
    }

    public void Victory()
    {
        victoryMenu.transform.Find("Star").GetComponent<Image>().sprite = stars[GameMenu.Instance().StarValue];
        victoryMenu.SetActive(true);
        SoundManager.Instance().PauseBackGroundMusic();
        SoundManager.PlaySound(SoundManager.SoundEffect.VictoryEffect);
        Time.timeScale = 0f;
        SoundManager.Instance().ClickButton();
    }

    public void QuitGame()
    {
        Debug.Log("Quit !!!");
        SoundManager.Instance().ClickButton();
        Application.Quit();
    }
}
