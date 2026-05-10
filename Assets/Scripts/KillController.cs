/**********************************************************************************************************************
// File Name : KillController.cs
// Author : Darryn C. Gorman
// Creation Date : March 26, 2026
//
// Brief Description : Handles simple destroy mechanic when collision with tag, and send that to the gamemanager to
                       keep track of how many objects been destroyed.
**********************************************************************************************************************/
using UnityEngine;
using UnityEngine.SceneManagement;

public class KillController : MonoBehaviour
{
    private GameManager gm;
    private TutorialManager Tgm;

    /// <summary>
    /// Finds and set gm to the GameManager script and Tgm to TutorialManager script
    /// </summary>
    private void Start()
    {
        gm = FindFirstObjectByType<GameManager>();
        Tgm = FindFirstObjectByType<TutorialManager>();
    }

    /// <summary>
    /// Called when this object collides with another object
    /// </summary>
    /// <param name="collision"></param>
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            Destroy(collision.gameObject);
            Destroy(gameObject);

            if (SceneManager.GetActiveScene().buildIndex >= 3 &&
            SceneManager.GetActiveScene().buildIndex <= 5)
            {
                gm.EnemyDestroyed();
            }
        } 

        if (SceneManager.GetActiveScene().buildIndex == 2)
        {
            Tgm.StepTwo();
        }
    }
}
