using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RWaterForce : MonoBehaviour
{
    public Transform direction;
    public float force = 0.08f;

    public AudioClip[] clips;
    private AudioSource source;

    private void Start()
    {
        source = gameObject.AddComponent<AudioSource>();
        source.clip = clips[Random.Range(0, clips.Length - 1)];
    }

    private void OnTriggerStay(Collider other)
    {
        Rigidbody rb = other.GetComponent<Rigidbody>();

        if (rb && (other.tag == "Player" || other.tag == "Buoyant"))
        {
            rb.AddForce(direction.rotation.eulerAngles * force, ForceMode.Acceleration);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        Rigidbody rb = other.GetComponent<Rigidbody>();

        if (rb && (other.tag == "Player"))
        {
            source.Play();
            source.clip = clips[Random.Range(0, clips.Length - 1)];
        }
    }
}
