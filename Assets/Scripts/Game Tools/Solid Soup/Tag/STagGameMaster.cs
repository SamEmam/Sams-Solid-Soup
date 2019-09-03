using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class STagGameMaster : MonoBehaviour
{
    public RVehicleTypeSelector[] vehicles;
    [HideInInspector]
    public List<STagPlayerMaster> tagPlayers = new List<STagPlayerMaster>();
    public Transform tagObject;
    [HideInInspector]
    public Transform tagPosition;

    public TextMeshProUGUI tagText;
    private SceneLoader sceneLoader;

    private float timeBeforeStart = 6f;
    private float timeBeforeEnd = 2f;
    private float counter;
    private bool hasStarted = false;
    private bool hasEnded = false;

    private void Start()
    {
        sceneLoader = GetComponent<SceneLoader>();
        timeBeforeEnd *= 60;
        counter = timeBeforeStart;
        foreach (var vehicle in vehicles)
        {
            if (vehicle.gameObject.activeInHierarchy)
            {
                tagPlayers.Add(vehicle.GetVehicle().GetComponent<STagPlayerMaster>());
            }
        }

        foreach (var player in tagPlayers)
        {
            player.GM = this;
        }
    }
    

    private void Update()
    {
        if (hasEnded)
        {
            return;
        }
        counter -= Time.deltaTime;
        
        if (!hasStarted)
        {
            if (counter <= 0)
            {
                RandomTag();
                hasStarted = true;
                counter = timeBeforeEnd;
                foreach (var player in tagPlayers)
                {
                    player.AddPoints();
                }
            }
            else
            {
                tagText.text = "Random tag in: 0" + (int)counter;
                return;
            }
        }
        else if (counter <= 0)
        {
            // End Game
            hasEnded = true;
            tagText.text = "Game Over!";
            StartCoroutine(EndScene());
            tagObject.position = Vector3.up * 100;

        }
        else
        {
            var sec = counter % 60;
            var min = counter / 60;

            if (sec < 10)
            {

                tagText.text = (int)min + ":0" + (int)sec;
            }
            else
            {
                tagText.text = (int)min + ":" + (int)sec;
            }
        }


        if (tagPosition)
        {
            tagObject.position = tagPosition.position + (Vector3.up * 15);
        }
        else
        {
            tagObject.position = Vector3.up * 100;
        }
    }

    public void UntagAll()
    {
        foreach (var player in tagPlayers)
        {
            player.isTagged = false;
        }
    }

    void RandomTag()
    {
        var rng = Random.Range(0, tagPlayers.Count);
        tagPlayers[rng].GetTagged();
    }

    IEnumerator EndScene()
    {
        foreach (var player in tagPlayers)
        {
            if (!player.isTagged)
            {
                player.gameObject.SetActive(false);
            }
        }
        yield return new WaitForSeconds(5);
        sceneLoader.LoadSceneByIndex(4);
    }
}
