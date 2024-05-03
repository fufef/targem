using System;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public Player player;
    Rigidbody2D rb;
    private bool IsColliding = false;
    private DateTime previousAttack = DateTime.MinValue;
    private float speed = 3f;
    private float maxSpeed = 3f;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        var diff = player.transform.position - this.transform.position;
        diff = speed * diff.normalized;
        rb.velocity = diff;

        if (IsColliding)
        {
            if ((DateTime.Now - previousAttack).TotalSeconds > 1)
            {
                previousAttack = DateTime.Now;
                player.TakeDamage(0.1f);
            }
        }
    }

    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            IsColliding = true;
        }

        if (collision.CompareTag("Stenomaska"))
        {
            speed = 1f;
        }
    }

    public void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            IsColliding = false;
        }

        if (collision.CompareTag("Stenomaska"))
        {
            speed = maxSpeed;
        }
    }
}
