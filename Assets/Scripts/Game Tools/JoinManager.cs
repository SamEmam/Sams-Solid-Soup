using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using XboxCtrlrInput;
using TMPro;
using UnityEngine.UI;

public class JoinManager : MonoBehaviour
{
    public TextMeshProUGUI pressAToJoin;
    public Image playerImage;
    public int playerNum;
    public XboxController controller;
    private bool hasJoined = false;

    // Start is called before the first frame update
    void Start()
    {
        playerImage.gameObject.SetActive(false);
        pressAToJoin.gameObject.SetActive(true);
        
    }

    // Update is called once per frame
    void Update()
    {
        if (hasJoined)
        {
            return;
        }

        if (XCI.GetButtonDown(XboxButton.A, controller))
        {
            hasJoined = true;
            playerImage.gameObject.SetActive(true);
            pressAToJoin.gameObject.SetActive(false);
            JoinPlayer(playerNum);
        }
    }

    void JoinPlayer(int playerNum)
    {
        switch (playerNum)
        {
            case 1:
                GamePrefs.Player1 = true;
                break;
            case 2:
                GamePrefs.Player2 = true;
                break;
            case 3:
                GamePrefs.Player3 = true;
                break;
            case 4:
                GamePrefs.Player4 = true;
                break;
        }
    }
}
