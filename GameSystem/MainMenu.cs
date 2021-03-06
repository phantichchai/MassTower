using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour
{
    [SerializeField] GameObject buttonMusic;
    [SerializeField] GameObject buttonSound;
    private void Start()
    {
        buttonMusic.SetActive(SoundManager.Instance().music);
        buttonSound.SetActive(SoundManager.Instance().sound);
    }

    public void PlayGame()
    {
        SoundManager.Instance().ClickButton();
        Invoke("Play", 0.3f);
    }

    public void Play()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void QuitGame()
    {
        Debug.Log("Quit !!!");
        Application.Quit();
    }

    public void ClickMuteMusic()
    {
        SoundManager.Instance().ClickButton();
        SoundManager.Instance().MuteBackgroundMusic();
        buttonMusic.SetActive(SoundManager.Instance().music);
    }

    public void ClickUnMuteMusic()
    {
        SoundManager.Instance().ClickButton();
        SoundManager.Instance().UnMuteBackgroundMusic();
        buttonMusic.SetActive(SoundManager.Instance().music);
    }

    public void ClickMuteSound()
    {
        SoundManager.Instance().ClickButton();
        SoundManager.Instance().MuteSound();
        buttonSound.SetActive(SoundManager.Instance().sound);
        SoundManager.Instance().gameObject.GetComponent<SoundManager>().enabled = false;
    }

    public void ClickUnMuteSound()
    {
        SoundManager.Instance().ClickButton();
        SoundManager.Instance().UnMuteSound();
        buttonSound.SetActive(SoundManager.Instance().sound);
        SoundManager.Instance().gameObject.GetComponent<SoundManager>().enabled = true;
    }
}
