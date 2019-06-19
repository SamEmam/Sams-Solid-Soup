using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.Events;
using UnityEngine.UI;
using Rewired;
using TMPro;

public class GameModeSelection : MonoBehaviour
{
    private Player player;

    [SerializeField]
    private TextObjectColoring textObjectColoring;

    [SerializeField]
    private Material defaultMat, selectedMat;

    [SerializeField]
    private GameObject[] gameModes;
    
    private int gameModeIndex = 0;

    [SerializeField]
    private GameObject subMode;
    [SerializeField]
    private GameSubModeSelection subModeSelector;
    [SerializeField]
    private GameTimeSelection timeSelector;

    public bool isSelected;

    private float cooldown = 0.2f;

    // Start is called before the first frame update
    void Start()
    {
        player = ReInput.players.GetPlayer(1);
        isSelected = true;
        EnableGameMode(gameModeIndex);
    }

    // Update is called once per frame
    void Update()
    {
        if (player.GetButtonDown("Start"))
        {
            GamePrefs.GameMode = (GameModeEnum)gameModeIndex;
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
            NextGameMode();
        }

        if (player.GetButtonDown("Left"))
        {
            PrevGameMode();
        }

        if (player.GetButtonDown("Up"))
        {
            isSelected = false;
            cooldown = 0.2f;
            timeSelector.isSelected = true;
        }

        if (player.GetButtonDown("Down"))
        {
            isSelected = false;
            cooldown = 0.2f;

            if (subMode.activeInHierarchy)
            {
                subModeSelector.isSelected = true;
            }
            else
            {
                timeSelector.isSelected = true;
            }
        }
    }

    void SubModeCheck()
    {
        if (gameModeIndex == 0)
        {
            subMode.SetActive(true);
        }
        else
        {
            subMode.SetActive(false);
        }
    }

    void NextGameMode()
    {
        if (gameModeIndex == gameModes.Length - 1)
        {
            gameModeIndex = 0;
        }
        else
        {
            gameModeIndex++;
        }
        EnableGameMode(gameModeIndex);
    }


    void PrevGameMode()
    {
        if (gameModeIndex == 0)
        {
            gameModeIndex = gameModes.Length - 1;
        }
        else
        {
            gameModeIndex--;
        }
        EnableGameMode(gameModeIndex);
    }



    void EnableGameMode(int index)
    {
        DisableGameModes();
        gameModes[index].SetActive(true);
        SubModeCheck();
    }

    void DisableGameModes()
    {
        foreach (var gameMode in gameModes)
        {
            gameMode.SetActive(false);
        }
    }

    
}
