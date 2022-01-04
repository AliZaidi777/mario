using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinToss : MonoBehaviour
{
    Rigidbody2D rb;
  //  int x = 0;
    int y = 6;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        rb.velocity = new Vector2(rb.velocity.x, y);
        Destroy(gameObject, 0.5f);

    }
}
