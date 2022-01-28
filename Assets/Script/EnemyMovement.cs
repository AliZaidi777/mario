using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    int x = 2;
    int y = 0;
    public Animator animator;
    Rigidbody2D rb;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }
    void Update()
    {

        rb.velocity = new Vector2(x, y);
    }
    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "pipe")
        {
            x = x * -1;
        }

    }
    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "mario")
        {
            animator.SetInteger("Int", 1);
        }
    }


}


