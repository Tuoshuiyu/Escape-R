/**********************************************************************************************************************
// File Name : EndScript.cs
// Author : Darryn C. Gorman
// Creation Date : April 1, 2026
//
// Brief Description : Quits the game in build version and stops editior in untiy 
**********************************************************************************************************************/
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EndScript : MonoBehaviour
{
    /// <summary>
    /// Quits/Exits the game when playing 
    /// </summary>
    public void QuitGame()
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
    /// Loads the main menu screen and set the time back to normal
    /// </summary>
    public void RestartGame()
    {
        SceneManager.LoadScene(0);
        Time.timeScale = 1.0f;
    }
}
