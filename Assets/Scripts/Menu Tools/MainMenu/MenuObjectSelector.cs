using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using XboxCtrlrInput;

public class MenuObjectSelector : MonoBehaviour
{
    [SerializeField]
    private TextObjectColoring[] textObjectColorings;
    [SerializeField]
    private TextExplosion[] textExplosions;
    [SerializeField]
    private Material defaultMat, selectedMat;


    private int currentIndex;
    private float startTime;

    // Start is called before the first frame update
    void Start()
    {
        SelectIndex(currentIndex);
        startTime = Time.time;
    }

    // Update is called once per frame
    void Update()
    {
        if (Time.time - startTime < 1.8f)
        {
            return;
        }

        if (XCI.GetButtonDown(XboxButton.A))
        {
            textExplosions[currentIndex].Explode();
            textObjectColorings[currentIndex].SwitchScene();
        }

        if (XCI.GetButtonDown(XboxButton.DPadDown))
        {
            SelectNext();
        }

        if (XCI.GetButtonDown(XboxButton.DPadUp))
        {
            SelectPrev();
        }
    }

    void SelectNext()
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

    void SelectPrev()
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
