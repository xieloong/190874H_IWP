using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    [Header("Pause Menu")]
    public GameObject pauseMenu;
    public GameObject pauseButton;

    [Header("GameOver Menu")]
    public GameObject gameoverMenu;
    // Start is called before the first frame update
    void Start()
    {
        pauseMenu.SetActive(false);
        pauseButton.SetActive(true);

        gameoverMenu.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void PauseGame()
    {
        pauseMenu.SetActive(true);
        pauseButton.SetActive(false);
        Time.timeScale = 0f;
    }

    public void ResumeGame()
    {
        pauseMenu.SetActive(false);
        pauseButton.SetActive(true);
        Time.timeScale = 1f;
    }

    public void GameOver()
    {
        gameoverMenu.SetActive(true);
        pauseButton.SetActive(false);
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
