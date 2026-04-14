/**********************************************************************************************************************
// File Name : EnemyController.cs
// Author : Darryn C. Gorman
// Creation Date : April 14, 2026
//
// Brief Description : Handles all the enemies/targets mechanics to sends triggers to other scripts to keep track of 
                       how many have been destroy/shoot.
**********************************************************************************************************************/
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    private GameManager gm;

    /// <summary>
    /// At the start gm is set to the GameManager script
    /// </summary>
    private void Start()
    {
        gm = FindFirstObjectByType<GameManager>();
    }

    /// <summary>
    /// When the objecy the script is attach to destroys it calls the EnemyDestroyed function in gm script
    /// </summary>
    private void OnDestroy()
    {
        Debug.Log("Enemy Destroyed");
        gm.EnemyDestroyed();
    }

}
