using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SPHPoint : MonoBehaviour
{
    private int value = 1;
    public bool randomStart = false;

    private void Start()
    {
        if (randomStart)
        {
            var rng = Random.Range(0, 1);
            if (rng == 1)
            {
                Destroy(gameObject);
            }
        }
    }

    private void Update()
    {
        transform.Rotate(0, 1, 0, Space.Self);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            other.GetComponent<SPHPlayer>().AwardPoint(value);
            Destroy(gameObject);
        }
    }

    //private void OnCollisionEnter(Collision other)
    //{
    //    if (other.transform.tag == "Player")
    //    {
    //        Debug.Log("HIT PLAYER COLLIDER");
    //        other.transform.GetComponent<SPHPlayer>().AwardPoint(value);
    //        Destroy(gameObject);
    //    }
    //}
}
