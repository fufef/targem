using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Teleport_Yelow : MonoBehaviour
{
    public Transform teleportTarget;
    public Collider2D targetCollider; // Назначить коллайдер, который нужно проверить в инспекторе
    private bool IN;
    private void Update()
    {

        if (Input.GetKeyDown(KeyCode.E) && IN)
        {
            transform.position = teleportTarget.position;
        }
    }
    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("YellowDoor"))
        {
            IN = true;
        }
    }

}