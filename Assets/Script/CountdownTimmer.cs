using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class CountdownTimmer : MonoBehaviour
{
    float currentTime = 0f;
    float startingTime = 60f;
    public TextMeshProUGUI countDownText;
    public GameObject gameover;
    void Start()
    {
        currentTime = startingTime;
    }

    void Update()
    {
        currentTime -= 1 * Time.deltaTime;
        countDownText.text = currentTime.ToString("0");

        if(currentTime <= 0)
        {
            gameover.SetActive(true);
            currentTime = 0;
        }

    }

}
