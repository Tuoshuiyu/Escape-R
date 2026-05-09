/**********************************************************************************************************************
// File Name : MenuManager.cs
// Author : Darryn C. Gorman
// Creation Date : May 8, 2026
//
// Brief Description : Handles all the interactions and functions of the main menu scene
**********************************************************************************************************************/
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
   
    }

    /// <summary>
    /// Loads the next scene listed in the build scene list
    /// </summary>
    public void LoadNextLevel()
    {
        //Insures that it's not the last scene then goes to the next one
        int nextIndex = (SceneManager.GetActiveScene().buildIndex + 1) % SceneManager.sceneCountInBuildSettings;
        SceneManager.LoadScene(nextIndex);
    }
}
