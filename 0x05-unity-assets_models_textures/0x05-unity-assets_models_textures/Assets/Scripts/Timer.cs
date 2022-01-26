using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{
    public Text TimerText;
    float time = 0f;
    int mins = 0;
    float secs = 0.00f;

    // Update is called once per frame
    void Update()
    {
        time += Time.deltaTime;
        mins = (int) time / 60;
        secs =  time % 60f;
        TimerText.text = mins.ToString() + ":" + secs.ToString("00.00");
    }
}
