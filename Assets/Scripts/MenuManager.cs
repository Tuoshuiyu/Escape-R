/**********************************************************************************************************************
// File Name : MenuManager.cs
// Author : Darryn C. Gorman
// Creation Date : May 8, 2026
//
// Brief Description : Handles all the interactions and functions of the main menu and level select scene
**********************************************************************************************************************/
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour
{

    /// <summary>
    /// Loads the next scene listed in the build scene list
    /// </summary>
    public void LoadNextLevel()
    {
        //Insures that it's not the last scene then goes to the next one
        int nextIndex = (SceneManager.GetActiveScene().buildIndex + 1) % SceneManager.sceneCountInBuildSettings;
        SceneManager.LoadScene(nextIndex);
    }

    #region Level Select Scene

    /// <summary>
    /// Loads the tutorial scene
    /// </summary>
    public void LoadTutorial()
    {
        SceneManager.LoadScene(2);
    }

    /// <summary>
    /// Loads level one scene
    /// </summary>
    public void LoadLevelOne()
    {
        SceneManager.LoadScene(3);
    }

    /// <summary>
    /// Loads level two scene
    /// </summary>
    public void LoadLevelTwo()
    {
        SceneManager.LoadScene(4);
    }

    /// <summary>
    /// Loads level three scene
    /// </summary>
    public void LoadLevelThree()
    {
        SceneManager.LoadScene(5);
    }

    /// <summary>
    /// Loads the main menu scene
    /// </summary>
    public void LoadMainMenu()
    {
        SceneManager.LoadScene(0);
    }

    #endregion

}