using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using XboxCtrlrInput;

public class LocalGameManager : MonoBehaviour
{
    public XboxController controller;
    private SceneLoader sceneLoader;

    // Start is called before the first frame update
    void Start()
    {
        sceneLoader = FindObjectOfType<SceneLoader>();
    }

    // Update is called once per frame
    void LateUpdate()
    {
        if (XCI.GetButtonDown(XboxButton.Back, controller))
        {
            sceneLoader.LoadSceneByIndex(0);
        }

        if (XCI.GetButtonDown(XboxButton.Start, controller))
        {
            
            if (GamePrefs.GameMode == GameModeEnum.Racing)
            {
                sceneLoader.LoadSceneByIndex(2);
            }
            else if (GamePrefs.GameMode == GameModeEnum.Warfare)
            {
                sceneLoader.LoadSceneByIndex(3);
            }
            else if (GamePrefs.GameMode == GameModeEnum.Soup)
            {
                sceneLoader.LoadSceneByIndex(4);
            }
        }
    }
}
