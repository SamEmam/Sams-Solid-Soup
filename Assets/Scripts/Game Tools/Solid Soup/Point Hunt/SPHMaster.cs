using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class SPHMaster : MonoBehaviour
{
    public TextMeshProUGUI pointHuntText;
    public GameObject point;
    public Transform[] spawnPositions;
    private float timeBeforeEnd = 2f;
    private float gameCounter;
    private float spawnCounter;
    private float spawnInterval = 8f;
    private bool hasEnded = false;
    private SceneLoader sceneLoader;
    [HideInInspector]
    public List<GameObject> spawnedPoints = new List<GameObject>();

    [SerializeField]
    private int spawnAttempts = 0;

    private void Start()
    {
        sceneLoader = GetComponent<SceneLoader>();
        gameCounter = timeBeforeEnd * 60;
        spawnInterval -= 0.5f * GamePrefs.TotalPlayerCount;
    }

    private void Update()
    {
        if (hasEnded)
        {
            return;
        }
        gameCounter -= Time.deltaTime;
        spawnCounter -= Time.deltaTime;

        if (spawnCounter <= 0)
        {
            SpawnPoint();
            spawnCounter = spawnInterval;
        }

        if (gameCounter <= 0)
        {
            // End Game
            hasEnded = true;
            pointHuntText.text = "Game Over!";
            StartCoroutine(EndScene());
            return;

        }
        else
        {
            var sec = gameCounter % 60;
            var min = gameCounter / 60;

            if (sec < 10)
            {

                pointHuntText.text = (int)min + ":0" + (int)sec;
            }
            else
            {
                pointHuntText.text = (int)min + ":" + (int)sec;
            }
        }
    }

    void SpawnPoint()
    {
        if (spawnAttempts >= 10)
        {
            spawnAttempts = 0;
            Debug.Log("10 Attemps used, not spawning");
            return;
        }
        //var spawnOffset = new Vector3(Random.Range(-2, 2), 0, Random.Range(-2, 2));
        var positionToSpawn = spawnPositions[Random.Range(0, spawnPositions.Length - 1)].position;


        // Check if it colliders with a previously instantiated point
        foreach (var spawn in spawnedPoints)
        {
            if (!spawn)
            {
                spawnedPoints.Remove(spawn);
                spawnAttempts++;
                SpawnPoint();
                return;
            }
            if (spawn.transform.position == positionToSpawn)
            {
                Debug.Log("Spawn position occupied: " + spawnAttempts);
                spawnAttempts++;
                SpawnPoint();
                return;
            }
        }
        
        spawnAttempts = 0;
        var spawnedPoint = Instantiate(point, positionToSpawn, Quaternion.identity);
        spawnedPoints.Add(spawnedPoint);
    }

    IEnumerator EndScene()
    {
        foreach (var point in spawnedPoints)
        {
            if (point)
            {
                Destroy(point);
            }
        }
        yield return new WaitForSeconds(5);
        sceneLoader.LoadSceneByIndex(4);
    }
}
