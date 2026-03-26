/**********************************************************************************************************************
// File Name : ShootController.cs
// Author : Darryn C. Gorman
// Creation Date : March 26, 2026
//
// Brief Description : Handles simple destroy mechanic when collision with tag.
**********************************************************************************************************************/
using UnityEngine;

public class KillController : MonoBehaviour
{
    /// <summary>
    /// Called when this object collides with another object
    /// </summary>
    /// <param name="collision">Collision data from Unity</param>
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            // Destroy the enemy
            Destroy(collision.gameObject);

            // Destroy this projectile
            Destroy(gameObject);
        }
    }
}
