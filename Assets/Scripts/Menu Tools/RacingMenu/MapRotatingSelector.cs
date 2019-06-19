using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Rewired;

public class MapRotatingSelector : MonoBehaviour
{
    private Player player;

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
        player = ReInput.players.GetPlayer(1);
        transform.rotation = Quaternion.Euler(0, 0, 0);
    }

    // Update is called once per frame
    void Update()
    {
        if (player.GetButtonDown("Select"))
        {
            GamePrefs.RaceMapEnum = (RaceMapEnum)mapIndex;
        }

        if (player.GetButtonDown("Right"))
        {
            RotRight();
        }

        if (player.GetButtonDown("Left"))
        {
            RotLeft();
        }

        UpdateRotation();
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
