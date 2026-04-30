/**********************************************************************************************************************
// File Name : KillController.cs
// Author : Darryn C. Gorman
// Creation Date : March 26, 2026
//
// Brief Description : Handles simple destroy mechanic when collision with tag, and send that to the gamemanager to
                       keep track of how many objects been destroyed.
**********************************************************************************************************************/
using UnityEngine;

public class KillController : MonoBehaviour
{
    private GameManager gm;

    /// <summary>
    /// Finds and set gm to the GameManager script
    /// </summary>
    private void Start()
    {
        gm = FindFirstObjectByType<GameManager>();
    }

    /// <summary>
    /// Called when this object collides with another object
    /// </summary>
    /// <param name="collision"></param>
    private void OnCollisionEnter(Collision collision)
    {
        //So that any enemy can't spawn the platform
        if (collision.gameObject.CompareTag("Enemy"))
        {
            Destroy(collision.gameObject);
            Destroy(gameObject);

            gm.EnemyDestroyed();
        }
    }
}
