﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.Events;
using UnityEngine.UI;
using XboxCtrlrInput;
using TMPro;

public class GameTimeSelection : MonoBehaviour
{
    [SerializeField]
    private XboxController controller;

    [SerializeField]
    private int time = 10;

    [SerializeField]
    private TextObjectColoring textObjectColoring;

    [SerializeField]
    private Material defaultMat, selectedMat;

    [SerializeField]
    private Transform spawnPos;

    [SerializeField]
    private GameObject[] charObjArray;

    private List<GameObject> spawnedObjs = new List<GameObject>();

    [SerializeField]
    private GameObject subMode;
    [SerializeField]
    private GameSubModeSelection subModeSelector;
    [SerializeField]
    private GameModeSelection gameModeSelector;

    public bool isSelected;

    private float cooldown = 0.2f;

    // Start is called before the first frame update
    void Start()
    {
        isSelected = false;
        BuildNumbers();
    }

    // Update is called once per frame
    void Update()
    {
        if (XCI.GetButtonDown(XboxButton.Start, controller))
        {
            GamePrefs.GameTime = time;
        }

        if (!isSelected)
        {
            if (textObjectColoring.GetMat() != defaultMat)
            {
                textObjectColoring.SetMat(defaultMat);
            }

            return;
        }

        if (cooldown > 0)
        {
            if (textObjectColoring.GetMat() != selectedMat)
            {
                textObjectColoring.SetMat(selectedMat);
            }

            cooldown -= Time.deltaTime;
            return;
        }

        if (XCI.GetButtonDown(XboxButton.DPadRight, controller))
        {
            IncreaseTime();
            BuildNumbers();
        }

        if (XCI.GetButtonDown(XboxButton.DPadLeft, controller))
        {
            DecreaseTime();
            BuildNumbers();
        }

        if (XCI.GetButtonDown(XboxButton.DPadDown, controller))
        {
            isSelected = false;
            cooldown = 0.2f;
            gameModeSelector.isSelected = true;
        }

        if (XCI.GetButtonDown(XboxButton.DPadUp, controller))
        {
            isSelected = false;
            cooldown = 0.2f;

            if (subMode.activeInHierarchy)
            {
                subModeSelector.isSelected = true;
            }
            else
            {
                gameModeSelector.isSelected = true;
            }
        }
        
    }

    void IncreaseTime()
    {
        if (time == 60)
        {
            return;
        }
        else
        {
            time += 5;
        }
    }

    void DecreaseTime()
    {
        if (time == 10)
        {
            return;
        }
        else
        {
            time -= 5;
        }
    }

    void BuildNumbers()
    {
        DestroyNumbers();
        StringToCharArray(time.ToString(), spawnPos);
    }

    void StringToCharArray(string numberString, Transform transform)
    {
        int temp;
        Vector3 offset = Vector3.back;
        char[] numberCharArray = numberString.ToCharArray();

        for (int i = 0; i < numberCharArray.Length; i++)
        {
            temp = (int)System.Char.GetNumericValue(numberCharArray[i]);
            var num = Instantiate(charObjArray[temp], transform.position + offset, transform.rotation);
            spawnedObjs.Add(num);
            offset += Vector3.back;
        }
    }

    void DestroyNumbers()
    {
        foreach (var objs in spawnedObjs)
        {
            Destroy(objs);
        }
    }
}
