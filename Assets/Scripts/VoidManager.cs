/**********************************************************************************************************************
// File Name : VoidManager.cs
// Author : Darryn C. Gorman
// Creation Date : April 21, 2026
//
// Brief Description : Handles when a pickup hits the void it comes back to the start
**********************************************************************************************************************/
using UnityEngine;

public class VoidManager : MonoBehaviour
{
    [SerializeField] private float lowestYPos;
    [SerializeField] private Transform pickupSpawn;
    private bool isGone;

    /// <summary>
    /// Sets the isGone bool to false when game starts
    /// </summary>
    void Start()
    {
        isGone = false;
    }

    /// <summary>
    /// Every frame checks if object is lower or higher then lowest (if lowest calls Gone() function)
    /// </summary>
    void Update()
    {
        if (transform.position.y < lowestYPos && !isGone)
        {
            Gone();
        }
    }

    /// <summary>
    /// Teleports the object back to the spawn location
    /// </summary>
    private void Gone()
    {
        transform.position = pickupSpawn.position;
        isGone = false;
    }
}
