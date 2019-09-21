using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SDerbyPlayerCollider : MonoBehaviour
{
    public SDerbyPlayer player;
    public Rigidbody rb;
    [SerializeField]
    private int collisionStrength = 20;

    //private void OnCollisionEnter(Collision collision)
    //{
    //    player.TakeDamage((int)collision.relativeVelocity.magnitude * 10, collision.gameObject.GetComponent<SDerbyPlayerNumber>().playerNum);
    //}

    private void OnTriggerEnter(Collider other)
    {
        SDerbyPlayerCollider otherPlayerCol = other.GetComponent<SDerbyPlayerCollider>();
        if (otherPlayerCol)
        {
            float otherPlayer = otherPlayerCol.rb.velocity.magnitude;

            float thisPlayer = rb.velocity.magnitude;

            float relativeVelocity = otherPlayer - thisPlayer;

            if (relativeVelocity > 0f)
            {
                //player.TakeDamage((int)(relativeVelocity * collisionStrength), otherPlayerCol.player.GetComponent<SDerbyPlayerNumber>().playerNum);
                player.TakeDamage((int)(relativeVelocity * collisionStrength), otherPlayerCol.player.playerNum);
            }
            else
            {
                player.TakeDamage(Mathf.Abs((int)(relativeVelocity * (collisionStrength / 5))), otherPlayerCol.player.playerNum);
            }
        }
        
    }
}
