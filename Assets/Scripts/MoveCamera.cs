/**********************************************************************************************************************
// File Name : MoveCamera.cs
// Author : Darryn C. Gorman
// Creation Date : March 26, 2026
//
// Brief Description : Tranform position script for the camera that is appiled to the character's head
**********************************************************************************************************************/
using UnityEngine;

public class MoveCamera : MonoBehaviour
{
    [SerializeField] private Transform headPos;

    /// <summary>
    /// Sets the position to be the players head every frame
    /// </summary>
    void Update()
    {
        transform.position = headPos.position;
    }
}