using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

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
        loadingText.text = "LOADING!...";
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

        //yield return new WaitForSeconds(3f);

        AsyncOperation async = SceneManager.LoadSceneAsync(scene);

        while (!async.isDone)
        {
            yield return null;
            //yield return new WaitForSeconds(3f);
        }
    }
}
