using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RPG
{
    [AddComponentMenu("Player/Camera/FirstPerson")]

    public class MouseLook : MonoBehaviour
    {
        
        [Header("Sensitivity")]
        public float sensitivityX;
        public float sensitivityY;
        [Space(5)]
        [Header("Max and Min Clamping")]
        // cap the rotational speed of the camera
        public float minimumY = -60;
        public float maximumY = 60;
        float rotationY = 0;
        [Space(5)]
        [Header("Rotation Type")]
        public RotationalAxis axis = RotationalAxis.MouseX;
        public enum RotationalAxis
        {
            MouseXAndY = 0,
            MouseX = 1,
            MouseY = 2
        }


        void Start()
        {
            // freeze current rigibody's rotation, and hide and lock cursor

            if (this.GetComponent<Rigidbody>())
            {
                this.GetComponent<Rigidbody>().freezeRotation = true;
            }

            Cursor.visible = false;
            Cursor.lockState = CursorLockMode.Locked;
        }

        void Update()
        {
            // if mouse movement is on both x and y planes
            if (axis == RotationalAxis.MouseXAndY)
            {
                // multiply the x and y mouse movements by their sensitivities
                float rotationX = transform.localEulerAngles.y + Input.GetAxis("Mouse X") * sensitivityX;
                rotationY += Input.GetAxis("Mouse Y") * sensitivityY;
                // cap the rotation speed
                rotationY = Mathf.Clamp(rotationY, minimumY, maximumY);
                // rotate the camera 
                transform.localEulerAngles = new Vector3(-rotationY, rotationX, 0);
            }
            // otherwise if mouse movement is only on x plane
            else if (axis == RotationalAxis.MouseX)
            {
                // rotate camera
                transform.Rotate(0, Input.GetAxis("Mouse X") * sensitivityX, 0);
            }
            // otherwise mouse movement is only on y plane
            else
            {
                // multiply y movement by sensitivity
                rotationY += Input.GetAxis("Mouse Y") * sensitivityY;
                // cap the rotation speed
                rotationY = Mathf.Clamp(rotationY, minimumY, maximumY);
                // rotate camera
                transform.localEulerAngles = new Vector3(-rotationY, transform.localEulerAngles.y, 0);
            }


            /*
            if (Input.GetKeyDown(KeyCode.Escape)){
                if(Cursor.visible == false)
                {
                    Cursor.visible = true;
                    Cursor.lockState = CursorLockMode.None;
                }
                else
                {
                    Cursor.visible = false;
                    Cursor.lockState = CursorLockMode.Locked;
                }
            }
            */
        }


 





    }


}