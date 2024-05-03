using UnityEngine;

public class Player : Character
{
    Animator animator;
    SpriteRenderer sprite;
    Rigidbody2D rb;
    public HealthBar healthBar;
    float health = 1;
    public Animator Animator;


    [SerializeField]
    private float speed;

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
            animator.Play("walk_x");
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
        
        if (moveX == 0 & moveY == 0)
        {
            Animator.SetInteger("walk", 0 );
        }
        else { Animator.SetInteger("walk", 1); }

    }

    public void TakeDamage(float damage)
    {
        if (health <= 0)
        {
            Die();
        }
        else
        {
            health = health - damage;
            healthBar.SetHealth(health);
        }
    }
}
