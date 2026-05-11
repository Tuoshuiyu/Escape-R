/**********************************************************************************************************************
// File Name : GameManager.cs
// Author : Darryn C. Gorman
// Creation Date : April 1, 2026
//
// Brief Description : Handles all of the scenes transitions and UI in the build and editor. Also keeps track of all
                       functions such as collectables
**********************************************************************************************************************/
using TMPro;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI enemyRemain;
    [SerializeField] private TextMeshProUGUI doorOpen;
    [SerializeField] private GameObject pause;
        
    private int collectables;
    private DoorManager doorManager;
    private CameraManager cGM;

    private bool levelOne = false;
    private bool levelTwo = false;
    private bool levelThree = false;

    private InputAction restart;
    private InputAction exit;

    /// <summary>
    /// At the start of the scene all fields are set and enable and Sets the bools for each level when on that level
    /// </summary>
    private void Start()
    {
        restart = InputSystem.actions.FindAction("Restart");
        restart.performed += RestartPerformed;

        exit = InputSystem.actions.FindAction("Exit");
        exit.performed += ExitPerformed;

        doorManager = FindFirstObjectByType<DoorManager>();
        cGM = FindFirstObjectByType<CameraManager>();

        collectables = 0;

        pause.SetActive(false);

        #region Current Level Quest Functions

       if (SceneManager.GetActiveScene().buildIndex == 3)
        {
            levelOne = true;
            enemyRemain.text = "Find & Shoot red boxes\r\n- 2 remaining";
        }

       if (SceneManager.GetActiveScene().buildIndex == 4)
        {
            levelTwo = true;
            enemyRemain.text = "Find & Shoot red boxes\r\n- 3 remaining";
        }

        if (SceneManager.GetActiveScene().buildIndex == 5)
        {
            levelThree = true;
            enemyRemain.text = "Find & Shoot red boxes\r\n- 4 remaining";
        }
        
        #endregion
    }

    /// <summary>
    /// When the script is disable/inactive so is the restart action
    /// </summary>
    private void OnDisable()
    {
        if (restart != null) { restart.performed -= RestartPerformed; }
    }

    /// <summary>
    /// Set the pause menu and true and stops time
    /// </summary>
    /// <param name="obj"></param>
    private void ExitPerformed(InputAction.CallbackContext obj)
    {
        pause.SetActive(true);
        cGM.ToggleCrosshair();
        Time.timeScale = 0f;
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
    /// Sets the time back to normal and disables the pause
    /// </summary>
    public void ExitPause()
    {
        pause.SetActive(false);
        cGM.ReenableCrosshiar();
        Time.timeScale = 1f;
    }

    #region Enemy Functions

    /// <summary>
    /// Adds collectables then checks if the requirement is meet and peforms the statement for all the enemies
    /// </summary>
    public void EnemyDestroyed()
    {
        collectables++;
        Debug.Log("Enemy Destroyed");

        //Level 1
        if (levelOne == true)
        {
            if (collectables == 1) { enemyRemain.text = "Find & Shoot red boxes\r\n- 1 remaining"; }

            if (collectables == 2)
            {
                enemyRemain.text = "Find & Shoot red boxes\r\n- 0 remaining";
                enemyRemain.color = Color.green;

                doorManager.allEniemesGone();
                doorOpen.text = "Collect the VR Headset - Unlocked\r\n<s>- Completed other objectives to unlock";
                doorOpen.color = Color.green;
            }
        }

        //Level 2
        if (levelTwo == true)
        {
            if (collectables == 1) { enemyRemain.text = "Find & Shoot red boxes\r\n- 2 remaining"; }
            if (collectables == 2) { enemyRemain.text = "Find & Shoot red boxes\r\n- 1 remaining"; }

            if (collectables == 3)
            {
                enemyRemain.text = "Find & Shoot red boxes\r\n- 0 remaining";
                enemyRemain.color = Color.green;

                doorManager.allEniemesGone();
                doorOpen.text = "Collect the VR Headset - Unlocked\r\n<s>- Completed other objectives to unlock";
                doorOpen.color = Color.green;
            }
        }

        //Level 3
        if (levelThree == true)
        {
            if (collectables == 1) { enemyRemain.text = "Find & Shoot red boxes\r\n- 3 remaining"; }
            if (collectables == 2) { enemyRemain.text = "Find & Shoot red boxes\r\n- 2 remaining"; }
            if (collectables == 3) { enemyRemain.text = "Find & Shoot red boxes\r\n- 1 remaining"; }

            if (collectables == 4)
            {
                enemyRemain.text = "Find & Shoot red boxes\r\n- 0 remaining";
                enemyRemain.color = Color.green;

                doorManager.allEniemesGone();
                doorOpen.text = "Collect the VR Headset - Unlocked\r\n<s>- Completed other objectives to unlock";
                doorOpen.color = Color.green;
            }
        }
    }

    #endregion

}
