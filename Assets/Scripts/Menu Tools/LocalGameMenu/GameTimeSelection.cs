using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.Events;
using UnityEngine.UI;
using Rewired;
using TMPro;

public class GameTimeSelection : MonoBehaviour
{
    private Player player;

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
        player = ReInput.players.GetPlayer(1);
        isSelected = false;
        BuildNumbers();
    }

    // Update is called once per frame
    void Update()
    {
        if (player.GetButtonDown("Start"))
        {
            GamePrefs.GameTime = time * 60;
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
            IncreaseTime();
            BuildNumbers();
        }

        if (player.GetButtonDown("Left"))
        {
            DecreaseTime();
            BuildNumbers();
        }

        if (player.GetButtonDown("Up"))
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

        if (player.GetButtonDown("Down"))
        {
            isSelected = false;
            cooldown = 0.2f;
            gameModeSelector.isSelected = true;
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
