using System;
using UnityEngine;

public class Player : Character
{
    [SerializeField]
    private float speed;

    [SerializeField]
    private bool triggerActive = false;

    [SerializeField]
    private MapGen mapGen;

    [SerializeField]
    private Sprite left;

    [SerializeField]
    private Sprite right;

    [SerializeField]
    private Sprite top;

    [SerializeField]
    private Sprite bottom;

    private SpriteRenderer spriteRenderer;

    private new void Start()
    {
        base.Start();
        var c = GetComponent<BoxCollider2D>();
        c.tag = "Player";
        spriteRenderer = c.GetComponent<SpriteRenderer>();
    }

    public static int count_button = 0;
    public new void Update()
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

        if (Input.GetButton("Horizontal"))
        {
            if (Math.Sign(Input.GetAxis("Horizontal")) < 0)
            {
                spriteRenderer.sprite = left;
            }
            else
            {
                spriteRenderer.sprite = right;
            }
        }

        if (Input.GetButton("Vertical"))
        {
            if (Math.Sign(Input.GetAxis("Vertical")) > 0)
            {
                spriteRenderer.sprite = top;
            }
            else
            {
                spriteRenderer.sprite = bottom;
            }
        }
    }

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
