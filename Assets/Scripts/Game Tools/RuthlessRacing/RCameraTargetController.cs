﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RCameraTargetController : MonoBehaviour
{
    [SerializeField]
    private CameraMultiTarget cameraMultiTarget;
    public List<GameObject> targets;

    private int playerCount;

    private void LateUpdate()
    {
        if (playerCount != GameObject.FindGameObjectsWithTag("Player").Length)
        {
            UpdateTargets();
        }
        
    }

    void UpdateTargets()
    {
        targets = new List<GameObject>();
        targets.AddRange(GameObject.FindGameObjectsWithTag("Player"));
        targets.AddRange(GameObject.FindGameObjectsWithTag("Objective"));

        playerCount = targets.Count;

        if (targets.Count == 0)
        {
            return;
        }
        cameraMultiTarget.SetTargets(targets.ToArray());
    }
}
