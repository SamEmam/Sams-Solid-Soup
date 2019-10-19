using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuSettingsDisabler : MonoBehaviour
{
    //[SerializeField]
    //private GameObject settings;
    //[SerializeField]
    //private MenuQualitySettings settingsScript;

    private void Awake()
    {
        GamePrefs.HasAppliedSettings = false;

        //settingsScript.ApplySettings();
        //settings.SetActive(false);
    }
}
