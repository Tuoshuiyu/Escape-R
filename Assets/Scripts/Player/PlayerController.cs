/**********************************************************************************************************************
// File Name : PlayerControler.cs
// Author : Darryn C. Gorman
// Creation Date : March 24, 2026
//
// Brief Description : This holds the controlls and functions of the player. The mechanics of the player and the
                       functions when actions happen in game or preformed. 
**********************************************************************************************************************/
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    // Fields 
    private InputAction move;
    private Rigidbody rb;
    private Vector3 playerMovement;

    [SerializeField] private float playerSpeed;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb = GetComponent<Rigidbody>();

        move = InputSystem.actions.FindAction("Move");
        move.performed += MovePerformed;
        move.canceled += MoveCanceled;
    }

    #region InputAction Functions

    /// <summary>
    /// Cancels the movement and allows to player to stop on release and not continue to move
    /// </summary>
    /// <param name="obj"></param>
    private void MoveCanceled(InputAction.CallbackContext obj)
    {
        playerMovement = Vector3.zero;
    }

    /// <summary>
    /// Sets and reads the value of the x/y (vertical/horizontal) and times it by the speed of the player
    /// </summary>
    /// <param name="obj"></param>
    private void MovePerformed(InputAction.CallbackContext obj)
    {
        Vector2 input = obj.ReadValue<Vector2>();
        playerMovement = new Vector3(input.x, 0, input.y) * playerSpeed;
    }

    #endregion

    // Update is called once per frame
    void Update()
    {
        rb.linearVelocity = new Vector3(playerMovement.x, rb.linearVelocity.y, playerMovement.z);
    }
}
