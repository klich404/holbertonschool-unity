using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private CharacterController player;
    private Transform p2;
    public Transform cam;
    public float speed = 10f;
    public float jump = 13f;
    float vertical;
    Vector3 move = Vector3.zero;

    void Awake()
    {
        player = GetComponent<CharacterController>();
        p2 = GetComponent<Transform>();
    }

    void Update()
    {
        vertical = move.y;
        move = Vector3.zero;
        if (Input.GetKey("w"))
            move = Vector3.forward + move;
        if (Input.GetKey("s"))
            move = Vector3.back + move;
        if (Input.GetKey("d"))
            move = Vector3.right + move;
        if (Input.GetKey("a"))
            move = Vector3.left + move;
        move = ((cam.right * move.x) + (cam.forward * move.z)) * speed;
        if (player.isGrounded)
        {
            if (Input.GetKey("space"))
                vertical = jump;
            else
                vertical = 0;
        }
        move.y = vertical;
        move.y = move.y - (20 * Time.deltaTime);
        if(p2.position.y < -30.0f)
            move = Vector3.zero;
        player.Move(move * Time.deltaTime);
        if (p2.position.y < -30.0f)
            p2.position = new Vector3(0, 10, 0);
        if (Input.GetKey("escape"))
            Application.Quit();
    }
}
