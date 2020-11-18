using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController2D : MonoBehaviour
{
    Animator animator;
    Rigidbody2D rb2d;
    SpriteRenderer spriteRenderer; //Here we are referencing these functions, like giving them nicknames.

    bool isGrounded;

    [SerializeField]            // This adds a function in unity that allows us to edit that field within the game engine.
    Transform groundCheck;
    
    [SerializeField]
    Transform groundCheckL;

    [SerializeField]
    Transform groundCheckR;

    [SerializeField]
    private float runSpeed = 1.5f;     // determines how fast our player moves.

    [SerializeField]
    private float jumpSpeed = 4f;      // determines the jump speed for our player.

    // Start is called before the first frame update
    void Start()
    {
        
        animator = GetComponent<Animator>();
        rb2d = GetComponent<Rigidbody2D>();
        spriteRenderer = GetComponent<SpriteRenderer>(); //Telling the computer what to do when we call on these functions.

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void FixedUpdate() //Similar to the update function but it has a fixed timestep, is a bit more accurate for games within the physics world.
    {
        if ((Physics2D.Linecast(transform.position, groundCheck.position, 1 << LayerMask.NameToLayer("Ground"))) || //If the line cast goes from the player to the object known as "Ground" then apply the folllowing 
           (Physics2D.Linecast(transform.position, groundCheckL.position, 1 << LayerMask.NameToLayer("Ground"))) ||
           (Physics2D.Linecast(transform.position, groundCheckR.position, 1 << LayerMask.NameToLayer("Ground"))))

        {
            isGrounded = true;
        }
        else
        {
            isGrounded = false;
            animator.Play("Player_jump");
        }

        if(Input.GetKey("d") || Input.GetKey("right")) // || means OR
        {
            rb2d.velocity = new Vector2(runSpeed, rb2d.velocity.y); // If conditions are met we are adding a new velocity to the rigidbody2d (our player)
            if (isGrounded) // This if statement is added to fix the jumping animation bugging out
            {
                animator.Play("Player_run"); // plays the animation defined when the conditions are met.
            }
            spriteRenderer.flipX = false;
        }
        else if(Input.GetKey("a") || Input.GetKey("left"))
        {
            rb2d.velocity = new Vector2(-runSpeed, rb2d.velocity.y); //rb2d.velocity.y within the new vector just tells the computer to keep the current y velocity.
            if (isGrounded)
            {
                animator.Play("Player_run");
            }
            spriteRenderer.flipX = true; // This flips our sprite when we are moving left
        }
        
        else
        {
            if (isGrounded)
            {
                animator.Play("Player_idle");
            }
            rb2d.velocity = new Vector2(0, rb2d.velocity.y); // Turns out X velocity to 0 when we are not pressing any keys
        }

        if(Input.GetKey("space") && isGrounded)
        {
            rb2d.velocity = new Vector2(rb2d.velocity.x, jumpSpeed); //rb2d.velocity.x within the new vector just tells the computer to keep the current x velocity.
            animator.Play("Player_jump");
        }
    }
}
