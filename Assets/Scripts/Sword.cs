using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class Sword : MonoBehaviour
{
    public AudioSource clip;
    private BoxCollider2D collider2D;
    private SpriteRenderer playerSpriteRendered;

    public Animator animator;

    void Start()
    {
        playerSpriteRendered = transform.root.GetComponent<SpriteRenderer>();
        collider2D = GetComponent<BoxCollider2D>();
        collider2D.enabled=false;
    }


    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Q)|| Input.GetMouseButtonDown(0))
        {
            Attack();
            clip.Play();
        }
    }
    public void Attack()
    {
        animator.Play("Attack");
        collider2D.enabled = true;
        Invoke("DisableAttack",0.5f);
    }
    public void DisableAttack()
    {
        collider2D.enabled = false;
    }

    private void OnTriggerEnter2D(Collider2D collision) {
         if (collision.gameObject.CompareTag("Enemy"))
         {
            collision.gameObject.GetComponentInParent<DamageEnemy>().LosseLifeAndHit();
            collider2D.enabled=false;
         }
    }
}
