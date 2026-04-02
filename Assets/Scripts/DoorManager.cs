/**********************************************************************************************************************
// File Name : DoorManager.cs
// Author : Darryn C. Gorman
// Creation Date : April 1, 2026
//
// Brief Description : Handles the portal for the player to enter to go to next level.
**********************************************************************************************************************/
using UnityEngine;
using UnityEngine.SceneManagement;

public class DoorManager : MonoBehaviour
{
    /// <summary>
    /// Loads scene when collide with the door with the player | and show c
    /// </summary>
    /// <param name="collision"></param>
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            SceneManager.LoadScene(0);
            Cursor.visible = true;
            Cursor.lockState = CursorLockMode.None;
            
        }
    }
}
