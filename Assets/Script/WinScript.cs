using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class WinScript : MonoBehaviour
{
    void  OnTriggerEnter2D(Collider2D other)
    {
        if(other.tag == "mario")
        {
            SceneManager.LoadScene("win");
        }
    }
}
