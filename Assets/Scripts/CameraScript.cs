using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraScript : MonoBehaviour
{
    [SerializeField]
    private Vector3 offset;
    [SerializeField]
    private float dampling;

    public Transform target;

    private Vector3 vel = Vector3.zero;

    private void Update()
    {
        Vector3 targetPos = target.position + offset;   
        targetPos.z = transform.position.z;


        transform.position = Vector3.SmoothDamp(transform.position, targetPos, ref vel, dampling);
    }
}
