using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerMove : MonoBehaviour
{
public Animator animator;

public float runSpeed = 2;
public float jumpSpeed=3; 

public float dobleJumpSpeed=2.5f;

private bool canDobleJump;

Rigidbody2D rb2D;

public SpriteRenderer spriteRenderer;

public bool betterJump = false;
public float fallMultiplier = 0.5f;
public float lowJumpMultiplier = 1f;


    

    void Start()
    {
        animator = GetComponent<Animator>();
        rb2D = GetComponent<Rigidbody2D>();
    }

    void Update() {
        if (Input.GetKey("w"))
        {
            if(CheckG.isGrounded)
            {
                canDobleJump = true;
                rb2D.velocity = new Vector2(rb2D.velocity.x,jumpSpeed);
            }
            else
            {
                if (Input.GetKeyDown("w"))
                {
                    if (canDobleJump)
                    {
                        animator.SetBool("DobleJump",true);
                        rb2D.velocity = new Vector2(rb2D.velocity.x,dobleJumpSpeed);
                        canDobleJump = false;
                    }
                }
            }
            
        }
        if (Input.GetKey("r")){
            restart_game();
        }


        if(CheckG.isGrounded==false)
        {
            animator.SetBool("Jump",true);
            animator.SetBool("Run",false);
        }
        if(CheckG.isGrounded==true)
        {
            animator.SetBool("Jump",false);
            animator.SetBool("DobleJump",false);
            animator.SetBool("Falling",false);
        }
        if(rb2D.velocity.y<0)
            {
                animator.SetBool("Falling",true);
            }
        else if(rb2D.velocity.y>0)
            {
                animator.SetBool("Falling",false);
            }

    }
  
    void FixedUpdate()
    {
        if (Input.GetKey("d") || Input.GetKey("right") )
        {
           rb2D.velocity= new Vector2(runSpeed,rb2D.velocity.y);
           spriteRenderer.flipX = false;
           animator.SetBool("Run",true);
        }
        else if (Input.GetKey("a") || Input.GetKey("left") )
        {
            rb2D.velocity= new Vector2(-runSpeed,rb2D.velocity.y);
            spriteRenderer.flipX = true;
            animator.SetBool("Run",true);
        }
        else
        {
            animator.SetBool("Run",false);
            rb2D.velocity = new Vector2(0,rb2D.velocity.y);
        }

        if(betterJump)
        {
            if(rb2D.velocity.y<0)
            {
                rb2D.velocity += Vector2.up *Physics2D.gravity.y * (fallMultiplier) * Time.deltaTime;
            }
             if(rb2D.velocity.y>0 && !Input.GetKey("w"))
            {
                rb2D.velocity += Vector2.up *Physics2D.gravity.y * (lowJumpMultiplier) * Time.deltaTime;
            }
            
        }

        
    }

    void restart_game(){
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }


}

