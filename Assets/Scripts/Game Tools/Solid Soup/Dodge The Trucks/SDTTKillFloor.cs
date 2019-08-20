using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SDTTKillFloor : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            Destroy(other.transform.parent.gameObject);
        }
        else
        {
            Destroy(other.gameObject);
        }
    }
}
