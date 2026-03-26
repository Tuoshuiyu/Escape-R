/**********************************************************************************************************************
// File Name : ShootController.cs
// Author : Darryn C. Gorman
// Creation Date : March 26, 2026
//
// Brief Description : Handles simple shooting using Player Input system.
**********************************************************************************************************************/
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class ShootController : MonoBehaviour
{
    [SerializeField] private GameObject bulletPrefab;
    [SerializeField] private float shootForce;
    [SerializeField] private float bulletHeight;
    [SerializeField] private float destroyTimeBullet;
    private InputAction shoot;

    private List<GameObject> spawnedBullets = new List<GameObject>();

    /// <summary>
    /// Sets the shoot with the unity inputSystem
    /// </summary>
    void Start()
    {
        shoot = InputSystem.actions.FindAction("Attack");
        shoot.performed += ShootPerformed;
        //shoot.canceled += ShootCanceled;
    }

    /*private void ShootCanceled(InputAction.CallbackContext obj)
    {
        throw new NotImplementedException();
    }
    */

    /// <summary>
    /// Called when the fire input is triggered
    /// </summary>
    /// <param name="obj"></param>
    private void ShootPerformed(InputAction.CallbackContext obj)
    {
        Fire();
        DestroyBullet();
    }

    /// <summary>
    /// Spawns and shoots a buller forward
    /// </summary>
    private void Fire()
    {
        GameObject newBullet = Instantiate(bulletPrefab);
        spawnedBullets.Add(newBullet);

        // Set position slightly in front of player
        newBullet.transform.position = transform.position + transform.forward * 0.6f + Vector3.up * bulletHeight;

        // Match player rotation
        newBullet.transform.rotation = transform.rotation;

        // Get Rigidbody and apply force
        Rigidbody rb = newBullet.GetComponent<Rigidbody>();
        rb.AddForce(transform.forward * shootForce, ForceMode.Impulse);
    }

    IEnumerator DestroyBullet()
    {
        foreach (GameObject bullet in spawnedBullets)
        {
            yield return new WaitForSeconds(destroyTimeBullet);
            Destroy(bullet);
        }
    }
}
