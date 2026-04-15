/**********************************************************************************************************************
// File Name : MovePoints.cs
// Author : Darryn C. Gorman
// Creation Date : April 15, 2026
//
// Brief Description : Moves a gameObject between points depending on how many is set in the hierarchy
**********************************************************************************************************************/
using UnityEngine;

public class MovePoints : MonoBehaviour
{

    [SerializeField] private GameObject[] movePoints;
    [SerializeField] private float speed;
    private int currentIndex;

    /// <summary>
    /// Sets the currentIndex to 0 at the start
    /// </summary>
    void Start()
    {
        currentIndex = 0;
    }

    /// <summary>
    /// Every frame the currentIndex is increased and mvoes the attached object between points 
    /// </summary>
    void Update()
    {
        if (Vector3.Distance(transform.position, movePoints[currentIndex].transform.position) < 0.1f)
        {
            currentIndex++;

            if (currentIndex >= movePoints.Length)
            {
                currentIndex = 0;
            }
        }

        transform.position = Vector3.MoveTowards(transform.position, movePoints[currentIndex].transform.position,
            speed * Time.deltaTime);
    }
}
