using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Player.Movement.CharController
{
    [RequireComponent(typeof(CharacterController))]
    public class Movement : MonoBehaviour
    {
        public Vector3 moveDir = Vector3.zero;
        public CharacterController charC;
        public float jumpSpeed = 8;
        public float walkSpeed = 6;
        public float sprintSpeed = 10;
        public float crouchSpeed = 3;
        public float gravity = 20;
        public float speed;

        public float stamina = 100;



        public Animator anim;
        float timer = 0f;


        // Use this for initialization
        void Start()
        {
            charC = this.GetComponent<CharacterController>();
            float speed = walkSpeed;
        }

        // Update is called once per frame
        void Update()
        {


            if (charC.isGrounded)
            {
                

                
                // When Left Shift is pressed, set speed to sprintspeed
                if (Input.GetKeyDown(KeyCode.LeftShift))
                {
                    speed = sprintSpeed;
                }
                // When Left shift is released, set speed to walkspeed 
                if (Input.GetKeyUp(KeyCode.LeftShift))
                {
                    speed = walkSpeed;
                }
                

                // Wihle Left shift is pressed, set speed to sprintspeed
                if (Input.GetKey(KeyCode.LeftShift))
                {
                    speed = sprintSpeed;
                }

                
                if (Input.GetKey(KeyCode.LeftControl))
                {
                    speed = crouchSpeed;
                }
                

                // Reset speed to walk speed
                else
                {
                    speed = walkSpeed;
                }

               

                moveDir = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));
                moveDir = transform.TransformDirection(moveDir);
                moveDir *= speed;
                if (Input.GetButton("Jump"))
                {
                    anim.SetBool("Jump", true);
                    //moveDir.y = jumpSpeed;
                }
            }
            if (anim.GetBool("Jump") == true)
            {
                timer += Time.deltaTime;
                if (timer >= 0.15f)
                {
                    anim.SetBool("Jump", false);
                    timer = 0;
                }

            }   if (Input.GetAxis("Horizontal") > 0.1 || Input.GetAxis("Horizontal") < -0.1 || Input.GetAxis("Vertical") > 0.1 || Input.GetAxis("Vertical") < -0.1)
                {
                    anim.SetBool("Movement", true);
                }
                else
                {
                    anim.SetBool("Movement", false);
                }
                if (Input.GetKeyDown(KeyCode.LeftControl))
                {
                    anim.SetBool("Crouch", true);
                    //moveDir.y = jumpSpeed;
                }

                if (Input.GetKeyUp(KeyCode.LeftControl))
                {
                    anim.SetBool("Crouch", false);
                    //moveDir.y = jumpSpeed;
                }
                if (Input.GetKeyDown(KeyCode.LeftShift))
                {
                    anim.SetBool("Sprint", true);
                }
                if (Input.GetKeyUp(KeyCode.LeftShift))
                {
                    anim.SetBool("Sprint", false);
                }

            
            moveDir.y -= gravity * Time.deltaTime;
            charC.Move(moveDir * Time.deltaTime);

        }
    }
}