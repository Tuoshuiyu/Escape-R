/**********************************************************************************************************************
// File Name : TutorialManager.cs
// Author : Darryn C. Gorman
// Creation Date : April 30, 2026
//
// Brief Description : Handles all the tutorial functions and blue door to allow the player to learn how to play.
**********************************************************************************************************************/
using UnityEngine;
using UnityEngine.SceneManagement;

public class TutorialManager : MonoBehaviour
{
    /// <summary>
    /// Loads tutorial scene when collide with the door with the player 
    /// </summary>
    /// <param name="collision"></param>
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            SceneManager.LoadScene(2);
            Cursor.visible = true;
            Cursor.lockState = CursorLockMode.None;
        }
    }

}
