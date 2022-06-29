using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{

    AudioSource audioSource;

    private void Start()
    {
        audioSource = GameObject.Find("Music").GetComponent<AudioSource>();
    }


    public void GameMenu()
    {
        Debug.Log("GameMenu");
        SceneManager.LoadScene("GameMenu");
    }

    public void QuitGame()
    {
        Debug.Log("Quit");
        Application.Quit();
    }

    public void ReturnToMainMenu()
    {
        Debug.Log("ReturnToMainMenu");
        SceneManager.LoadScene("Menu");
    }

    public void Restart()
    {
        Debug.Log("Restart");
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void MuteMusic()
    {
        Debug.Log("Muted");
        audioSource.Stop();
    }

    public void UnMuteMusic()
    {
        Debug.Log("UnMuted");
        audioSource.Play();
    }
}
