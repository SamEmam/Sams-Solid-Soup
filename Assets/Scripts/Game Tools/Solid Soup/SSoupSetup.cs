using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SSoupSetup : MonoBehaviour
{
    public int startIndex, splitIndex, finishIndex;
    public List<int> list4Player; // With split-screen
    public List<int> list8Player; // Without split-screen

    private void Awake()
    {
        for (int i = startIndex; i < finishIndex; i++)
        {
            list4Player.Add(i);
        }

        for (int i = splitIndex; i < finishIndex; i++)
        {
            list8Player.Add(i);
        }

        for (int i = 0; i < list4Player.Count - 1; i++)
        {
            var r = Random.Range(i, list4Player.Count);
            var temp = list4Player[i];
            list4Player[i] = list4Player[r];
            list4Player[r] = temp;
        }

        for (int i = 0; i < list8Player.Count - 1; i++)
        {
            var r = Random.Range(i, list8Player.Count);
            var temp = list8Player[i];
            list8Player[i] = list8Player[r];
            list8Player[r] = temp;
        }
    }

    public void SetSoupList(bool withSplit)
    {
        if (withSplit)
        {
            GamePrefs.SoupList = list4Player;
        }
        else
        {
            GamePrefs.SoupList = list8Player;
        }
    }
}
