using System.Collections;
using System.Collections.Generic;
using UnityEngine;



// This script can be found in the Component sectoin under the option NPC/Dialogue
namespace RPG
{
    [AddComponentMenu("NPC/Diaogue")]
    public class Dialogue : MonoBehaviour
    {

        #region Variables
        [Header("Reference")]

        public string[] negText, neuText, posText;
        // int showing how much the npc likes us
        public int approval;
        // displayed dialogue
        private string[] text;
        public string response1, response2;

        // boolean to toggle if we can see a characters dialogue box
        public bool showDlg;
        // index for our current line of dialogue and an index for a set question marke of the dialogue
        public int index, optionsIndex;
        // object reference to the player
        public GameObject player;
        // mouselok script reference for the maincamera
        public MouseLook mainCam;
        [Header("NPC Name and Dialogue")]
        // name of this specific NPC
        public string npcName;

        public GUIStyle dlgBg, next, optBut, exit;


        #endregion

        #region Start
        void Start()
        {
            // find and reference the player object by tag
            player = GameObject.FindGameObjectWithTag("Player");
            // find reference the mainCamera by tag and get the mouse look component
            mainCam = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<MouseLook>();
            text = new string[5];
            for (int i = 0; i < text.Length; i++)
            {
                text[i] = neuText[i];
            }

        }
        #endregion

        #region Update
        void Update()
        {
            if (approval <= -1)
            {
                text = negText;
            }

            if (approval == 0)
            {
                text = neuText;
            }
            if (approval >= 1)
            {
                text = posText;
            }
        }

        #endregion

        #region OnGUI
        void OnGUI()
        {
            if (showDlg)
            {
                float scrW = Screen.width / 16;
                float scrH = Screen.height / 9;
                // the dialogue box is in bottom 3rd of the screen and displays the NPC's name and current dialogue line
                GUI.Box(new Rect(0, 6 * scrH, Screen.width, 3 * scrH), npcName + ": " + text[index], dlgBg);
                // if not a the end of the dialogue or not at the options selection
                if (!(index + 1 >= text.Length || index == optionsIndex))
                {
                    // next button allows us to progress dialogue
                    if (GUI.Button(new Rect(15 * scrW, 8.5f * scrH, scrW, 0.5f * scrH), "", next))
                    {
                        index++;
                    }
                }

                else if (index == optionsIndex)
                {
                    // next button allows us to progress dialogue, and increases approval rating
                    if (GUI.Button(new Rect(14 * scrW, 8f * scrH, scrW, 0.5f * scrH), response1, optBut))
                    {
                        approval++;
                        index++;
                    }
                    // decline button progresses to end of dialogue, and reduces approval rating
                    if (GUI.Button(new Rect(15 * scrW, 8f * scrH, scrW, 0.5f * scrH), response2, optBut))
                    {
                        approval--;
                        index++;
                    }
                }

                else
                {
                    // end dialogue button
                    if (GUI.Button(new Rect(15 * scrW, 8f * scrH, scrW, 0.5f * scrH), "", exit))
                    {
                        showDlg = false;
                        index = 0;
                        mainCam.enabled = true;
                        // reactivate player's mouselook function
                        player.GetComponent<MouseLook>().enabled = true;
                        // reactivate player's movement
                        player.GetComponent<CharacterHandler>().movement = true;
                        // relock the mouse cursor
                        Cursor.lockState = CursorLockMode.Locked;
                        // hide cursor
                        Cursor.visible = false;
                    }
                }



            }
        }

        #endregion



    }
}