using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private CharacterController player;
    private Transform p2;
    private Transform ty;
    private Vector3 move = Vector3.zero;
    private Vector3 face = Vector3.zero;
    private Quaternion rot;
    private Animator anim;
    private float fall = 0f;
    private float vertical;
    public Transform cam;
    public float speed = 10f;
    public float jump = 13f;

    // Is called when the script instance is being loaded
    void Awake()
    {
        //Cursor.visible = false;
        player = GetComponent<CharacterController>();
        p2 = GetComponent<Transform>();
        ty = p2.Find("ty");
        anim = ty.GetComponent<Animator>();
    }

    // Update is called once per frame
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
            fall = 0;
            anim.SetBool("Grounded", true);
            if (Input.GetKey("space"))
            {
                vertical = jump;
                anim.SetTrigger("Jump");
            }
            else
                vertical = 0;
        }
        else
        {
            fall += Time.deltaTime;
            anim.SetBool("Grounded", false);
        }
        if (move != Vector3.zero)
        {
            face = new Vector3(move.x, 0, move.z);
            anim.SetBool("Moving", true);
        }
        else
            anim.SetBool("Moving", false);
        move.y = vertical;
        move.y = move.y - (20 * Time.deltaTime);
        player.Move(new Vector3(move.x, move.y, move.z) * Time.deltaTime);
        if(move != Vector3.zero)
        {
            rot = Quaternion.LookRotation(face);
            ty.rotation = rot;
        }
        anim.SetFloat("Fall", fall);
        if (p2.position.y < -30.0f)
            p2.position = new Vector3(0, 20, 0);
    }
}
