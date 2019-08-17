using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SLetterReset : MonoBehaviour
{
    private Vector3 startPos;
    private Vector3 startRot;
    private float resetTimer = 4f;
    private bool isHit = false;
    private Rigidbody rb;

    // Start is called before the first frame update
    void Start()
    {
        startPos = transform.position;
        startRot = transform.localEulerAngles;
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        if (isHit)
        {
            resetTimer -= Time.deltaTime;

            if (resetTimer < 0)
            {
                isHit = false;
                rb.velocity = Vector3.zero;
                rb.angularVelocity = Vector3.zero;
                transform.localEulerAngles = startRot;
                transform.position = startPos;
                resetTimer = 4f;
            }

        }

    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Player" || collision.gameObject.tag == "PlayerChassis" || collision.gameObject.tag == "Letter")
        {
            isHit = true;
        }
    }
}