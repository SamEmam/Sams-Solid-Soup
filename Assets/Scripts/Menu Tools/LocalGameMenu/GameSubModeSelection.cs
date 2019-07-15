using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.Events;
using UnityEngine.UI;
using Rewired;
using TMPro;

public class GameSubModeSelection : MonoBehaviour
{
    private Player player;

    [SerializeField]
    private GameObject[] subModes;

    private int subModeIndex;

    [SerializeField]
    private TextObjectColoring textObjectColoring;

    [SerializeField]
    private Material defaultMat, selectedMat;

    [SerializeField]
    private GameModeSelection gameModeSelector;
    [SerializeField]
    private GameTimeSelection timeSelector;

    public bool isSelected;

    private float cooldown = 0.2f;


    // Start is called before the first frame update
    void Start()
    {
        subModeIndex = (int)GamePrefs.SubMode;
        player = ReInput.players.GetPlayer(1);
        isSelected = false;
        EnableSubMode(subModeIndex);
    }

    // Update is called once per frame
    void Update()
    {
        if (player.GetButtonDown("Start"))
        {
            GamePrefs.SubMode = (SubModeEnum)subModeIndex;
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

        if (player.GetButtonDown("Right"))
        {
            NextSubMode();
        }

        if (player.GetButtonDown("Left"))
        {
            PrevSubMode();
        }

        if (player.GetButtonDown("Up"))
        {
            isSelected = false;
            cooldown = 0.2f;
            gameModeSelector.isSelected = true;
        }

        if (player.GetButtonDown("Down"))
        {
            isSelected = false;
            cooldown = 0.2f;
            timeSelector.isSelected = true;
        }
    }

    void NextSubMode()
    {
        if (subModeIndex == subModes.Length - 1)
        {
            subModeIndex = 0;
        }
        else
        {
            subModeIndex++;
        }

        EnableSubMode(subModeIndex);
    }

    void PrevSubMode()
    {
        if (subModeIndex == 0)
        {
            subModeIndex = subModes.Length - 1;
        }
        else
        {
            subModeIndex--;
        }

        EnableSubMode(subModeIndex);
    }

    void EnableSubMode(int index)
    {
        DisableSubModes();
        subModes[index].SetActive(true);
    }

    void DisableSubModes()
    {
        foreach (var subMode in subModes)
        {
            subMode.SetActive(false);
        }
    }
}
