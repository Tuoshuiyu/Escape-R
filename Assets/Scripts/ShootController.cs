/**********************************************************************************************************************
// File Name : ShootController.cs
// Author : Darryn C. Gorman
// Creation Date : March 26, 2026
//
// Brief Description : Handles simple shooting using Player Input system.
**********************************************************************************************************************/
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

    [SerializeField] private List<GameObject> spawnedBullets = new List<GameObject>();

    /// <summary>
    /// Every time scripts becomes active shoot is enable and set
    /// </summary>
    private void OnEnable()
    {
        shoot = InputSystem.actions.FindAction("Attack");

        if (shoot != null) { shoot.performed += ShootPerformed; }
    }

    /// <summary>
    /// Every time script becomes inactive shoot is disable
    /// </summary>
    private void OnDisable()
    {
        if (shoot != null) { shoot.performed -= ShootPerformed; } 
    }

    /// <summary>
    /// Called when the fire input is triggered
    /// </summary>
    /// <param name="obj"></param>
    private void ShootPerformed(InputAction.CallbackContext obj)
    {
        Fire();
    }

    /// <summary>
    /// Spawns and shoots a bullet forward from the middle of the screen (crosshair) using raycast
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
        StartCoroutine(DestroyBullet(newBullet));
    }

    /// <summary>
    /// When called waits for set time then, destroys and remove the Bullets
    /// </summary>
    /// <param name="newBullet"></param>
    /// <returns></returns>
    IEnumerator DestroyBullet(GameObject newBullet)
    {
        yield return new WaitForSeconds(destroyTimeBullet);
        spawnedBullets.Remove(newBullet);
        Destroy(newBullet);
    }
}
