using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using XboxCtrlrInput;

public class StartManager : MonoBehaviour
{
    [SerializeField]
    private SceneLoader sceneLoader;
    [SerializeField]
    private XboxController controller;

    // Update is called once per frame
    void LateUpdate()
    {
        if (XCI.GetButtonDown(XboxButton.A, controller))
        {
            switch ((int)GamePrefs.RaceMapEnum)
            {
                case 0:
                    sceneLoader.LoadSceneByIndex(5);
                    break;
                case 1:
                    sceneLoader.LoadSceneByIndex(6);
                    break;
                case 2:
                    sceneLoader.LoadSceneByIndex(7);
                    break;
            }
        }
    }

    private void Update()
    {
        if (XCI.GetButtonDown(XboxButton.Back, controller))
        {
            sceneLoader.LoadSceneByIndex(1);
        }
    }
}
