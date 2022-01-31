using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class scoreScript : MonoBehaviour
{
    public TextMeshProUGUI point;
    int x = 0;
    public GameObject Aenemy;

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "coin")
        {
            x = x + 200;
            point.text = x.ToString();
        }
        if (collision.gameObject.tag == "A")
        {
            Debug.Log(234);
            Aenemy.SetActive(true);
        }
        if (collision.gameObject.tag == "Aenemy")
        {
            Debug.Log(213);
            x = x + 1000;
            Destroy(collision.gameObject);
        }
    }

}
