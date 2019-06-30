using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RResetManager : MonoBehaviour
{
    public RGameMaster GM;
    public Transform spawnPoint;
    
    private List<Vector3> spawnPositions;

    // ReEnables player GameObjects, recalculates playersleft and resets alive booleans
    public void ResetPlayers()
    {
        GM.playersLeft = 0;
        Debug.Log("RM ResetPlayers");
        if (GamePrefs.Player1)
        {
            GM.p1.SetActive(true);
            GM.playersLeft++;
            GM.p1Alive = true;
        }
        if (GamePrefs.Player2)
        {
            GM.p2.SetActive(true);
            GM.playersLeft++;
            GM.p2Alive = true;
        }
        if (GamePrefs.Player3)
        {
            GM.p3.SetActive(true);
            GM.playersLeft++;
            GM.p3Alive = true;
        }
        if (GamePrefs.Player4)
        {
            GM.p4.SetActive(true);
            GM.playersLeft++;
            GM.p4Alive = true;
        }
        if (GamePrefs.Player5)
        {
            GM.p5.SetActive(true);
            GM.playersLeft++;
            GM.p5Alive = true;
        }
        if (GamePrefs.Player6)
        {
            GM.p6.SetActive(true);
            GM.playersLeft++;
            GM.p6Alive = true;
        }
        if (GamePrefs.Player7)
        {
            GM.p7.SetActive(true);
            GM.playersLeft++;
            GM.p7Alive = true;
        }
        if (GamePrefs.Player8)
        {
            GM.p8.SetActive(true);
            GM.playersLeft++;
            GM.p8Alive = true;
        }
    }

    // Recalculates spawnpositions, shuffles positions and respawns players at positions
    public void Respawn()
    {
        spawnPositions = new List<Vector3>();
        switch (GM.totalPlayers)
        {
            case 1:
                spawnPositions.Add(spawnPoint.position + (spawnPoint.forward * -2) + (spawnPoint.right * -2));
                break;
            case 2:
                spawnPositions.Add(spawnPoint.position + (spawnPoint.forward * -2) + (spawnPoint.right * -2));
                spawnPositions.Add(spawnPoint.position + (spawnPoint.forward * -2) + (spawnPoint.right * 2));
                break;
            case 3:
                spawnPositions.Add(spawnPoint.position + (spawnPoint.forward * -2) + (spawnPoint.right * -2));
                spawnPositions.Add(spawnPoint.position + (spawnPoint.forward * -2) + (spawnPoint.right * 2));
                spawnPositions.Add(spawnPoint.position + (spawnPoint.forward * -10) + (spawnPoint.right * -2));
                break;
            case 4:
                spawnPositions.Add(spawnPoint.position + (spawnPoint.forward * -2) + (spawnPoint.right * -2));
                spawnPositions.Add(spawnPoint.position + (spawnPoint.forward * -2) + (spawnPoint.right * 2));
                spawnPositions.Add(spawnPoint.position + (spawnPoint.forward * -10) + (spawnPoint.right * -2));
                spawnPositions.Add(spawnPoint.position + (spawnPoint.forward * -10) + (spawnPoint.right * 2));
                break;
            case 5:
                spawnPositions.Add(spawnPoint.position + (spawnPoint.forward * -2) + (spawnPoint.right * -2));
                spawnPositions.Add(spawnPoint.position + (spawnPoint.forward * -2) + (spawnPoint.right * 2));
                spawnPositions.Add(spawnPoint.position + (spawnPoint.forward * -10) + (spawnPoint.right * -2));
                spawnPositions.Add(spawnPoint.position + (spawnPoint.forward * -10) + (spawnPoint.right * 2));
                spawnPositions.Add(spawnPoint.position + (spawnPoint.forward * -18) + (spawnPoint.right * -2));
                break;
            case 6:
                spawnPositions.Add(spawnPoint.position + (spawnPoint.forward * -2) + (spawnPoint.right * -2));
                spawnPositions.Add(spawnPoint.position + (spawnPoint.forward * -2) + (spawnPoint.right * 2));
                spawnPositions.Add(spawnPoint.position + (spawnPoint.forward * -10) + (spawnPoint.right * -2));
                spawnPositions.Add(spawnPoint.position + (spawnPoint.forward * -10) + (spawnPoint.right * 2));
                spawnPositions.Add(spawnPoint.position + (spawnPoint.forward * -18) + (spawnPoint.right * -2));
                spawnPositions.Add(spawnPoint.position + (spawnPoint.forward * -18) + (spawnPoint.right * 2));
                break;
            case 7:
                spawnPositions.Add(spawnPoint.position + (spawnPoint.forward * -2) + (spawnPoint.right * -2));
                spawnPositions.Add(spawnPoint.position + (spawnPoint.forward * -2) + (spawnPoint.right * 2));
                spawnPositions.Add(spawnPoint.position + (spawnPoint.forward * -10) + (spawnPoint.right * -2));
                spawnPositions.Add(spawnPoint.position + (spawnPoint.forward * -10) + (spawnPoint.right * 2));
                spawnPositions.Add(spawnPoint.position + (spawnPoint.forward * -18) + (spawnPoint.right * -2));
                spawnPositions.Add(spawnPoint.position + (spawnPoint.forward * -18) + (spawnPoint.right * 2));
                spawnPositions.Add(spawnPoint.position + (spawnPoint.forward * -26) + (spawnPoint.right * -2));
                break;
            case 8:
                spawnPositions.Add(spawnPoint.position + (spawnPoint.forward * -2) + (spawnPoint.right * -2));
                spawnPositions.Add(spawnPoint.position + (spawnPoint.forward * -2) + (spawnPoint.right * 2));
                spawnPositions.Add(spawnPoint.position + (spawnPoint.forward * -10) + (spawnPoint.right * -2));
                spawnPositions.Add(spawnPoint.position + (spawnPoint.forward * -10) + (spawnPoint.right * 2));
                spawnPositions.Add(spawnPoint.position + (spawnPoint.forward * -18) + (spawnPoint.right * -2));
                spawnPositions.Add(spawnPoint.position + (spawnPoint.forward * -18) + (spawnPoint.right * 2));
                spawnPositions.Add(spawnPoint.position + (spawnPoint.forward * -26) + (spawnPoint.right * -2));
                spawnPositions.Add(spawnPoint.position + (spawnPoint.forward * -26) + (spawnPoint.right * 2));
                break;
            default:
                spawnPositions.Add(spawnPoint.position + (spawnPoint.forward * -2) + (spawnPoint.right * -2));
                spawnPositions.Add(spawnPoint.position + (spawnPoint.forward * -2) + (spawnPoint.right * 2));
                spawnPositions.Add(spawnPoint.position + (spawnPoint.forward * -10) + (spawnPoint.right * -2));
                spawnPositions.Add(spawnPoint.position + (spawnPoint.forward * -10) + (spawnPoint.right * 2));
                spawnPositions.Add(spawnPoint.position + (spawnPoint.forward * -18) + (spawnPoint.right * -2));
                spawnPositions.Add(spawnPoint.position + (spawnPoint.forward * -18) + (spawnPoint.right * 2));
                spawnPositions.Add(spawnPoint.position + (spawnPoint.forward * -26) + (spawnPoint.right * -2));
                spawnPositions.Add(spawnPoint.position + (spawnPoint.forward * -26) + (spawnPoint.right * 2));
                break;
        }

        for (int i = 0; i < spawnPositions.Count; i++)
        {
            Vector3 temp = spawnPositions[i];
            int randomIndex = Random.Range(i, spawnPositions.Count);
            spawnPositions[i] = spawnPositions[randomIndex];
            spawnPositions[randomIndex] = temp;
        }

        if (GamePrefs.Player1)
        {
            GM.p1.transform.position = spawnPositions[0];
            GM.p1.transform.rotation = spawnPoint.rotation;
            var p1RB = GM.p1.GetComponent<Rigidbody>();
            p1RB.velocity = Vector3.zero;
            p1RB.angularVelocity = Vector3.zero;
        }
        if (GamePrefs.Player2)
        {
            GM.p2.transform.position = spawnPositions[1];
            GM.p2.transform.rotation = spawnPoint.rotation;
            var p2RB = GM.p2.GetComponent<Rigidbody>();
            p2RB.velocity = Vector3.zero;
            p2RB.angularVelocity = Vector3.zero;
        }
        if (GamePrefs.Player3)
        {
            GM.p3.transform.position = spawnPositions[2];
            GM.p3.transform.rotation = spawnPoint.rotation;
            var p3RB = GM.p3.GetComponent<Rigidbody>();
            p3RB.velocity = Vector3.zero;
            p3RB.angularVelocity = Vector3.zero;
        }
        if (GamePrefs.Player4)
        {
            GM.p4.transform.position = spawnPositions[3];
            GM.p4.transform.rotation = spawnPoint.rotation;
            var p4RB = GM.p4.GetComponent<Rigidbody>();
            p4RB.velocity = Vector3.zero;
            p4RB.angularVelocity = Vector3.zero;
        }
        if (GamePrefs.Player5)
        {
            GM.p5.transform.position = spawnPositions[4];
            GM.p5.transform.rotation = spawnPoint.rotation;
            var p5RB = GM.p5.GetComponent<Rigidbody>();
            p5RB.velocity = Vector3.zero;
            p5RB.angularVelocity = Vector3.zero;
        }
        if (GamePrefs.Player6)
        {
            GM.p6.transform.position = spawnPositions[5];
            GM.p6.transform.rotation = spawnPoint.rotation;
            var p6RB = GM.p6.GetComponent<Rigidbody>();
            p6RB.velocity = Vector3.zero;
            p6RB.angularVelocity = Vector3.zero;
        }
        if (GamePrefs.Player7)
        {
            GM.p7.transform.position = spawnPositions[6];
            GM.p7.transform.rotation = spawnPoint.rotation;
            var p7RB = GM.p7.GetComponent<Rigidbody>();
            p7RB.velocity = Vector3.zero;
            p7RB.angularVelocity = Vector3.zero;
        }
        if (GamePrefs.Player8)
        {
            GM.p8.transform.position = spawnPositions[7];
            GM.p8.transform.rotation = spawnPoint.rotation;
            var p8RB = GM.p8.GetComponent<Rigidbody>();
            p8RB.velocity = Vector3.zero;
            p8RB.angularVelocity = Vector3.zero;
        }
    }

    // Disables player GameObject and alive boolean
    public void UnAlivePlayer(RPlayerScore ps)
    {
        switch (ps.playerNum)
        {
            case 1:
                GM.p1Alive = false;
                GM.p1.SetActive(false);
                break;
            case 2:
                GM.p2Alive = false;
                GM.p2.SetActive(false);
                break;
            case 3:
                GM.p3Alive = false;
                GM.p3.SetActive(false);
                break;
            case 4:
                GM.p4Alive = false;
                GM.p4.SetActive(false);
                break;
            case 5:
                GM.p5Alive = false;
                GM.p5.SetActive(false);
                break;
            case 6:
                GM.p6Alive = false;
                GM.p6.SetActive(false);
                break;
            case 7:
                GM.p7Alive = false;
                GM.p7.SetActive(false);
                break;
            case 8:
                GM.p8Alive = false;
                GM.p8.SetActive(false);
                break;
        }
    }

    // Disables all player powerups
    public void ResetPowerups()
    {
        if (GamePrefs.Player1)
        {
            GM.p1Power.DisableAll();
        }
        if (GamePrefs.Player2)
        {
            GM.p2Power.DisableAll();
        }
        if (GamePrefs.Player3)
        {
            GM.p3Power.DisableAll();
        }
        if (GamePrefs.Player4)
        {
            GM.p4Power.DisableAll();
        }
        if (GamePrefs.Player5)
        {
            GM.p5Power.DisableAll();
        }
        if (GamePrefs.Player6)
        {
            GM.p6Power.DisableAll();
        }
        if (GamePrefs.Player7)
        {
            GM.p7Power.DisableAll();
        }
        if (GamePrefs.Player8)
        {
            GM.p8Power.DisableAll();
        }
    }
}
