using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Teleport_Yelow : MonoBehaviour
{
    public Transform teleportTarget;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.E) && IsInTrigger())
        {
            Debug.Log("1");
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
                Debug.Log("2");
                return true;
            }
        }

        return false;
    }
}