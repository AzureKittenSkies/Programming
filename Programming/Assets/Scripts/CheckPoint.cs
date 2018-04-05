using UnityEngine;
using System.Collections;

namespace RPG
{
    [AddComponentMenu("Character Setup/Checkpoint")]
    public class CheckPoint : MonoBehaviour
    {
        #region Variables
        [Header("Check Point Elements")]
        public GameObject curCheckPoint;
        [Header("Character Handler")]
        // character handler script that holds the player's information
        public GameObject charH;
        #endregion
        #region Start
        void Start()
        {
            #region playerprefs spawnpoint key
            //if we have a save key called SpawnPoint
            if (PlayerPrefs.HasKey("SpawnPoint"))
            {
                // current checkpoint is set to stored spawnpoint
                curCheckPoint = GameObject.Find(PlayerPrefs.GetString("SpawnPoint"));
                // move player to that checkpoint
                this.transform.position = curCheckPoint.transform.position;
            }
            #endregion
        }
        #endregion

        #region Update
        void Update()
        {
            /*
            //if our characters health is less than or equal to 0
            if (false)
            {
                //our transform.position is equal to that of the checkpoint
                this.transform.position = curCheckPoint.transform.position;
                //our characters health is equal to full health
                //charH.curHealth = charH.maxHealth;
                //character is alive
                //charH.alive = true;
                //characters controller is active		
                CharacterController controller = this.GetComponent<CharacterController>();
                controller.enabled = true;
            }
            */
        }
        #endregion
        #region OnTriggerEnter
        //Collider other
        void OnTriggerEnter(Collider other)
        {
            // if compared object's tag is "Checkpoint"
            if (other.CompareTag("Checkpoint"))
            { 
                curCheckPoint = other.gameObject;
                //save our SpawnPoint as the name of that object
                PlayerPrefs.SetString("SpawnPoint", curCheckPoint.name);
            }
        }
        #endregion
    }
}





