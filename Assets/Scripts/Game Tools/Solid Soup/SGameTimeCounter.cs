using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class SGameTimeCounter : MonoBehaviour
{
    public float time;
    public TextMeshProUGUI text;

    private void Update()
    {
        time = GamePrefs.GameTime;

        GamePrefs.GameTime -= Time.deltaTime;

        if (text)
        {
            UpdateText();
        }
    }

    void UpdateText()
    {
        if (time > 0f)
        {
            var min = (int)time / 60;
            var sec = (int)time % 60;

            if (sec < 10)
            {
                text.text = "Time left: " + min + ":0" + sec;
            }
            else
            {
                text.text = "Time left: " + min + ":" + sec;
            }
        }
        else
        {
            text.text = "Times up!";
        }
    }
}
