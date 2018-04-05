using UnityEngine;
using System.Collections;

namespace RPG
{
    [AddComponentMenu("Character Set Up/Interact")]
    public class PickUp : MonoBehaviour
    {
        #region Variables
        [Header("Player and Camera Connection")]
        public GameObject player;
        public GameObject mainCam;
        #endregion

        #region Start
        void Start()
        {
            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;
            player = GameObject.FindGameObjectWithTag("Player");
            mainCam = GameObject.FindGameObjectWithTag("MainCamera");
        }

        #endregion

        #region Update
        void Update()
        {
            // if interact key is pressed
            if (Input.GetKeyDown(KeyCode.E))
            {
                Ray interact;
                // ray drawn from camera to center of screen
                interact = Camera.main.ScreenPointToRay(new Vector2(Screen.width / 2, Screen.height / 2));
                RaycastHit hitinfo;
                // if the ray hits an object within 10 units
                if (Physics.Raycast(interact, out hitinfo, 10))
                {
                    #region NPC tag
                    // if object's tag is "NPC"
                    if (hitinfo.collider.CompareTag("NPC"))
                    {
                        // debug statement
                        Debug.Log("Hit the NPC");
                        // get dialogue script off of NPC 
                        Dialogue dlg = hitinfo.transform.GetComponent<Dialogue>();
                        // if the NPC's dialogue exists
                        if (dlg != null)
                        {
                            // show dialogue
                            dlg.showDlg = true;
                            // deactivate player's mouselook
                            player.GetComponent<MouseLook>().enabled = false;
                            // deactivate player's movement
                            player.GetComponent<CharacterHandler>().movement = false;
                            // unlock cursor movement
                            Cursor.lockState = CursorLockMode.None;
                            // show cursor
                            Cursor.visible = true;
                        }
                    }
                    #endregion
                    #region Item
                    // if object's tag is "Item"
                    if (hitinfo.collider.CompareTag("Item"))
                    {
                        // debug statment
                        Debug.Log("Hit an Item");
                    }
                    #endregion
                }
            }
        }
        #endregion
    }






}