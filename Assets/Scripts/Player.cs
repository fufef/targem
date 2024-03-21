using System;
using UnityEngine;

public class Player : Character
{
    [SerializeField]
    private float speed;

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
    }
}
