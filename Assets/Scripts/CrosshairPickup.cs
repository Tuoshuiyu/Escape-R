/**********************************************************************************************************************
// File Name : CrosshairPickup.cs
// Author : Darryn C. Gorman
// Creation Date : March 30, 2026
//
// Brief Description : Detects GameObjects with the "Pickup" tag using raycast.
**********************************************************************************************************************/
using UnityEngine;

public class CrosshairPickup : MonoBehaviour
{
    [SerializeField] private float range;

    // Update is called once per frame
    void Update()
    {
        DetectPickup();
    }

    private void DetectPickup()
    {
        Ray ray = new Ray(transform.position, transform.forward);
        RaycastHit hit;

        // Draw the ray in the Scene view
        Debug.DrawRay(transform.position, transform.forward * range, Color.red);

        if (Physics.Raycast(ray, out hit, range))
        {
            Debug.Log("Hit: " + hit.collider.name);

            if (hit.collider.CompareTag("Pickup"))
            {
                Debug.Log("Looking at a Pickup!");
                Debug.DrawRay(transform.position, transform.forward * range, Color.green);
            }
        }
    }
}
