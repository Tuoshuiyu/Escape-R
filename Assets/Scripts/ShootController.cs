/**********************************************************************************************************************
// File Name : ShootController.cs
// Author : Darryn C. Gorman
// Creation Date : March 26, 2026
//
// Brief Description : Handles simple shooting using Player Input system.
**********************************************************************************************************************/
using System;
using UnityEngine;
using UnityEngine.InputSystem;

public class ShootController : MonoBehaviour
{
    [SerializeField] private GameObject bullet;
    private float shootForce;
    private InputAction shoot;

    /// <summary>
    /// Sets the shoot with the unity inputSystem
    /// </summary>
    void Start()
    {
        shootForce = 20f;

        shoot = InputSystem.actions.FindAction("Attack");
        shoot.performed += ShootPerformed;

    }

    /// <summary>
    /// Called when the fire input is triggered
    /// </summary>
    /// <param name="obj"></param>
    /// <exception cref="System.NotImplementedException"></exception>
    private void ShootPerformed(InputAction.CallbackContext obj)
    {
        if (obj.performed)
        {
            Fire();
        }
    }

    /// <summary>
    /// Spawns and shoots a buller forward
    /// </summary>
    /// <exception cref="NotImplementedException"></exception>
    private void Fire()
    {
        // Create the projectile
        GameObject newBullet = Instantiate(bullet);

        // Set position slightly in front of player
        newBullet.transform.position = transform.position + transform.forward * 0.6f;

        // Match player rotation
        newBullet.transform.rotation = transform.rotation;

        // Get Rigidbody and apply force
        Rigidbody rb = newBullet.GetComponent<Rigidbody>();
        rb.AddForce(transform.forward * shootForce, ForceMode.Impulse);
    }
}
