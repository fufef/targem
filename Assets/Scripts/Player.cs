using System;
using UnityEngine;

public class Player : Character
{
    private float speed = 10f;

    private new void Start()
    {
        base.Start();
    }

    private new void FixedUpdate()
    {
        base.FixedUpdate();

        // движение игрока. 
        // потом можно и переписать, в зависимости от того как будет нужно чтобы чел двигался 
        if (Input.GetButton("Horizontal") || Input.GetButton("Vertical"))
            Move(new Vector3(Math.Sign(Input.GetAxis("Horizontal")), 
                             Math.Sign(Input.GetAxis("Vertical"))), speed);
    }
}
