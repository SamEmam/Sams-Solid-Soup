using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class RPauseBeforeStart : MonoBehaviour
{
    [SerializeField]
    private TextMeshProUGUI Counter123;
    private bool resumeIn3Seconds = true;

    void Update()
    {
        ResumeIn3Seconds();
    }

    void ResumeIn3Seconds()
    {
        if (resumeIn3Seconds)
        {
            StartCoroutine(ResumeAfterSeconds(3));
        }
    }

    private IEnumerator ResumeAfterSeconds(int resumetime) // 3
    {
        Time.timeScale = 0.0001f;
        float pauseEndTime = Time.realtimeSinceStartup + resumetime; // 10 + 4 = 13

        float number3 = Time.realtimeSinceStartup + 1; // 10 + 1 = 11
        float number2 = Time.realtimeSinceStartup + 2; // 10 + 2 = 12
        float number1 = Time.realtimeSinceStartup + 3; // 10 + 3 = 13

        while (Time.realtimeSinceStartup < pauseEndTime) // 10 < 13
        {
            if (Time.realtimeSinceStartup <= number3)      // 10 < 11
                Counter123.text = "Three";
            else if (Time.realtimeSinceStartup <= number2) // 11 < 12
                Counter123.text = "Two";
            else if (Time.realtimeSinceStartup <= number1) // 12 < 13
                Counter123.text = "One";

            yield return null;
        }
        Counter123.enabled = false;
        resumeIn3Seconds = false;
        Time.timeScale = 1;
    }
}
