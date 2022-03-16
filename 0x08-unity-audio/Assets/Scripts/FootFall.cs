using UnityEngine;

public class FootFall : MonoBehaviour
{
    public AudioClip grassStepSFX;
    public AudioClip rockStepSFX;
    public AudioClip grassLandingSFX;
    public AudioClip rockLandingSFX;
    public GameObject player;
    private string surface;
    private bool grounded;

    public void FootstepSFX()
    {
        grounded = player.GetComponent<PlayerController>().onGround();
        if (grounded)
        {
            if (player.GetComponent<PlayerController>().surfaceType() == "Stone")
                GetComponent<AudioSource>().PlayOneShot(rockStepSFX);
            else
                GetComponent<AudioSource>().PlayOneShot(grassStepSFX);
        }
    }

    public void Landing()
    {
        if (player.GetComponent<PlayerController>().surfaceType() == "Stone")
            GetComponent<AudioSource>().PlayOneShot(rockLandingSFX);
        else
            GetComponent<AudioSource>().PlayOneShot(grassLandingSFX);
    }
}
