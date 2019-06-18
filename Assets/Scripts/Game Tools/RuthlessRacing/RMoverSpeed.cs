using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RMoverSpeed : MonoBehaviour
{
    [SerializeField]
    private RMover mover;
    [SerializeField]
    private Transform target;
    [SerializeField]
    private Transform wall;

    private float speed;
    [SerializeField]
    private float maxSpeed;
    [SerializeField]
    private float minSpeed;
    [SerializeField]
    private float maxDist;
    [SerializeField]
    private float minDist;

    [SerializeField]
    private float colSpeedMulti;

    private int playersInCol;

    private void Update()
    {
        SpeedEvaluator();
        mover.speed = speed;
    }

    public void SpeedEvaluator()
    {
        var dist = Vector3.Distance(wall.position, target.position);

        if (dist > maxDist)
        {
            // target is far away, set max speed;
            speed = maxSpeed;
        }
        else if (dist < minDist)
        {
            // target is close, set min speed;
            speed = minSpeed;
        }
        else
        {
            // target is between max/min dist, set speed proportional
            var distRatio = (dist - minDist) / (maxDist - minDist);
            var diffSpeed = maxSpeed - minSpeed;

            // Final calc
            speed = (distRatio * diffSpeed) + minSpeed;
        }

        if (playersInCol <= 0)
        {
            speed += colSpeedMulti;
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.transform.tag == ("Player"))
        {
            playersInCol++;
        }
    }

    private void OnCollisionExit(Collision collision)
    {
        if (collision.transform.tag == ("Player"))
        {
            playersInCol--;
        }
    }


}
