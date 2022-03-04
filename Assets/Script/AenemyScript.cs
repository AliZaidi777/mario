using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AenemyScript : MonoBehaviour
{
    public Rigidbody2D rb;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.velocity = new Vector2(5, 0);
    }
   
}
