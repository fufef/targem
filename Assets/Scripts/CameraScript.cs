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

    public bool Follow;

    private void Update()
    {
        if (Follow)
        {
            transform.position = new Vector3(target.position.x, target.position.y, transform.position.z);
        }
    }
}
