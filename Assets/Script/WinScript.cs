using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class WinScript : MonoBehaviour
{
    public GameObject gameover;
    void  OnTriggerEnter2D(Collider2D other)
    {
        if(other.tag == "DTile")
        {
            //SceneManager.LoadScene("win");
            gameover.SetActive(true);
        }
    }
}
