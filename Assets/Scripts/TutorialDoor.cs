/**********************************************************************************************************************
// File Name : TutorialDoor.cs
// Author : Darryn C. Gorman
// Creation Date : May 9, 2026
//
// Brief Description : Handles the blue tutorial door at the start of the level to take the player to the tutorial.
**********************************************************************************************************************/
using UnityEngine;
using UnityEngine.SceneManagement;

public class TutorialDoor : MonoBehaviour
{
    /// <summary>
    /// Loads tutorial scene when collide with the door with the player | Loads level select when going back
    /// </summary>
    /// <param name="collision"></param>
    private void OnCollisionEnter(Collision collision)
    {
        //Level 1
        if (collision.gameObject.CompareTag("Player") && SceneManager.GetActiveScene().buildIndex == 3)
        {     
            Cursor.visible = true;
            Cursor.lockState = CursorLockMode.None;

            SceneManager.LoadScene(2);
        }

        //Level 2
        if (collision.gameObject.CompareTag("Player") && SceneManager.GetActiveScene().buildIndex == 4)
        {
            Cursor.visible = true;
            Cursor.lockState = CursorLockMode.None;

            SceneManager.LoadScene(2);
        }

        //Level 3
        if (collision.gameObject.CompareTag("Player") && SceneManager.GetActiveScene().buildIndex == 5)
        {
            Cursor.visible = true;
            Cursor.lockState = CursorLockMode.None;

            SceneManager.LoadScene(2);
        }

        if (collision.gameObject.CompareTag("Player") && SceneManager.GetActiveScene().buildIndex == 2)
        {           
            Cursor.visible = true;
            Cursor.lockState = CursorLockMode.None;

            SceneManager.LoadScene(1);
        }
    }
}
