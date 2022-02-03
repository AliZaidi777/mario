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
       // StartCoroutine(Example());
    }

    IEnumerator Example()
    {
        yield return new WaitForSeconds(2);
        gameover.SetActive(true);
        Time.timeScale = 0;
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "DTile")
        {
            // Mario.SetActive(false);
            Debug.Log(32333320);
            WinFlag.SetActive(true);
            StartCoroutine(Example());
        }
    }
}
