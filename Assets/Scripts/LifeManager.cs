/**********************************************************************************************************************
// File Name : LifeManager.cs
// Author : Darryn C. Gorman
// Creation Date : April 21, 2026
//
// Brief Description : Handles the death function when the player falls off the map and places them back at the start
**********************************************************************************************************************/
using UnityEngine;

public class LifeManager : MonoBehaviour
{
    [SerializeField] private float lowestYPos;
    [SerializeField] private AudioSource deathSound;
    [SerializeField] private Transform spawn;
    private bool isDead;

    /// <summary>
    /// Sets the isDead bool to false when game starts
    /// </summary>
    void Start()
    {
        //ah alive
        isDead = false;
    }

    /// <summary>
    /// Sets the isDead bool to true and calls the Respawn() function and turns off the playercontroller
    /// </summary>
    private void Die()
    {
        //bleh gone
        isDead = true;
        deathSound.Play();

        GetComponent<PlayerController>().enabled = false;

        //teleport player back to start
        Respawn();
    }

    /// <summary>
    /// Teleports(moves) the player to the spawn position and reset the bool back to false and playercontroller = true
    /// </summary>
    private void Respawn()
    {
        transform.position = spawn.position;
        isDead = false;
        GetComponent<PlayerController>().enabled = true;
    }

    /// <summary>
    /// Once per frame checks if player is higher then lowestPos if not then calls Die()
    /// </summary>
    void Update()
    {
        if (transform.position.y < lowestYPos && !isDead)
        {
            Die();
        }
    }
}
