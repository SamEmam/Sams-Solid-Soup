using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RAudioListenerFiller : MonoBehaviour
{
    private RAudioListenerController audioLC;
    [SerializeField]
    private RVehicleTypeSelector p1, p2, p3, p4, p5, p6, p7, p8;

    private void Start()
    {
        audioLC = GetComponent<RAudioListenerController>();
        if (p1.GetVehicle())
        {
            audioLC.p1 = p1.GetVehicle().transform;
        }
        if (p2.GetVehicle())
        {
            audioLC.p2 = p2.GetVehicle().transform;
        }
        if (p3.GetVehicle())
        {
            audioLC.p3 = p3.GetVehicle().transform;
        }
        if (p4.GetVehicle())
        {
            audioLC.p4 = p4.GetVehicle().transform;
        }
        if (p5.GetVehicle())
        {
            audioLC.p5 = p5.GetVehicle().transform;
        }
        if (p6.GetVehicle())
        {
            audioLC.p6 = p6.GetVehicle().transform;
        }
        if (p7.GetVehicle())
        {
            audioLC.p7 = p7.GetVehicle().transform;
        }
        if (p8.GetVehicle())
        {
            audioLC.p8 = p8.GetVehicle().transform;
        }
    }
}
