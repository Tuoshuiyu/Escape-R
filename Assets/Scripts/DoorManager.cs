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
    private bool enemiesDestroyed;

    /// <summary>
    /// Set the bool to false at the start
    /// </summary>
    private void Start()
    {
        enemiesDestroyed = false;
    }

    /// <summary>
    /// Loads scene when collide with the door with the player but only works with bool is true
    /// </summary>
    /// <param name="collision"></param>
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player") && enemiesDestroyed == true)
        {
            SceneManager.LoadScene(0);
            Cursor.visible = true;
            Cursor.lockState = CursorLockMode.None;
            
        }
    }

    /// <summary>
    /// When called sets the bool to true
    /// </summary>
    public void allEniemesGone()
    {
        enemiesDestroyed = true;
    }
}
