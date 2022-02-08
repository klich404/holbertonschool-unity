using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WinTrigger : MonoBehaviour
{
    public Text timerText;

    // When a GameObject collides with another GameObject, Unity calls OnTriggerEnter
    void OnTriggerEnter(Collider other)
    {
        if (other.name == "Player")
            other.gameObject.GetComponent<Timer>().enabled = false;
            timerText.fontSize = 60;
            timerText.color = Color.green;
    }
}
