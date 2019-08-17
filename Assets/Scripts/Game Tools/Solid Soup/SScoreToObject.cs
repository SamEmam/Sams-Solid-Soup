using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SScoreToObject : MonoBehaviour
{
    public Transform scorePos;
    public GameObject[] charObjArray;
    public Material[] materials;

    private int playerNum;
    private string playerString;
    private Material objColor;

    private void OnEnable()
    {
        playerNum = GetComponent<RVehicleTypeSelector>().GetPlayerNum();
        
        switch (playerNum)
        {
            case 1:
                SetMaterial((int)GamePrefs.P1Color);
                playerString = GamePrefs.Player1Score.ToString();
                break;
            case 2:
                SetMaterial((int)GamePrefs.P2Color);
                playerString = GamePrefs.Player2Score.ToString();
                break;
            case 3:
                SetMaterial((int)GamePrefs.P3Color);
                playerString = GamePrefs.Player3Score.ToString();
                break;
            case 4:
                SetMaterial((int)GamePrefs.P4Color);
                playerString = GamePrefs.Player4Score.ToString();
                break;
            case 5:
                SetMaterial((int)GamePrefs.P5Color);
                playerString = GamePrefs.Player5Score.ToString();
                break;
            case 6:
                SetMaterial((int)GamePrefs.P6Color);
                playerString = GamePrefs.Player6Score.ToString();
                break;
            case 7:
                SetMaterial((int)GamePrefs.P7Color);
                playerString = GamePrefs.Player7Score.ToString();
                break;
            case 8:
                SetMaterial((int)GamePrefs.P8Color);
                playerString = GamePrefs.Player8Score.ToString();
                break;
        }

        StringToCharArray(playerString, scorePos);
    }

    void SetMaterial(int index)
    {
        objColor = materials[index];
    }

    void StringToCharArray(string scoreString, Transform position)
    {
        int temp;
        Vector3 offset = Vector3.forward;
        char[] scoreCharArray = scoreString.ToCharArray();

        for (int i = 0; i < scoreCharArray.Length; i++)
        {
            temp = (int)System.Char.GetNumericValue(scoreCharArray[i]);
            GameObject instantiatedNum = Instantiate(charObjArray[temp], position.position + offset, position.rotation);
            instantiatedNum.GetComponent<MeshRenderer>().material = objColor;
            offset += Vector3.forward * 3;
        }

    }
}
