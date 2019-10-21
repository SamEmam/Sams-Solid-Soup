using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class SRaceSpeedometerAlt : MonoBehaviour
{
    [SerializeField]
    private SRaceFinishLine finishLine;
    [SerializeField]
    private float multiplier = 3;
    [SerializeField]
    private RVehicleTypeSelector typeSelector;
    
    private Rigidbody rb;
    private SRacePlayerCheckpoint cp;
    private SRacePlayerPosition pos;


    private TextMeshProUGUI dial;
    private float speed;

    private void Start()
    {
        GameObject vehicle = typeSelector.GetVehicle();

        rb = vehicle.GetComponent<Rigidbody>();
        cp = vehicle.GetComponent<SRacePlayerCheckpoint>();
        pos = vehicle.GetComponent<SRacePlayerPosition>();

        dial = GetComponentInChildren<TextMeshProUGUI>();
    }

    private void Update()
    {
        var velocity = rb.velocity.magnitude * multiplier;
        speed = velocity;
        dial.text = speed.ToString("F1") + " km/h \n";
        if (finishLine.raceLaps > 1)
        {
            dial.text += (cp.laps + 1) + "/" + finishLine.raceLaps + " LAPS" + "\n";
        }
        dial.text += pos.positionString;
    }
}
