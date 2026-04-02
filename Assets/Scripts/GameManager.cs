/**********************************************************************************************************************
// File Name : EndScript.cs
// Author : Darryn C. Gorman
// Creation Date : April 1, 2026
//
// Brief Description : Handles all of the scenes transitions and UI in the build and editor.
**********************************************************************************************************************/
using UnityEditor;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    private InputAction restart;
    private InputAction exit;

    /// <summary>
    /// Finds and sets the input for restart
    /// </summary>
    private void Start()
    {
        restart = InputSystem.actions.FindAction("Restart");
        restart.performed += RestartRerformed;

        exit = InputSystem.actions.FindAction("Exit");
        exit.performed += ExitPerformed;
    }

    /// <summary>
    /// Quits/Exits the game when playing 
    /// </summary>
    /// <param name="obj"></param>
    private void ExitPerformed(InputAction.CallbackContext obj)
    {
#if UNITY_EDITOR
        //exits the Game Editor in unity
        EditorApplication.isPlaying = false;
#else
        //Quits when in a build
        Application.Quit();
#endif
    }


    /// <summary>
    /// Reloads the current scene when action is pressed
    /// </summary>
    /// <param name="obj"></param>
    private void RestartRerformed(InputAction.CallbackContext obj)
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
}
