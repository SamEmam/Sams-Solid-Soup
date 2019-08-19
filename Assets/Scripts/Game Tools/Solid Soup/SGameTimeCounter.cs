using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SGameTimeCounter : MonoBehaviour
{
    public float time;


    private void Update()
    {
        time = GamePrefs.GameTime;

        GamePrefs.GameTime -= Time.deltaTime;
    }
}
