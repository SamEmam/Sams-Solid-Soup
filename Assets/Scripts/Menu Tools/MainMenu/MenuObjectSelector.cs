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
    private float runTime = 2.6f;

    // Start is called before the first frame update
    void Start()
    {
        player = ReInput.players.GetPlayer(1);
        SelectIndex(currentIndex);
        startTime = Time.time;
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
            textExplosions[currentIndex].Explode();
            textObjectColorings[currentIndex].SwitchScene();
        }

        if (player.GetButtonDown("Up"))
        {
            SelectUp();
        }

        if (player.GetButtonDown("Down"))
        {
            SelectDown();
        }

        //if (XCI.GetButtonDown(XboxButton.A))
        //{
        //    textExplosions[currentIndex].Explode();
        //    textObjectColorings[currentIndex].SwitchScene();
        //}

        //if (XCI.GetButtonDown(XboxButton.DPadDown))
        //{
        //    SelectNext();
        //}

        //if (XCI.GetButtonDown(XboxButton.DPadUp))
        //{
        //    SelectPrev();
        //}
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
