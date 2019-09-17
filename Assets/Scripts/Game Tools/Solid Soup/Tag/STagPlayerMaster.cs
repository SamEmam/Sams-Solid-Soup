using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class STagPlayerMaster : MonoBehaviour
{
    [HideInInspector]
    public bool isTagged;
    [HideInInspector]
    public STagGameMaster GM;

    public Transform runnerTag;
    public GameObject boost;

    [HideInInspector]
    public bool canBeTagged = true;
    private float counter;
    private float braceTime = 2f;
    private int playerNum;
    private int points;

    private void Awake()
    {
        playerNum = GetComponent<RPlayerScore>().playerNum;
        points = GamePrefs.TotalPlayerCount / 2;
    }

    private void OnDisable()
    {
        boost.SetActive(false);
        runnerTag.position = transform.position + (Vector3.up * 15);
    }


    private void Update()
    {

        if (isTagged)
        {
            boost.SetActive(true);
            runnerTag.position = Vector3.up * 100;
            return;
        }

        boost.SetActive(false);
        runnerTag.position = transform.position + (Vector3.up * 15);

        if (canBeTagged)
        {
            return;
        }

        if (counter < 0f)
        {
            canBeTagged = true;
        }
        else
        {
            counter -= Time.deltaTime;
        }

        
    }

    public void GetTagged()
    {
        GM.tagPosition = transform;
        isTagged = true;
        SubtractPoints();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (!isTagged)
        {
            return;
        }

        if (other.tag == "Player")
        {
            var otherTag = other.gameObject.GetComponent<STagPlayerMaster>();
            if (!otherTag.canBeTagged)
            {
                return;
            }
            canBeTagged = false;
            isTagged = false;
            counter = braceTime;
            Debug.Log(other.name);
            otherTag.GetTagged();
            AddPoints();
        }
    }

    public void AddPoints()
    {
        switch (playerNum)
        {
            case 1:
                GamePrefs.Player1Score += points;
                break;
            case 2:
                GamePrefs.Player2Score += points;
                break;
            case 3:
                GamePrefs.Player3Score += points;
                break;
            case 4:
                GamePrefs.Player4Score += points;
                break;
            case 5:
                GamePrefs.Player5Score += points;
                break;
            case 6:
                GamePrefs.Player6Score += points;
                break;
            case 7:
                GamePrefs.Player7Score += points;
                break;
            case 8:
                GamePrefs.Player8Score += points;
                break;
        }
    }

    public void SubtractPoints()
    {
        switch (playerNum)
        {
            case 1:
                GamePrefs.Player1Score -= points;
                break;
            case 2:
                GamePrefs.Player2Score -= points;
                break;
            case 3:
                GamePrefs.Player3Score -= points;
                break;
            case 4:
                GamePrefs.Player4Score -= points;
                break;
            case 5:
                GamePrefs.Player5Score -= points;
                break;
            case 6:
                GamePrefs.Player6Score -= points;
                break;
            case 7:
                GamePrefs.Player7Score -= points;
                break;
            case 8:
                GamePrefs.Player8Score -= points;
                break;
        }
    }

}
