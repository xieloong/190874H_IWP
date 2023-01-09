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

    public GameObject levelcompleteMenu;

    public GameObject endText;

    // Start is called before the first frame update
    void Start()
    {
        for (int i = 0; i < PlayerController.playerControllerArray.Count; i++)
        {
            PlayerController.playerControllerArray[i].gameController = this;
        }

        Time.timeScale = 1f;
        endText.SetActive(false);
        levelcompleteMenu.SetActive(false);
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
        Debug.Log(PlayerController.playerControllerArray.Count);

        if (PlayerController.playerControllerArray.Count <= 1)
        {
            gameoverMenu.SetActive(true);
            pauseButton.SetActive(false);
        }
    }

    public IEnumerator LevelCompleted()
    {
        yield return new WaitForSeconds(2f);
        endText.SetActive(true); 
        yield return new WaitForSeconds(2f);
        Time.timeScale = 0f;
        levelcompleteMenu.SetActive(true);
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
