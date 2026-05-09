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

    public void Restart()
    {
        //Calculate the next index, but reset to 0 if it exceeds the total count
        int nextSceneIndex = (SceneManager.GetActiveScene().buildIndex + 1) % SceneManager.sceneCountInBuildSettings;

        SceneManager.LoadScene(nextSceneIndex);
    }
}
