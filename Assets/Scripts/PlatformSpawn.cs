/**********************************************************************************************************************
// File Name : PlatformSpawn.cs
// Author : Darryn C. Gorman
// Creation Date : April 30, 2026
//
// Brief Description : When the gameobject that the script is attached is destroy it spawns another gameobject. Calls
                       gameManager script to check track of enemies.
**********************************************************************************************************************/
using UnityEngine;

public class PlatformSpawn : MonoBehaviour
{
    private GameManager gm;
    [SerializeField] private GameObject platform;

    /// <summary>
    /// Finds and set gm to the GameManager script | Sets the platforms to false
    /// </summary>
    private void Start()
    {
        gm = FindFirstObjectByType<GameManager>();
        platform.SetActive(false);
    }

    /// <summary>
    /// When collided with a bullet it get destroyed and calls the gm script to add to counter
    /// </summary>
    /// <param name="collision"></param>
    private void OnCollisionEnter(Collision collision)
    {
        Destroy(collision.gameObject);
        Destroy(gameObject);

        gm.EnemyDestroyed();
    }

    /// <summary>
    /// When destroyed activateds the platform 
    /// </summary>
    private void OnDestroy()
    {
        platform.SetActive(true);
    }
}
