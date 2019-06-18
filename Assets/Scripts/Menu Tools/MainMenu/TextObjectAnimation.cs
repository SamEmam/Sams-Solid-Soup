using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TextObjectAnimation : MonoBehaviour
{

    [SerializeField]
    private Vector3 startPos;

    private Vector3 targetPos;
    private float speed = 12f;
    private float startTime;
    private float journeyLength;

    // Start is called before the first frame update
    void Start()
    {

        targetPos = transform.localPosition;
        transform.localPosition = startPos;

        startTime = Time.time;

        // Calculate the journey length
        journeyLength = Vector3.Distance(startPos, targetPos);
    }

    // Update is called once per frame
    void FixedUpdate()
    {

        if (Time.time - startTime > 1.8f)
        {
            return;
        }
        // Distance moved = time * speed.
        float distCovered = (Time.time - startTime) * speed;

        // Fraction of journey completed = current distance divided by total distance.
        float fracJourney = distCovered / journeyLength;

        // Set position as fraction of distance between markers.
        transform.localPosition = Vector3.Lerp(startPos, targetPos, fracJourney);

    }
}
