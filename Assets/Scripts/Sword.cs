using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sword : MonoBehaviour
{
    private BoxCollider2D collider2D;
    private SpriteRenderer playerSpriteRendered;

    public Animator animator;

    void Start()
    {
        playerSpriteRendered = transform.root.GetComponent<SpriteRenderer>();
        collider2D = GetComponent<BoxCollider2D>();
    }


    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Q)|| Input.GetMouseButtonDown(0))
        {
            Attack();
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
