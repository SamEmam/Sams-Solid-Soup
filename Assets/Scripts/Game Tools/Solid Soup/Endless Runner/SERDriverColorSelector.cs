using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SERDriverColorSelector : MonoBehaviour
{


    public SkinnedMeshRenderer mesh;
    public Material[] materials;
    private int playerNum;


    private void OnEnable()
    {
        playerNum = GetComponent<RPlayerScore>().playerNum;
        SetupPlayerColor(playerNum);
    }

    void SetupPlayerColor(int player)
    {
        switch (player)
        {
            case 1:
                mesh.material = materials[(int)GamePrefs.P1Color];
                break;
            case 2:
                mesh.material = materials[(int)GamePrefs.P2Color];
                break;
            case 3:
                mesh.material = materials[(int)GamePrefs.P3Color];
                break;
            case 4:
                mesh.material = materials[(int)GamePrefs.P4Color];
                break;
            case 5:
                mesh.material = materials[(int)GamePrefs.P5Color];
                break;
            case 6:
                mesh.material = materials[(int)GamePrefs.P6Color];
                break;
            case 7:
                mesh.material = materials[(int)GamePrefs.P7Color];
                break;
            case 8:
                mesh.material = materials[(int)GamePrefs.P8Color];
                break;

        }
    }
}
