using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class SERDistanceDial : MonoBehaviour
{
    public Transform killWall;
    public TextMeshProUGUI dial;
    private int distance;

    private void Update()
    {
        distance = (int)Vector3.Distance(transform.position, killWall.position) - 50;
        dial.text = distance + " m";
    }
}
