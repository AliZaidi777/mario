using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
   public int x = 2;
   // int y = 0;
    public Animator animator;
   public Rigidbody2D rb;
   // public Rigidbody2D rbA;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
     //   rbA = GetComponent<Rigidbody2D>();
    }
    void Update()
    {

        rb.velocity = new Vector2(x, 0);
      //  rbA.velocity = new Vector2(1f, 0);
    }
    void OnCollisionEnter2D(Collision2D collision)
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
    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "mario")
        {
            animator.SetInteger("Int", 1);
        }
    }


}


