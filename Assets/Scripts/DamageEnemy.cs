using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
public class DamageEnemy : MonoBehaviour
{
    public Collider2D collider2D;
    public Animator animator;

    public SpriteRenderer spriteRenderer;

    public GameObject destroyParticle;

    public float JumpForce=2.5f;
    public int lifes = 1;

    private void OnCollisionEnter2D(Collision2D collision) {
        if (collision.transform.CompareTag("Player"))
        {
            collision.gameObject.GetComponent<Rigidbody2D>().velocity = (Vector2.up*JumpForce);
            collision.transform.GetComponent<PlayerRespawn>().PlayerDamaged();
            
        }
        else if ((collision.transform.CompareTag("Sword")))
        {
            animator.Play("Collected");
            LosseLifeAndHit();
        }
        
    }
    
    public void LosseLifeAndHit()
    {
        lifes--;
        
        CheckLife();
    }
    public void CheckLife(){
        if(lifes==0){
    destroyParticle.SetActive(true);
    spriteRenderer.enabled = false;
    Invoke("EnemyDie",0.1f); 
    
        }
    }
    public void EnemyDie()
    {
        animator.Play("Collected");
        Destroy(gameObject);
    }
}
