using System;
using UnityEngine;
using TMPro;

public class GameManager : MonoBehaviour
{
    public TextMeshProUGUI timerText;
    public float timer = 60.0f;

    // Start is called before the first frame update
    void Start()
    {
        // timer = 60.0f;
    }

    // Update is called once per frame
    void Update()
    {
        timer -= Time.deltaTime;
        timerText.text = "Timer: " + Math.Round(timer);
        if (Math.Round(timer) == 0)
        {
            timer = 60.0f;
            Debug.Log("Time out!");
        }
    }
}
