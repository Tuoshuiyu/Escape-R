/**********************************************************************************************************************
// File Name : TutorialManager.cs
// Author : Darryn C. Gorman
// Creation Date : April 30, 2026
//
// Brief Description : Handles all the tutorial functions and blue door to allow the player to learn how to play.
**********************************************************************************************************************/
using TMPro;
using UnityEngine;

public class TutorialManager : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI tutorialText;
    [SerializeField] private TextMeshProUGUI topObjective;

    private bool stepTwoR = false;

    private DoorManager doorManager;

    /// <summary>
    /// At the start sets the text to tell the player how to use pickup mechanic and Set dorrmanager with its script
    /// </summary>
    void Start()
    {
        tutorialText.text = "Pickup Plank to go to next platform\r\n- Shift Pickup -Shift Again Drop";
        doorManager = FindFirstObjectByType<DoorManager>();
    }

    /// <summary>
    /// When the player reaches the platform the next step begins and Set stepTwoR to true for now repeat
    /// </summary>
    /// <param name="collision"></param>
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("StepOne") && stepTwoR == false)
        {
            tutorialText.text = "Destory The Red Box\r\n- Space to Shoot";
            stepTwoR = true;
        }
    }
    
    /// <summary>
    /// Introduces and changes the text to show the player the different boxes(enemies)
    /// </summary>
    public void StepTwo()
    {
        tutorialText.text = "Destroy The Red Box With the ! For A Suprise\r\n- Space to Shoot";
    }
    
    /// <summary>
    /// Changes the text to explain to the player how to pickup again and complete a level
    /// </summary>
    public void StepThree()
    {
        tutorialText.text = "Use the Stair and Collect the Vr Headset\r\n- Shift Pickup \r\n- Shift Again Drop";

        doorManager.allEniemesGone();
        topObjective.text = "Collect the VR Headset - Unlocked\r\n<s>- Tutorial Completed";
        topObjective.color = Color.green;
    }

}
