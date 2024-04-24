using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character : MonoBehaviour
{
    public int lives = 5;
    private bool isDied = false;
    private new Rigidbody2D rigidbody;

    public void Start()
    {
        rigidbody = GetComponent<Rigidbody2D>();
    }

    public void Update()
    {
        if (!isDied && lives == 0) Die();
        rigidbody.velocity = new Vector2();
    }

    public void Rotate(Vector3 destination)
    {
        Vector3 difference = (destination - transform.position).normalized;
        float rotationZ = Mathf.Atan2(difference.y, difference.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(0f, 0f, rotationZ);
    }

    public void Move(Vector3 direction, float speed) => rigidbody.velocity = direction.normalized * speed;

    public void Die() 
    {
        isDied = true;
        // для анимации смерти
        //var animator = GameObject.Find("SceneChanger").GetComponent<Animator>();
        //animator.SetTrigger(true);
    }
}
