using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    int x = -1;
    int y = 0;
  
    Rigidbody2D rb;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }
   public void Update()
    {

        rb.velocity = new Vector2(x, y);
    }
    private void OnCollisionEnter2D(Collision2D collision)
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


