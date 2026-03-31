/**********************************************************************************************************************
// File Name : CrosshairPickup.cs
// Author : Darryn C. Gorman
// Creation Date : March 30, 2026
//
// Brief Description : Detects GameObjects with the Pickup tag using raycast and allows the player to pick them up
                       drop them with the input system and moves smoothly in front of the player 
**********************************************************************************************************************/
using System;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;

public class CrosshairPickup : MonoBehaviour
{
    [SerializeField] private float range;
    [SerializeField] private Image crosshair;

    // Where object is held
    [SerializeField] private Transform holdPoint;

    // Movement settings
    [SerializeField] private float moveSpeed = 2f;
    [SerializeField] private float rotateSpeed = 100f;
    [SerializeField] private float followForce = 500f;

    //Default and when on target color
    private Color normalColor = Color.white;
    private Color pickupColor = Color.green;

    private InputAction pickup;

    // Stores currently held object
    private GameObject heldObject;
    private Rigidbody heldRb;

    // Offset from hold point
    private Vector3 holdOffset = Vector3.zero;

    /// <summary>
    /// Assigns the InputSystem at the start of the game 
    /// </summary>
    private void Start()
    {
        pickup = InputSystem.actions.FindAction("Pickup");
        pickup.performed += PickupPerformed;
    }

    /// <summary>
    /// Calls functions once per frame 
    /// </summary>
    void Update()
    {
        DetectPickup();
        HandleHeldObject();
    }

    /// <summary>
    /// Called when Input is pressed and checks if holding to drop or if not holding to pickup
    /// </summary>
    private void PickupPerformed(InputAction.CallbackContext obj)
    {
        if (heldObject != null)
        {
            DropObject();
        }
        else
        {
            TryPickup();
        }
    }

    /// <summary>
    /// Attempts to pick up an object using a raycast
    /// </summary>
    private void TryPickup()
    {
        Ray ray = new Ray(transform.position, transform.forward);
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit, range))
        {
            if (hit.collider.CompareTag("Pickup"))
            {
                heldObject = hit.collider.gameObject;
                heldRb = heldObject.GetComponent<Rigidbody>();

                if (heldRb != null)
                {
                    // Disable gravity for smoother holding
                    heldRb.useGravity = false;
                    heldRb.linearDamping = 10f;
                }

                // Reset offset when picked up
                holdOffset = Vector3.zero;
            }
        }
    }

    /// <summary>
    /// Drops the currently held object
    /// </summary>
    private void DropObject()
    {
        if (heldRb != null)
        {
            heldRb.useGravity = true;
            heldRb.linearDamping = 0f;
        }

        heldObject = null;
        heldRb = null;
    }

    /// <summary>
    /// Handles movement, rotation, and physics-based following of held object
    /// </summary>
    private void HandleHeldObject()
    {
        if (heldObject != null && heldRb != null)
        {
            // Move offset up/down
            if (Keyboard.current.qKey.isPressed)
            {
                holdOffset += Vector3.up * moveSpeed * Time.deltaTime;
            }

            if (Keyboard.current.eKey.isPressed)
            {
                holdOffset += Vector3.down * moveSpeed * Time.deltaTime;
            }

            // Rotate object with mouse
            float mouseX = Mouse.current.delta.x.ReadValue() * rotateSpeed * Time.deltaTime;
            heldObject.transform.Rotate(Vector3.up, mouseX);

            // Target position using offset
            Vector3 targetPos = holdPoint.position + holdOffset;

            // Apply physics force to move object smoothly
            Vector3 direction = targetPos - heldObject.transform.position;
            heldRb.AddForce(direction * followForce * Time.deltaTime);
        }
    }

    /// <summary>
    /// Shoots a raycast forward to check for pickup objects
    /// </summary>
    private void DetectPickup()
    {
        Ray ray = new Ray(transform.position, transform.forward);
        RaycastHit hit;

        crosshair.color = normalColor;

        if (Physics.Raycast(ray, out hit, range))
        {
            if (hit.collider.CompareTag("Pickup"))
            {
                Debug.Log("Looking at a Pickup!");
                crosshair.color = pickupColor;
            }
        }
    }
}