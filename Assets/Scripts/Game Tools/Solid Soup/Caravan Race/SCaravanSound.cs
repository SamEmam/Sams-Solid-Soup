using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SCaravanSound : MonoBehaviour
{
    public AudioClip[] clips;
    private AudioSource source;
    private FixedJoint joint;
    private bool hasPlayedSound = false;

    private void Start()
    {
        source = gameObject.AddComponent<AudioSource>();
        source.clip = clips[Random.Range(0, clips.Length - 1)];
        source.pitch = 0.5f;
        source.volume /= 2;

        joint = GetComponent<FixedJoint>();
    }

    private void Update()
    {
        if (hasPlayedSound)
        {
            return;
        }
        if (!joint)
        {
            hasPlayedSound = true;
            transform.SetParent(null);
            source.Play();
        }
    }
}
