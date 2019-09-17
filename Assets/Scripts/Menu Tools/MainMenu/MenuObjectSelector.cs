using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//using XboxCtrlrInput;
using Rewired;

public class MenuObjectSelector : MonoBehaviour
{
    [SerializeField]
    private TextObjectColoring[] textObjectColorings;
    [SerializeField]
    private TextExplosion[] textExplosions;
    [SerializeField]
    private Material defaultMat, selectedMat;

    private Player player;

    private int currentIndex;
    private float startTime;
    //private float runTime = 1.8f;
    private float runTime = 2.2f;

    public AudioClip[] clips;
    private AudioSource source;

    // Start is called before the first frame update
    void Start()
    {
        player = ReInput.players.GetPlayer(1);
        SelectIndex(currentIndex);
        startTime = Time.time;

        source = gameObject.AddComponent<AudioSource>();
        source.clip = clips[Random.Range(0, clips.Length - 1)];
    }

    // Update is called once per frame
    void Update()
    {
        if (Time.time - startTime < runTime)
        {
            return;
        }

        if (player.GetButtonDown("Select"))
        {
            source.Play();
            if (currentIndex != 2)
            {
                textExplosions[currentIndex].Explode();
                textObjectColorings[currentIndex].SwitchScene();
            }
            else
            {
                textObjectColorings[0].OpenSettings();
            }
        }

        if (player.GetButtonDown("Up"))
        {
            SelectUp();
        }

        if (player.GetButtonDown("Down"))
        {
            SelectDown();
        }
    }

    void SelectDown()
    {
        if (currentIndex == textObjectColorings.Length - 1)
        {
            SelectIndex(0);
        }
        else
        {
            SelectIndex(currentIndex + 1);
        }

        source.Play();
    }

    void SelectUp()
    {
        if (currentIndex == 0)
        {
            SelectIndex(textObjectColorings.Length - 1);
        }
        else
        {
            SelectIndex(currentIndex - 1);
        }

        source.Play();
    }

    void SelectIndex(int i)
    {
        DeselectIndex();
        textObjectColorings[i].SetMat(selectedMat);
        currentIndex = i;
    }

    void DeselectIndex()
    {
        textObjectColorings[currentIndex].SetMat(defaultMat);
    }
}
