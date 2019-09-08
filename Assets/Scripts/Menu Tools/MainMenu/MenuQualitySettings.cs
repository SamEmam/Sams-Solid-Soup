using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuQualitySettings : MonoBehaviour
{
    private void Start()
    {
        Application.targetFrameRate = 60;
        QualitySettings.vSyncCount = 0;
    }
}
