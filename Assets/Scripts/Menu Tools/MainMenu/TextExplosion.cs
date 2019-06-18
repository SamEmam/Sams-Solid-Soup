using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TextExplosion : MonoBehaviour
{
    private Vector3 explodePos;
    private float radius = 5f;
    private float force = 5;
    private float upwardsMod = 2;

    
    private void Start()
    {
        explodePos = transform.position;
    }

    public void Explode()
    {
        foreach (Rigidbody rigidbody in GetComponentsInChildren<Rigidbody>())
        {
            rigidbody.isKinematic = false;
            rigidbody.AddExplosionForce(force, transform.position, radius, upwardsMod, ForceMode.VelocityChange);
        }
    }
    
}
