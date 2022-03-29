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
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (x == 0)
        {
            if (MarioMovement.coinIs == true)
            {

                animator.SetInteger("b", 3);
                coin.SetActive(true);
              MarioMovement.coinIs = false;
            }
        }
    }
}
