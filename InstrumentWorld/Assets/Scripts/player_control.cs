using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class player_control : MonoBehaviour
{
    float speed = 4;
    float run_speed = 6;
    float jump_speed = 6;
    float rot_speed = 80;
    float rot = 0f;
    float gravity = 8;

    Vector3 moveDir = Vector3.zero;

    CharacterController cont;
    Animator anim;

    // Start is called before the first frame update
    void Start()
    {
        cont = GetComponent<CharacterController>();
        anim = GetComponent<Animator> ();
    }

    // Update is called once per frame
    void Update()
    {
        Movement();
    }

    void Movement()
    {
        if (cont.isGrounded)
        {
            //Eteenpäin liikkuminen
            if (Input.GetKey(KeyCode.W))
            {
                anim.SetInteger("condition", 1);
                moveDir = new Vector3(0, 0, 1) * speed;
                moveDir = transform.TransformDirection(moveDir);

                //Juokseminen
                if (Input.GetKey(KeyCode.LeftShift))
                {
                    anim.SetInteger("condition", 2);
                    moveDir = new Vector3(0, 0, 1) * run_speed;
                    moveDir = transform.TransformDirection(moveDir);
                }
                if (Input.GetKeyUp(KeyCode.LeftShift))
                {
                    anim.SetInteger("condition", 1);
                    moveDir = new Vector3(0, 0, 1) * speed;
                    moveDir = transform.TransformDirection(moveDir);
                }
            }
            if (Input.GetKeyUp(KeyCode.W))
            {
                anim.SetInteger("condition", 0);
                moveDir = new Vector3(0, 0, 0);
                moveDir = transform.TransformDirection(moveDir);
            }

            //Taaksepäin liikkuminen
            if (Input.GetKey(KeyCode.S))
            {
                anim.SetInteger("condition", 3);
                moveDir = new Vector3(0, 0, -1) * speed;
                moveDir = transform.TransformDirection(moveDir);
            }
            if (Input.GetKeyUp(KeyCode.S))
            {
                anim.SetInteger("condition", 0);
                moveDir = new Vector3(0, 0, 0);
                moveDir = transform.TransformDirection(moveDir);
            }

            //Hyppy
            if (Input.GetKey(KeyCode.Space))
            {
                anim.SetInteger("condition", 4);
                moveDir += new Vector3(0, 1, 0) * jump_speed;
                moveDir = transform.TransformDirection(moveDir);
            }
            if (Input.GetKeyUp(KeyCode.Space))
            {
                anim.SetInteger("condition", 0);
                moveDir = new Vector3(0, 0, 0);
                moveDir = transform.TransformDirection(moveDir);
            }
        }

        //hätäpysähdys
        if (Input.GetKey(KeyCode.E))
        {
            anim.SetInteger("condition", 0);
            moveDir = new Vector3(0, 0, 0);
            moveDir = transform.TransformDirection(moveDir);
        }

        rot += Input.GetAxis("Horizontal") * rot_speed * Time.deltaTime;
        transform.eulerAngles = new Vector3(0, rot, 0);

        moveDir.y -= gravity * Time.deltaTime;
        cont.Move(moveDir * Time.deltaTime);
    }
}
