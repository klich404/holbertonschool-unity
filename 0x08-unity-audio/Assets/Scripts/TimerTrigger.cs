using UnityEngine;

public class TimerTrigger : MonoBehaviour
{
    // Sent to all GameObjects before the application quits
    void OnTriggerExit(Collider other)
    {
        if (other.name == "Player")
            other.gameObject.GetComponent<Timer>().enabled = true;
    }
}
