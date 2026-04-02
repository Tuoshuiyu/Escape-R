/**********************************************************************************************************************
// File Name : CrosshairPickup.cs
// Author : Darryn C. Gorman
// Creation Date : March 30, 2026
//
// Brief Description : Detects GameObjects with the "Pickup" tag using raycast and allows the player to pick them up
                       drop them with the input system, and moves smoothly in front of the player 
**********************************************************************************************************************/
using System;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.Rendering.UI;
using UnityEngine.UI;

public class CrosshairPickup : MonoBehaviour
{
    [SerializeField] private float range;
    [SerializeField] private Image crosshair;
    [SerializeField] private Transform holdPoint;

    //Default and when on target color
    private Color normalColor = Color.white;
    private Color pickupColor = Color.green;

    private InputAction pickup;
    private GameObject heldObject;
    private GameObject currentPickup;

    /// <summary>
    /// Assigns the InputSystem at the start of the game 
    /// </summary>
    private void Start()
    {
        pickup = InputSystem.actions.FindAction("Pickup");
        pickup.performed += PickupPerformed;
    }

    /// <summary>
    /// Calls the DetectPickup() function once per frame 
    /// </summary>
    void Update()
    {
        DetectPickup();
    }

    #region Pickup Functions
    /// <summary>
    /// Called when Input is pressed and checks if holding to drop or if not holding to pickup
    /// </summary>
    /// <param name="obj"></param>
    private void PickupPerformed(InputAction.CallbackContext obj)
    {
        if (heldObject != null)
        {
            DropObject();
            return;
        }

        if (currentPickup != null)
        {
            PickUpObject(currentPickup);
        }
    }

    /// <summary>
    /// Picks up the pbjecy and turns the collider off
    /// </summary>
    /// <param name="obj"></param>
    private void PickUpObject(GameObject obj)
    {
        heldObject = obj;
        Rigidbody rb = heldObject.GetComponent<Rigidbody>();

        if (rb != null)
        {
            rb.isKinematic = true;
        }

        Collider col = heldObject.GetComponent<Collider>();

        if (col != null)
        {
            col.enabled = false;
        }

        heldObject.transform.SetParent(holdPoint);
        /*heldObject.transform.localPosition = new Vector3(holdPoint.transform.localPosition.y *
            heldObject.transform.localPosition.x, holdPoint.transform.localPosition.z * Time.deltaTime);*/
    }

    /// <summary>
    /// Drops the object and turns the collider back on 
    /// </summary>
    private void DropObject()
    {
        Rigidbody rb = heldObject.GetComponent<Rigidbody>();
        if (rb != null)
        {
            rb.isKinematic = false;
        }

        Collider col = heldObject.GetComponent<Collider>();
        if (col != null)
        {
            col.enabled = true;
        }

        heldObject.transform.SetParent(null);
        heldObject = null;
    }

    /// <summary>
    /// Shoots a raycast forward in the middle of the screen to check for objects that can be picked up 
    /// </summary>
    private void DetectPickup()
    {
        Ray ray = new Ray(transform.position, transform.forward);
        RaycastHit hit;
        currentPickup = null;
        crosshair.color = normalColor;

        if (Physics.Raycast(ray, out hit, range))
        {
            if (hit.collider.CompareTag("Pickup"))
            {
                crosshair.color = pickupColor;
                currentPickup = hit.collider.gameObject;
            }
        }
    }
    #endregion

}

