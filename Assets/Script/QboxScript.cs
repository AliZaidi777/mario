using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QboxScript : MonoBehaviour
{
    public Animator animator;
    public GameObject coin;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        animator.SetInteger("b", 3);
        coin.SetActive(true);
    }
}
