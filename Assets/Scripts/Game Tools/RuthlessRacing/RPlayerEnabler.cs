using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RPlayerEnabler : MonoBehaviour
{

    [SerializeField]
    private GameObject p1, p2, p3, p4, p5, p6, p7, p8;

    private void Awake()
    {
        if (GamePrefs.Player1)
        {
            p1.SetActive(true);
        }
        if (GamePrefs.Player2)
        {
            p2.SetActive(true);
        }
        if (GamePrefs.Player3)
        {
            p3.SetActive(true);
        }
        if (GamePrefs.Player4)
        {
            p4.SetActive(true);
        }
        if (GamePrefs.Player5)
        {
            p5.SetActive(true);
        }
        if (GamePrefs.Player6)
        {
            p6.SetActive(true);
        }
        if (GamePrefs.Player7)
        {
            p7.SetActive(true);
        }
        if (GamePrefs.Player8)
        {
            p8.SetActive(true);
        }
    }
}
