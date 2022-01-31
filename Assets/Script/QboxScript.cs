using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QboxScript : MonoBehaviour
{
    public Animator animator;
    public GameObject coin;
    int x;
    void Start()
    {
        x = 0;
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(x == 0)
        {
            animator.SetInteger("b", 3);
            coin.SetActive(true);

            x = 1;
        }
    }
}
