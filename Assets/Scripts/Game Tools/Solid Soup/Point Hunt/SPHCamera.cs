using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SPHCamera : MonoBehaviour
{
    private Rigidbody parentRB;
    private Transform target;
    

    // Start is called before the first frame update
    void Start()
    {
        target = transform.parent.GetComponent<RVehicleTypeSelector>().GetVehicle().transform;
        parentRB = target.GetComponent<Rigidbody>();

    }

    private void Update()
    {
        transform.position = target.position;
        float step = (parentRB.velocity.magnitude / 2) * Time.deltaTime;

        Vector3 newDir = Vector3.RotateTowards(transform.forward, parentRB.velocity, step, 0.0f);
        
        transform.rotation = Quaternion.LookRotation(newDir);
        
    }

}
