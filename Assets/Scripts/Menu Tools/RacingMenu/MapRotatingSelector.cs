using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using XboxCtrlrInput;

public class MapRotatingSelector : MonoBehaviour
{
    [SerializeField]
    private XboxController controller;
    [SerializeField]
    private int rotInterval = 45;
    [SerializeField]
    private int mapCount;
    [SerializeField]
    private int rotSpeed;

    private Quaternion targetAngle;
    private int mapIndex;

    // Start is called before the first frame update
    void Start()
    {
        transform.rotation = Quaternion.Euler(0, 0, 0);
    }

    // Update is called once per frame
    void Update()
    {
        if (XCI.GetButtonDown(XboxButton.DPadRight, controller))
        {
            RotRight();
        }

        if (XCI.GetButtonDown(XboxButton.DPadLeft, controller))
        {
            RotLeft();
        }

        if (XCI.GetButtonDown(XboxButton.A, controller))
        {
            GamePrefs.RaceMapEnum = (RaceMapEnum)mapIndex;
            // SceneLoader launch Ruthless Race
        }

        UpdateRotation();
    }

    void StartRace()
    {

    }

    void RotRight()
    {
        if (mapIndex == mapCount - 1)
        {
            mapIndex = 0;
        }
        else
        {
            mapIndex++;
        }

        targetAngle = Quaternion.Euler(0, mapIndex * rotInterval, 0);

    }

    void RotLeft()
    {
        if (mapIndex == 0)
        {
            mapIndex = mapCount - 1;
        }
        else
        {
            mapIndex--;
        }

        targetAngle = Quaternion.Euler(0, mapIndex * rotInterval, 0);

    }

    void UpdateRotation()
    {
        transform.rotation = Quaternion.Lerp(transform.rotation, targetAngle, 0.1f);
    }
}
