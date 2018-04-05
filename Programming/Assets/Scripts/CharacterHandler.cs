using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace RPG
{
    [RequireComponent(typeof(CharacterController))]
    [RequireComponent(typeof(MouseLook))]
    [AddComponentMenu("RPG/Character Handler")]
    public class CharacterHandler : MonoBehaviour
    {
        #region Variables
        [Header("CHARACTER HANDLER")]
        [Space(5)]
        [Header("General")]
        #region Health, Stamina and Mana
        // bool to tell if player is alive or dead 
        public bool alive;
        // max and min health, stamina, mana
        public int maxHealth, maxStamina, maxMana;
        // current and min health, stamina, mana
        public float curHealth, curStamina, curMana;
        #endregion
        /*[Space(3)]
        [Header("Player Stats")]
        #region Stats
        public int charisma;    //measuring force of personality
        public int constitution;//measuring endurance
        public int dexterity;   //measuring agility
        public int strength;    //measuring physical power
        public int wisdom;      //measuring perception and insight
        public int intelligence;//measuring reasoning and memory
        #endregion
        */
        [Space(5)]
        [Header("Levels and Exp")]
        #region Level and Exp
        // player's current level
        public int level;
        // max and current experience
        public int curExp, maxExp;
        #endregion
        /*
        [Space(3)]
        [Header("Weapon Stats")]
        #region Weapon
        public int weaponDamage;//amount of weapon damage we pull from the inventory(when we build one)
        public int ammo, ammoUsed;//ammo amount for this weapon...if it has ammo and how much we use from our clip
        public float coolDown;//the cool down of our weapon
        public bool canAttack, isEquipped;//if we can attack due to cool down and if weapon is equipped 
        public GameObject weaponMount, helmMount, packMount;//item parent locations for weapon, helmets and backpacks
        #endregion
        */
        [Space(5)]
        [Header("Movement Connection")]
        #region Movement Connection
        // vector3 to apply movement in 3D space
        public Vector3 moveDir = Vector3.zero;
        public CharacterController charC;
        #endregion
        [Space(5)]
        [Header("Movement Variables")]
        #region Movement Variables
        public float jumpSpeed = 8.0f;
        public float speed = 6.0f;
        public float walkSpeed = 6, crouchSpeed = 2, sprintSpeed = 14;
        public float gravity = 20.0f;
        public bool movement = true;
        #endregion
        [Space(5)]
        [Header("Camera Connection")]
        #region MiniMap
        // minimap render texture
        public RenderTexture miniMap;
        // minimap camera
        public Camera miniMapCamera;
        // player icon render texture
        public RenderTexture icon;
        // player icon camera
        public Camera iconCamera;
        // first player camera
        public Camera mainCamera;
        #endregion
        [Space(5)]
        [Header("Animations")]
        #region Animator
        // animator for main character model
        public Animator anim; 
        #endregion
        [Space(5)]
        [Header("Check Point Elements")]
        #region Check Points
        // GameObject for our current check point
        public GameObject curCheckPoint;
        #endregion
        [Space(5)]
        [Header("Textures")]
        #region Textures
        // object that renders our model into our scene
        public Renderer meshRenderer;
        // public index values for our texture files armour, clothes, eyes, hair, helm, mouth, skin
        public int armourIndex, clothesIndex, eyesIndex, hairIndex, helmIndex, mouthIndex, skinIndex;
        // public GUI Styles for healthColour, manaColour, staminaColour,expColour, bar, backGround, mapBorder
        public GUIStyle healthColour, manaColour, staminaColour, expColour, bar, backGround, mapBorder;
        #endregion
        #endregion

        void OnGUI()
        {
            #region OnGUI
            //set up our aspect ratio for the GUI elements
            float scrW = Screen.width / 16;
            float scrH = Screen.height / 9;
            float i = 0.5f * scrH;
            float j = (0.25f * scrH) + 7.5f;


            #region Jaymie's suggested code
            /*
            //HEALTH
            //GUI Box on screen for the healthbar background
            GUI.Box(new Rect(scrW - 15f, i * (0.25f * scrH) + (scrH - 25), 1.5f * scrW, 0.25f * scrH), "");
            //GUI Box for current health that moves in same place as the background bar...current Health divided by the position on screen and timesed by the total max health
            GUI.Box(new Rect(scrW - 15f, i * scrH + (scrH - 25), curHealth * (1.5f * scrW) / maxHealth, 0.25f * scrH), "");
            //GUI Box Health Border
            GUI.Box(new Rect(scrW - 12.5f, i * scrH + (scrH - 27.5f), (1.5f * scrW) + 5f, (0.25f * scrH) + 5f), "");
            i++;
            //MANA
            //GUI Box background bar
            GUI.Box(new Rect(scrW - 15f, i * (0.25f * scrH) + (scrH - 25), 1.5f * scrW, 0.25f * scrH), "");
            //GUI Box background bar//GUI Box for current  that moves in same place as the background bar...current  divided by the position on screen and timesed by the total max 
            GUI.Box(new Rect(scrW - 15f, i * (0.25f * scrH) + (scrH - 25), curMana * (1.5f * scrW) / maxMana, 0.25f * scrH), "");
            //GUI Box Mana Border
            GUI.Box(new Rect(scrW - 12.5f, i * scrH + (scrH - 27.5f), (1.5f * scrW) + 5f, (0.25f * scrH) + 5f), "");
            i++;
            //STAMNINA
            //GUI Box background bar
            GUI.Box(new Rect(scrW - 15f, i * (0.25f * scrH) + (scrH - 25), 1.5f * scrW, 0.25f * scrH), "");
            //GUI Box for current  that moves in same place as the background bar...current  divided by the position on screen and timesed by the total max
            GUI.Box(new Rect(scrW - 15f, i * (0.25f * scrH) + (scrH - 25), curStamina * (1.5f * scrW) / maxStamina, 0.25f * scrH), "");
            //GUI Box Stamina Border
            GUI.Box(new Rect(scrW - 12.5f, i * (0.25f * scrH) + (scrH - 27.5f), (1.5f * scrW) + 5f, (0.25f * scrH) + 5f), "");
            */
            #endregion

            //HEALTH
            //GUI Box on screen for the healthbar background
            GUI.Box(new Rect(2 * scrW + 15f, i, 3.5f * scrW, 0.25f * scrH), "");
            //GUI Box for current health that moves in same place as the background bar...current Health divided by the position on screen and timesed by the total max health
            GUI.Box(new Rect(2 * scrW + 15f, i, curHealth * (3.5f * scrW) / maxHealth, 0.25f * scrH), "");
            //GUI Box Health Border
            GUI.Box(new Rect(2 * scrW + 12.5f, i - 2.5f, (3.5f * scrW) + 5f, (0.25f * scrH) + 5f), "");

            //MANA
            //GUI Box background bar
            GUI.Box(new Rect(2 * scrW + 15f, (i - 2.5f) + (j), 3.5f * scrW, 0.25f * scrH), "");
            //GUI Box background bar//GUI Box for current  that moves in same place as the background bar...current  divided by the position on screen and timesed by the total max 
            GUI.Box(new Rect(2 * scrW + 15f, (i - 2.5f) + (j), curMana * (3.5f * scrW) / maxMana, 0.25f * scrH), "");
            //GUI Box Mana Border
            GUI.Box(new Rect(2 * scrW + 12.5f, (i - 2.5f) + ((0.25f * scrH) + 5f), (3.5f * scrW) + 5f, (0.25f * scrH) + 5f), "");

            //STAMNINA
            //GUI Box background bar
            GUI.Box(new Rect(2 * scrW + 15f, (i - 2.5f) + 2 * (j - 1.125f), 3.5f * scrW, 0.25f * scrH), "");
            //GUI Box for current  that moves in same place as the background bar...current  divided by the position on screen and timesed by the total max
            GUI.Box(new Rect(2 * scrW + 15f, (i - 2.5f) + 2 * (j - 1.125f), curStamina * (3.5f * scrW) / maxStamina, 0.25f * scrH), "");
            //GUI Box Stamina Border
            GUI.Box(new Rect(2 * scrW + 12.5f, (i - 2.5f) + 2 * (j - 2.5f), (3.5f * scrW) + 5f, (0.25f * scrH) + 5f), "");


            //EXP
            //GUI Box background bar
            GUI.Box(new Rect(2 * scrW + 15f, (i - 2.5f) + 3 * (j - 1.5f * 1.125f), 3.5f * scrW, 0.25f * scrH), "");
            //GUI Box for current  that moves in same place as the background bar...current divided by the position on screen and timesed by the total max
            GUI.Box(new Rect(2 * scrW + 15f, (i - 2.5f) + 3 * (j - 1.5f * 1.125f), curExp * (3.5f * scrW) / maxExp, 0.25f * scrH), "");
            //GUI Box Exp Border
            GUI.Box(new Rect(2 * scrW + 12.5f, (i - 2.5f) + 3 * (j - 2.5f), (3.5f * scrW) + 5f, (0.25f * scrH) + 5f), "");

            //MINIMAP
            //GUI Draw Texture on the screen that has the mini map render texture attached
            GUI.Box(new Rect((14f * scrW) + 2.5f, (0.25f * scrH) + 2.5f, (2f * scrW), (2 * scrH) - 5f), miniMap);
            //GUI Box MiniMap Border
            GUI.Box(new Rect(14f * scrW, 0.25f * scrH, 2 * scrW + 5f, 2 * scrH), "");

            //ICON
            //GUI Box Icon BackGround
            GUI.Box(new Rect(0.5f * scrW + 2.5f, i, 4 * ((0.25f * scrW) + 5f), 4 * ((0.25f * scrH) + 5f) - 5f), "");
            //GUI Draw Texture on the screen that has the icon render texture attached
            GUI.Box(new Rect(0.5f * scrW + 2.5f, i, 4 * ((0.25f * scrW) + 5f) - 5f, 4 * ((0.25f * scrH) + 5f) - 5f), icon);
            //GUI Box Border
            GUI.Box(new Rect(0.5f * scrW, i - 2.5f, 4 * ((0.25f * scrW) + 5f) - 2.5f, 4 * ((0.25f * scrH) + 5f)), "");
            #endregion
        }
        void Update()
        {
            Movement();
            CheckPoint();
            ExpHandler();
            PickUpHandler();
        }
        void Movement()
        {
            if (movement)
            {

                // character is grounded
                if (charC.isGrounded)
                {

                    // moveDir is equal to a new vector3 that is affected by Input.Get Axis; Horizontal, 0, Vertical
                    moveDir = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));

                    //moveDir is transformed in the direction of our moveDir
                    //moveDir = MouseLook.RotationalAxis.MouseX;

                    //  moveDir multiplied by speed
                    moveDir *= speed;
                    // can jump if grounded
                    if (Input.GetKeyDown(KeyCode.Space))
                    {
                        moveDir.y = jumpSpeed;
                    }
                }

            }

            // gravity will always act upon the player, and we multiply by time.deltatime to normalise it
            moveDir.y -= gravity * Time.deltaTime;
            // we then allow the character to move in the direction, multiplied by time.deltatime
            charC.Move(moveDir * Time.deltaTime);
        }
        void LateUpdate()
        {
            HealthCaps();
        }
        void CheckPoint()
        {
            #region Update
            // current health is less than or equal to zero, meaning the player is already dead
            if (curHealth <= 0)
            {
                // move player to previous checkpoint
                transform.position = curCheckPoint.transform.position;
                // restore player to full health
                curHealth = maxHealth;
                alive = true;
                charC.enabled = true;
            }
            #endregion
        }
        void HealthCaps()
        {
            if (curHealth > maxHealth)
            {
                //cap current health to max health
                curHealth = maxHealth;
            }
            // if current health is less than zero, character is dead
            if (curHealth <= 0)
            {
                // negative cap health
                curHealth = 0;
            }
            if (alive == true && curHealth <= 0)
            {
                alive = false;
                charC.enabled = false;
            }
        }
        void ExpHandler()
        {
            // if our current experience is greater or equal to the maximum experience
            if (curExp >= maxExp)
            {
                // current experience is equal to the difference between current exp and max exp
                curExp = curExp - maxExp;
                // level up
                level++;
                // next level exp requirement is increased by 50
                maxExp += 50;
            }
        }
        void PickUpHandler()
        {
            // if our interact key is pressed
            if (Input.GetKeyDown(KeyCode.E))
            {
                // create a ray
                Ray interact;
                // ray drawn from the main cameras screen point center of screen
                interact = Camera.main.ScreenPointToRay(new Vector2(Screen.width / 2, Screen.height / 2));
                // create hit info
                RaycastHit hitinfo;
                // if this physics raycast hits something within 10 units
                if (Physics.Raycast(interact, out hitinfo, 10))
                {
                    #region NPC tag
                    // if rayhit object is tagged NPC
                    if (hitinfo.collider.CompareTag("NPC"))
                    {
                        // Debug that we hit an NPC
                        Debug.Log("Hit the NPC");
                        // grab the dialoge script off the npc that we hit
                        Dialogue dlg = hitinfo.transform.GetComponent<Dialogue>();
                        // if that dialogue script exists on the NPC
                        if (dlg != null)
                        {
                            // turn the dialogue on and display it
                            dlg.showDlg = true;
                            // get the player's mouselook script and turn it off
                            GetComponent<MouseLook>().enabled = false;
                            // get the players movement script and turn it off
                            GetComponent<CharacterHandler>().movement = false;
                            // allow the cursor to move on screen
                            Cursor.lockState = CursorLockMode.None;
                            // and allow the cursor to be visible on screen
                            Cursor.visible = true;
                        }
                    }
                    #endregion
                    #region Item
                    // rayhit info is tagged Item
                    if (hitinfo.collider.CompareTag("Item"))
                    {
                        //Debug that we hit an Item
                        Debug.Log("Hit an Item");
                    }
                    #endregion
                }
            }

        }

        #region OnTriggerEnter
        void OnTriggerEnter(Collider other)
        {
            // if other object's tag is CheckPoint
            if (other.CompareTag("Checkpoint"))
            {
                // our checkpoint is equal to the other object
                curCheckPoint = other.gameObject;
                // save our SpawnPoint as the name of that object            
                PlayerPrefs.SetString("SpawnPoint", curCheckPoint.name);
            }
            #endregion
        }
    }
}