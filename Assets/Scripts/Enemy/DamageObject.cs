using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageObject : MonoBehaviour
{
    public float JumpForce=8f;
private void OnCollisionEnter2D(Collision2D collision) {
    if(collision.transform.CompareTag("Player"))
    {
        collision.gameObject.GetComponent<Rigidbody2D>().velocity = (Vector2.up*JumpForce);
        collision.transform.GetComponent<PlayerRespawn>().PlayerDamaged();

    }
}
}
