using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
   public int x = 2;
    public Animator animator;
   public Rigidbody2D rb;

    public bool isAlive = true;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }
    void Update()
    {
        if(isAlive)
        rb.velocity = new Vector2(x, 0);
    }
    void OnCollisionEnter2D(Collision2D collision)
    {
        if (isAlive)
        {
            if (collision.gameObject.tag == "pipe")
            {
                x = x * -1;
            }
            if (collision.gameObject.tag == "enemy")
            {
                x = x * -1;
            }
        }


    }
    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "mario")
        {
            animator.SetInteger("Int", 1);
        }
    }

    public void Dead()
    {
        isAlive = false;
        Destroy(gameObject, 0.5f);
        var colliders = GetComponentsInChildren<Collider2D>();

        for (int i = 0; i < colliders.Length; i++)
        {
            colliders[i].enabled = false;
        }
    }
}


