using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelLoader : MonoBehaviour
{
    int currentSceneIndex;
    [SerializeField] float timeToWait = 3f;

    void Start()
    {
        Debug.Log("start");
        currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        if (currentSceneIndex == 0)
        {
            StartCoroutine(WaitForTime());
        }
    }

    IEnumerator WaitForTime()
    {
        yield return new WaitForSecondsRealtime(timeToWait);
        Debug.Log("in coroutine");
        LoadNextScene();
    }

    public void LoadNextScene()
    {
        Debug.Log("load next scene");
        currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(currentSceneIndex + 1);
    }

    public void LoadStartScreen()
    {
        SceneManager.LoadScene("Start Screen");
        Time.timeScale = 1;
    }
    public void LoadGame()
    {
        SceneManager.LoadScene("Level 1");
        Time.timeScale = 1;
    }

    public void RestartScene()
    {
        SceneManager.LoadScene(currentSceneIndex);
    }

    public void LoadOptionsScene()
    {
        SceneManager.LoadScene("Options Screen");
    }

    public void Quit()
    {
        Application.Quit();
    }

}
