using UnityEngine;
using UnityEngine.UI;

public class WinTrigger : MonoBehaviour
{
    public Text timerText;
    public GameObject winCanvas;
    public GameObject timer;

    // When a GameObject collides with another GameObject, Unity calls OnTriggerEnter
    void OnTriggerEnter(Collider other)
    {
        if (other.name == "Player")
        {
            other.gameObject.GetComponent<Timer>().enabled = false;
            timer.SetActive(false);
            winCanvas.SetActive(true);
        }
    }
}
