using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class LevelLoader : MonoBehaviour
{
    int currentIndex;

    public GameObject levelLoader;

    // Start is called before the first frame update
    void Start()
    {
        currentIndex = SceneManager.GetActiveScene().buildIndex;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void NextScene()
    {
        SceneManager.LoadScene(currentIndex + 1);
        GetComponent<Spawner>().lastEnemySpawned = false;
    }

    public void ReloadScenes()
    {
        SceneManager.LoadScene(currentIndex);
        GetComponent<Spawner>().lastEnemySpawned = false;
    }

    public void AnyScene(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
        GetComponent<Spawner>().lastEnemySpawned = false;
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
