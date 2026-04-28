/**********************************************************************************************************************
// File Name : EndScript.cs
// Author : Darryn C. Gorman
// Creation Date : April 1, 2026
//
// Brief Description : Handles all of the scenes transitions and UI in the build and editor. Also keeps track of all
                       functions such as collectables
**********************************************************************************************************************/
    using TMPro;
    using UnityEditor;
    using UnityEngine;
    using UnityEngine.InputSystem;
    using UnityEngine.SceneManagement;

    public class GameManager : MonoBehaviour
    {

        [SerializeField] private TextMeshProUGUI enemyRemain;
        [SerializeField] private GameObject platform1;
        [SerializeField] private TextMeshProUGUI doorOpen;

        private int collectables;
        private DoorManager doorManager;

        private InputAction restart;
        private InputAction exit;

        /// <summary>
        /// At the start of the scene all fields are set and enable
        /// </summary>
        private void Start()
        {
            restart = InputSystem.actions.FindAction("Restart");
            restart.performed += RestartPerformed;

            exit = InputSystem.actions.FindAction("Exit");
            exit.performed += ExitPerformed;

            doorManager = FindFirstObjectByType<DoorManager>();

            collectables = 0;
            platform1.gameObject.SetActive(false);
        }

        /// <summary>
        /// When the script is disable/inactive so is the restart action
        /// </summary>
        private void OnDisable()
        {
            if (restart != null) { restart.performed -= RestartPerformed; }
        }

        /// <summary>
        /// Quits/Exits the game when playing 
        /// </summary>
        /// <param name="obj"></param>
        private void ExitPerformed(InputAction.CallbackContext obj)
        {
            Application.Quit();
        }


        /// <summary>
        /// Reloads the current scene when action is pressed
        /// </summary>
        /// <param name="obj"></param>
        private void RestartPerformed(InputAction.CallbackContext obj)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }

        /// <summary>
        /// Loads the scene listed as number 1 in the build settings
        /// </summary>
        public void LevelOne()
        {
            SceneManager.LoadScene(1);
        }

        #region Enemy Functions

        /// <summary>
        /// Adds collectables then checks if the requirement is meet and peforms the statement for all the enemies
        /// </summary>
        public void EnemyDestroyed()
        {
            //Level 1 

            collectables++;
        
            if(collectables == 1)
            {
                enemyRemain.text = "Find & Shoot red boxes\r\n- 2 remaining";
            }

            if(collectables == 2)
            {
                enemyRemain.text = "Find & Shoot red boxes\r\n- 1 remaining";
            }

            if(collectables == 3)
            {
                enemyRemain.text = "<s>Find & Shoot red boxes\r\n- 0 remaining";
                enemyRemain.color = Color.green;

                doorManager.allEniemesGone();

                doorOpen.text = "Collect the VR Headset | Unlocked\r\n<s>- Completed other objectives to unlock";
                doorOpen.color = Color.green;
            
            }
        }

        public void PlatformSpawn()
        {
            platform1.gameObject.SetActive(true);
        }

        public void LevelOneEnemies()
        {

        }

    #endregion
}
