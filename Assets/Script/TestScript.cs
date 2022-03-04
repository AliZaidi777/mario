using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestScript : MonoBehaviour
{
    Rigidbody2D rb;

    float jumpTime = 0.2f;
    bool canJump = true;
    bool jump = true;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (jump == true)
        {
            if (Input.GetButtonDown("Jump"))
            {
                jumpTime = 0.2f;
            }
            else if (Input.GetButton("Jump") && canJump)
            {
                jumpTime -= Time.deltaTime;

                if (jumpTime < 0f)
                {
                    canJump = false;
                    jump = false;

                    rb.velocity = new Vector2(rb.velocity.x, 14);
                }
            }
            else if (Input.GetButtonUp("Jump") && canJump)
            {
                if (jumpTime > 0f)
                {
                    Debug.Log("Small Jump");
                    rb.velocity = new Vector2(rb.velocity.x, 4);
                }
                canJump = true;
                jump = false;
            }

            if (Input.GetButtonUp("Jump")) canJump = true;
        }
    }
        void OnCollisionEnter2D(Collision2D collision)
        {
        Debug.Log(3456789);
                jump = true;
        }
}
