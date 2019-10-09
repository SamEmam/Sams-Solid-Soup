using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIAntiObjectScaler : MonoBehaviour
{
    private float sizeIncrement = 0.065f;
    private float startSize = 0.035f;

    private void Start()
    {
        Vector3 scale = transform.localScale;

        scale.x = sizeIncrement * GamePrefs.TotalPlayerCount + startSize;

        transform.localScale = scale;
    }
}
