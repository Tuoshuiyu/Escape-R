/**********************************************************************************************************************
// File Name : EndScript.cs
// Author : Darryn C. Gorman
// Creation Date : April 1, 2026
//
// Brief Description : Quits the game in build version and stops editior in untiy and holds the start menu functions
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
    /// Goes to the next scene in the build list | +1
    /// </summary>
    public void NextScene()
    {
        int nextSceneIndex = SceneManager.GetActiveScene().buildIndex + 1;

        SceneManager.LoadScene(nextSceneIndex);
    }
}
