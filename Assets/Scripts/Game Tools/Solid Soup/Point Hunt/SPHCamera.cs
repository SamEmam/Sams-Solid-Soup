using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SPHCamera : MonoBehaviour
{

    // Start is called before the first frame update
    void Start()
    {
        transform.SetParent(transform.parent.GetComponent<RVehicleTypeSelector>().GetVehicle().transform);
        
    }
    
}
