using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SPHCamera : MonoBehaviour
{
    private Rigidbody parentRB;
    private Transform target;
    public Vector3 newDir;
    

    // Start is called before the first frame update
    void Start()
    {
        target = transform.parent.GetComponent<RVehicleTypeSelector>().GetVehicle().transform;
        parentRB = target.GetComponent<Rigidbody>();

    }

    private void Update()
    {
        transform.position = parentRB.position;

        float speed = 2f;

        Vector3 targetRotation = Quaternion.LookRotation(parentRB.velocity).eulerAngles;

        targetRotation.x = Mathf.Clamp(targetRotation.x, -25, 25);

        Quaternion targetQuaternion = Quaternion.Euler(targetRotation);

        transform.rotation = Quaternion.Lerp(transform.rotation, targetQuaternion, Time.deltaTime * speed);
        
    }

}
