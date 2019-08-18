using Rewired;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameSoupModeSelection : MonoBehaviour
{
    private Player player;

    [SerializeField]
    private GameObject[] soupModes;

    private bool withSplit;

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

    private void Start()
    {
        withSplit = GamePrefs.WithSplit;
        player = ReInput.players.GetPlayer(1);
        isSelected = false;
        EnableSoupMode(withSplit);
    }
    

    void Update()
    {
        if (player.GetButtonDown("Start"))
        {
            GamePrefs.WithSplit = withSplit;
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

        if (player.GetButtonDown("Right") || player.GetButtonDown("Left"))
        {
            NextSoupMode();
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

    void NextSoupMode()
    {
        if (withSplit)
        {
            withSplit = false;
        }
        else
        {
            withSplit = true;
        }

        EnableSoupMode(withSplit);
    }

    void EnableSoupMode(bool mode)
    {
        if (mode)
        {
            soupModes[0].SetActive(true);
            soupModes[1].SetActive(false);
        }
        else
        {
            soupModes[1].SetActive(true);
            soupModes[0].SetActive(false);
        }

    }

    void DisableSoupMode()
    {

        soupModes[0].SetActive(false);
        soupModes[1].SetActive(false);
    }
}
