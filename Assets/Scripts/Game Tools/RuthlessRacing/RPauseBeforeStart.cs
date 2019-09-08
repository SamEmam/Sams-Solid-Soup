using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class RPauseBeforeStart : MonoBehaviour
{
    [SerializeField]
    private TextMeshProUGUI Counter123;
    private bool resumeIn3Seconds = true;

    public string text1 = "Three", text2 = "Two", text3 = "One";

    void Update()
    {
        ResumeIn3Seconds();
    }

    void ResumeIn3Seconds()
    {
        if (resumeIn3Seconds)
        {
            StartCoroutine(ResumeAfterSeconds(3.5f));
        }
    }

    private IEnumerator ResumeAfterSeconds(float resumetime) // 3
    {
        Time.timeScale = 0.0001f;
        float pauseEndTime = Time.realtimeSinceStartup + resumetime; // 10 + 4 = 13

        float number3 = Time.realtimeSinceStartup + 1.5f; // 10 + 1 = 11
        float number2 = Time.realtimeSinceStartup + 3; // 10 + 2 = 12
        float number1 = Time.realtimeSinceStartup + 3.5f; // 10 + 3 = 13

        while (Time.realtimeSinceStartup < pauseEndTime) // 10 < 13
        {
            if (Time.realtimeSinceStartup <= number3)      // 10 < 11
                Counter123.text = text1;
            else if (Time.realtimeSinceStartup <= number2) // 11 < 12
                Counter123.text = text2;
            else if (Time.realtimeSinceStartup <= number1) // 12 < 13
                Counter123.text = text3;

            yield return null;
        }
        Counter123.enabled = false;
        resumeIn3Seconds = false;
        Time.timeScale = 1;
    }
}
