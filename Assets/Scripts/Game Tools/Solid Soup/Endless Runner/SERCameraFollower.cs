using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SERCameraFollower : MonoBehaviour
{
    public Camera mainCam;
    public bool IncreaseDifficultyOverTime = false;
    [Range(1,5)]
    public int difficultyLevel = 3;
    private float additionalDistance = 0f;
    private float startTime;

    private void Start()
    {
        startTime = Time.time;
        difficultyLevel = 5 - difficultyLevel;
    }

    private void Update()
    {
        var zPos = mainCam.transform.position.z;

        if (IncreaseDifficultyOverTime)
        {
            zPos += additionalDistance;
            additionalDistance += (Time.time - startTime) / (difficultyLevel * 10000);
        }

        transform.position = new Vector3(transform.position.x, transform.position.y, zPos);
    }
}
