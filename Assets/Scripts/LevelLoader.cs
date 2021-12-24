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

    public void LevelScreen()
    {
        SceneManager.LoadScene("Level Screen");
    }

    public void Scene0()
    {
        SceneManager.LoadScene(0);
    }
    public void Scene1()
    {
        SceneManager.LoadScene(1);
    }

    public void Scene2()
    {
        SceneManager.LoadScene(2);
    }

    public void Scene3()
    {
        SceneManager.LoadScene(3);
    }

    public void Scene4()
    {
        SceneManager.LoadScene(4);
    }

    public void Scene5()
    {
        SceneManager.LoadScene(5);
    }

    public void Scene6()
    {
        SceneManager.LoadScene(6);
    }

    public void Quit()
    {
        Application.Quit();
    }

}
