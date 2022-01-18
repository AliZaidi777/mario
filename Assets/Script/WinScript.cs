using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class WinScript : MonoBehaviour
{
    public GameObject gameover;
    public GameObject WinFlag;
   // public GameObject Mario;

    void Start()
    {
        StartCoroutine(Example());
    }

    IEnumerator Example()
    {
        yield return new WaitForSeconds(5);
        gameover.SetActive(true);
    }
    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.tag == "DTile")
        {
           // Mario.SetActive(false);
            WinFlag.SetActive(true);
            StartCoroutine(Example());
        }
    }
}
