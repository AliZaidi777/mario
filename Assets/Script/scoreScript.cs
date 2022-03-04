using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class scoreScript : MonoBehaviour
{
    public TextMeshProUGUI point;
    public TextMeshProUGUI Hscore;
    int x = 0;
    public GameObject Aenemy;
    public GameObject Benemy;

    void Start()
    {
        Hscore.text = PlayerPrefs.GetInt("HighScore", 0).ToString();
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "coin")
        {
            x = x + 200;
            point.text = x.ToString();
        }
        if (collision.gameObject.tag == "A")
        {
            x = x + 200;
            point.text = x.ToString();
            Aenemy.SetActive(true);
        }
        if (collision.gameObject.tag == "poweUp")
        {
            x = x + 1000;
            point.text = x.ToString();
            Destroy(collision.gameObject);
        }
        if (collision.gameObject.tag == "B")
        {
            x = x + 200;
            point.text = x.ToString();
            Benemy.SetActive(true);
        }
        if (collision.gameObject.tag == "poweUp")
        {
            x = x + 1000;
            point.text = x.ToString();
            Destroy(collision.gameObject);
        }
        if (collision.gameObject.tag == "stick")
        {
            x = x + 2000;
            point.text = x.ToString();
        }
        if (collision.gameObject.tag == "enemy")
        {
            x = x + 300;
            point.text = x.ToString();
        }
        if(x > PlayerPrefs.GetInt("HighScore", 0))
        {
            PlayerPrefs.SetInt("HighScore", x);
            Hscore.text = PlayerPrefs.GetInt("HighScore").ToString();
        }
    }

}
