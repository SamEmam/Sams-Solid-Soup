using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class SRaceSpeedometer : MonoBehaviour
{
    public SRaceFinishLine finishLine;
    public float multiplier = 3;
    private Rigidbody rb;
    private SRacePlayerCheckpoint cp;
    private TextMeshProUGUI dial;
    private float speed;
    private SRacePlayerPosition pos;

    private void Start()
    {
        rb = GetComponentInParent<Rigidbody>();
        cp = GetComponentInParent<SRacePlayerCheckpoint>();
        dial = GetComponentInChildren<TextMeshProUGUI>();
        pos = GetComponentInParent<SRacePlayerPosition>();
    }

    private void Update()
    {
        var velocity = rb.velocity.magnitude * multiplier;
        speed = velocity;
        dial.text = speed.ToString("F1") + " km/h \n" + (cp.laps + 1) + "/" + finishLine.raceLaps + " LAPS" + "\n" + pos.positionString;
    }
}
