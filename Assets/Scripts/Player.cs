using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : Character
{
    Animator animator;
    SpriteRenderer sprite;
    Rigidbody2D rb;


    [SerializeField]
    private float speed;

    [SerializeField]
    private bool triggerActive = false;

    [SerializeField]
    private MapGen mapGen;

    private new void Start()
    {
        base.Start();

        animator = GetComponent<Animator>();
        sprite = GetComponent<SpriteRenderer>();
        rb = GetComponent<Rigidbody2D>();

        var c = GetComponent<BoxCollider2D>();
        c.tag = "Player";
    }
    public static int count_button = 0;


    private void FixedUpdate()
    {
        float moveX = 0f;
        float moveY = 0f;

        if (Input.GetKey(KeyCode.D))
        {
            moveX = speed;
            animator.Play("walk_x");
            sprite.flipX = false;
        }
        
        else if (Input.GetKey(KeyCode.A))
        {
            moveX = -speed;
            sprite.flipX = true;
        }

        if (Input.GetKey(KeyCode.W))
        {
            moveY = speed;
            if (moveX != 0f)
            {
                moveY = moveY * 0.7f; // Уменьшаем скорость по диагонали для равновесия
            }
            animator.Play("walk_up");
        }

        if (Input.GetKey(KeyCode.S))
        {
            moveY = -speed;
            if (moveX != 0f)
            {
                moveY = moveY * 0.7f; // Уменьшаем скорость по диагонали для равновесия
            }
            animator.Play("walk_down");
        }

        rb.velocity = new Vector2(moveX, moveY);




        /*if (Input.GetKey(KeyCode.D))
        {
            rb.velocity = new Vector2(speed,rb.velocity.y);
            animator.Play("walk_x");
        }
        else if (Input.GetKey(KeyCode.A))
        {
            rb.velocity = new Vector2(-speed, rb.velocity.y);
        }
        else if (Input.GetKey(KeyCode.W))
        {
            rb.velocity = new Vector2(rb.velocity.x,speed);
        }
        else if (Input.GetKey(KeyCode.S))
        {
            rb.velocity = new Vector2(rb.velocity.x,-speed);
        }*/
    }

    /*  public new void Update()
      {
          base.Update();

          // движение игрока. 
          // потом можно и переписать, в зависимости от того как будет нужно чтобы чел двигался 
          if (Input.GetButton("Horizontal") || Input.GetButton("Vertical"))
              Move(new Vector3(Math.Sign(Input.GetAxis("Horizontal")), 
                               Math.Sign(Input.GetAxis("Vertical"))), speed);


          if (triggerActive && Input.GetKeyDown(KeyCode.E))
          {
              count_button++;
              SomeCoolAction();
          }
      }
    */

    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("YellowDoor"))
        {
            triggerActive = true;
        }
    }

    public void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("YellowDoor"))
        {
            triggerActive = false;
        }
    }

    public void SomeCoolAction()
    {
        Debug.Log("IN!");
        mapGen.GenerateMaze();
        var z = transform.position.z;
        transform.position = new Vector3(41, 41, z);
    }
}
