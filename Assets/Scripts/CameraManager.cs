/**********************************************************************************************************************
// File Name : CameraManager.cs
// Author : Darryn C. Gorman
// Creation Date : March 26, 2026
//
// Brief Description : This is a camera script that moves with the players mouse (first-person view)
**********************************************************************************************************************/
using UnityEngine;

public class CameraManager : MonoBehaviour
{
    [SerializeField] private float cameraSpeed;
    [SerializeField] private float verticalLimit;
    [SerializeField] private float smoothSpeed;

    [SerializeField] private Transform orientation;
    [SerializeField] private Transform playerBody;

    private float xRotate = 0f;
    private float yRotate = 0f;
    private float xValue = 0f;
    private float yValue = 0f;


    /// <summary>
    /// Hides the cursor, locks it and sets the x and y to equal the x and y rotation
    /// </summary>
    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        xValue = xRotate;
        yValue = yRotate;
    }

    /// <summary>
    /// Moves the camera based on the players mouse movement, seta a limit, and moves around the body(player)
    /// </summary>
    void Update()
    {
        float mouseX = Input.GetAxis("Mouse X") * cameraSpeed;
        float mouseY = Input.GetAxis("Mouse Y") * cameraSpeed;

        yRotate += mouseX;
        xRotate -= mouseY;
        xRotate = Mathf.Clamp(xRotate, -verticalLimit, verticalLimit);

        xValue = Mathf.Lerp(xValue, xRotate, smoothSpeed * Time.deltaTime);
        yValue = Mathf.Lerp(yValue, yRotate, smoothSpeed * Time.deltaTime);

        transform.rotation = Quaternion.Euler(xValue, yValue, 0);
        orientation.rotation = Quaternion.Euler(0, yValue, 0);
        playerBody.rotation = Quaternion.Euler(0, yValue, 0);
    }
}
