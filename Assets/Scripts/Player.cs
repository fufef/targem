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

    private new void Start()
    {
        base.Start();
        var c = GetComponent<BoxCollider2D>();
        c.tag = "Player";
    }

    private new void Update()
    {
        base.Update();

        // движение игрока. 
        // потом можно и переписать, в зависимости от того как будет нужно чтобы чел двигался 
        if (Input.GetButton("Horizontal") || Input.GetButton("Vertical"))
            Move(new Vector3(Math.Sign(Input.GetAxis("Horizontal")), 
                             Math.Sign(Input.GetAxis("Vertical"))), speed);

        if (triggerActive && Input.GetKeyDown(KeyCode.F))
        {
            SomeCoolAction();
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
