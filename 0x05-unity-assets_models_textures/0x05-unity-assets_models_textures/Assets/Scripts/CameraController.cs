using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    // Start is called before the first frame update
    public Transform player;
    public Vector3 offset;
    public float speedCamera = 3f; 
    Quaternion vertical;
    Quaternion horizontal;

    void Start()
    {
        offset = new Vector3(0, 2.5f, -6.25f);
    }

    // Update is called once per frame
    void LateUpdate()
    {
        if (Input.GetMouseButton(1))
        {
            horizontal = Quaternion.AngleAxis(Input.GetAxis("Mouse X") * speedCamera, Vector3.up);
            vertical = Quaternion.AngleAxis(Input.GetAxis("Mouse Y") * speedCamera, Vector3.left);
            offset = horizontal * vertical * offset;
        }
            transform.position = player.position + offset;
            transform.LookAt(player.position + new Vector3(0, 0.24f, 0));
    }
}
