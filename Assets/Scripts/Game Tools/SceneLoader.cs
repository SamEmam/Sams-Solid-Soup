using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
using UnityEngine.UI;

public class SceneLoader : MonoBehaviour
{
    public TextMeshProUGUI loadingText;
    public GameObject loadingCanvas;

    private void Start()
    {
        loadingCanvas.SetActive(false);
    }

    public void LoadSceneByIndex(int scene)
    {
        loadingCanvas.SetActive(true);
        loadingText.text = "LOADING!";
        StartCoroutine(LoadNewScene(scene));
    }

    public void LoadSceneByName(string scene)
    {
        bool sceneIsFound = false;
        for (int i = 0; i < SceneManager.sceneCountInBuildSettings; i++)
        {
            Debug.Log(SceneManager.GetSceneByBuildIndex(i).name);
            if (scene == SceneManager.GetSceneByBuildIndex(i).name)
            {
                LoadSceneByIndex(i);
                sceneIsFound = true;
                break;
            }
        }
        if (!sceneIsFound)
        {
            Debug.Log(scene + " does not exist in build settings.");
        }
        else
        {
            Debug.Log(scene + " found!");
        }
    }

    IEnumerator LoadNewScene(int scene)
    {
        int dotCount = 3;
        AsyncOperation async = SceneManager.LoadSceneAsync(scene);
        
        while (!async.isDone)
        {
            if (dotCount > 0)
            {
                dotCount--;
                loadingText.text += ".";
                yield return new WaitForSeconds(0.4f);
            }
            else
            {
                yield return null;
            }
        }
    }
}
