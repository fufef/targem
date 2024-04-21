using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TeleportOnButtonPress : MonoBehaviour
{
    public Transform teleportTarget;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.E) && IsInTrigger())
        {
    
            transform.position = teleportTarget.position;
        }
    }

    private bool IsInTrigger()
    {
        // Проверяем, находится ли персонаж внутри триггера.
        Collider[] colliders = Physics.OverlapSphere(transform.position, 0.5f);
        foreach (Collider collider in colliders)
        {
            if (collider.gameObject.tag == "TeleportTrigger")
            {

                return true;
            }
        }

        return false;
    }
}