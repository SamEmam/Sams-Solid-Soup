using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SSBColorSelector : MonoBehaviour
{
    [SerializeField]
    private GameObject[] colors;

    private GameObject spawnedShip;
    

    public GameObject LoadColor(int playerNum)
    {
        switch (playerNum)
        {
            case 1:
                SpawnShip((int)GamePrefs.P1Color);
                break;
            case 2:
                SpawnShip((int)GamePrefs.P2Color);
                break;
            case 3:
                SpawnShip((int)GamePrefs.P3Color);
                break;
            case 4:
                SpawnShip((int)GamePrefs.P4Color);
                break;
            case 5:
                SpawnShip((int)GamePrefs.P5Color);
                break;
            case 6:
                SpawnShip((int)GamePrefs.P6Color);
                break;
            case 7:
                SpawnShip((int)GamePrefs.P7Color);
                break;
            case 8:
                SpawnShip((int)GamePrefs.P8Color);
                break;
            default:
                SpawnShip(0);
                break;
        }

        return GetColorObject();
    }

    void SpawnShip(int index)
    {
        if (index > colors.Length - 1)
        {
            index = 0;
        }

        // ^ temp
        spawnedShip = Instantiate(colors[index], transform.position, transform.rotation);
    }

    GameObject GetColorObject()
    {
        return spawnedShip;
    }
}
