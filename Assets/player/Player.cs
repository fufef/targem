using TMPro;
using UnityEngine;
using UnityEngine.Rendering.Universal;

public class Player : Character
{
    Animator animator;
    SpriteRenderer sprite;
    Rigidbody2D rb;
    public Sprite deathSprite;
    public TextMeshProUGUI moneyBar;
    public HealthBar healthBar;
    float health = 1;
    public Animator Animator;
    private bool isShopOpened;
    private int money = 100;
    public TextMeshProUGUI shopUI;
    public Light2D flashlight;
    private float damageModificator = 1f;
    public bool inMaze = false;
    private bool iscos = false;

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

    private new void Update()
    {
        if (health < 0)
        {
            base.Update();
            return;
        }

        if (Input.GetKeyDown(KeyCode.I))
        {
            isShopOpened = !isShopOpened;
            if (isShopOpened)
            {
                shopUI.enabled = true;
            }
            else
            {
                shopUI.enabled = false;
            }
        }

        if (isShopOpened)
        {
            if (Input.GetKeyDown(KeyCode.F))
            {
                if (money >= 30)
                {
                    flashlight.shapeLightFalloffSize = flashlight.shapeLightFalloffSize + 0.5f;
                    money -= 30;
                }
            }

            if (Input.GetKeyDown(KeyCode.G))
            {
                if (money >= 30)
                {
                    speed = speed + 0.3f;
                    money -= 30;
                }
            }

            if (Input.GetKeyDown(KeyCode.H))
            {
                if (money >= 30)
                {
                    damageModificator = damageModificator - 0.05f;
                    money -= 30;
                }
            }
        }
    }


    private void FixedUpdate()
    {
        if (health < 0)
        {
            base.Update();
            return;
        }

        float moveX = 0f;
        float moveY = 0f;

        if (Input.GetKey(KeyCode.D) && iscos == false)
        {
            moveX = speed;
            animator.Play("walk_x");
            sprite.flipX = false;
        }

        if (Input.GetKey(KeyCode.D))
        {
            moveX = speed;
        }

        if (Input.GetKey(KeyCode.A) && iscos == false)
        {
            moveX = -speed;
            animator.Play("walk_x");
            sprite.flipX = true;
        }

        if (Input.GetKey(KeyCode.A))
        {
            moveX = -speed;
        }

        if (Input.GetKey(KeyCode.W))
        {
            iscos = true;
            Debug.Log("j");
            moveY = speed;
            if (moveX != 0f)
            {
                moveY = moveY * 0.7f; // Уменьшаем скорость по диагонали для равновесия
            }
            animator.Play("walk_up");
        }
        if (!Input.GetKey(KeyCode.W) && !Input.GetKey(KeyCode.S))
        {
            iscos = false;
            Debug.Log("sddasda");
        }

        if (Input.GetKey(KeyCode.S))
        {
            iscos = true;
            Debug.Log("s");
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

        moneyBar.text = money.ToString();
    }

    public void TakeDamage(float damage)
    {
        if (health <= 0)
        {
            Die();
        }
        else
        {
            health = health - damage * damageModificator;
            healthBar.SetHealth(health);
            if (health <= 0)
            {
                animator.enabled = false;
                sprite.sprite = deathSprite;
            }
        }
    }
}
