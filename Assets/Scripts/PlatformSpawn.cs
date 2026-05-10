/**********************************************************************************************************************
// File Name : PlatformSpawn.cs
// Author : Darryn C. Gorman
// Creation Date : April 30, 2026
//
// Brief Description : When the gameobject that the script is attached is destroy it spawns another gameobject. Calls
                       gameManager script to check track of enemies.
**********************************************************************************************************************/
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlatformSpawn : MonoBehaviour
{
    private GameManager gm;
    private TutorialManager Tgm;
    [SerializeField] private GameObject platform;

    /// <summary>
    /// Finds and set gm and Tgm to their scripts | Sets the platforms to false
    /// </summary>
    private void Start()
    {
        gm = FindFirstObjectByType<GameManager>();
        Tgm = FindFirstObjectByType<TutorialManager>();
        platform.SetActive(false);
    }

    /// <summary>
    /// When collided with a bullet it get destroyed and calls the gm script to add to counter 
    /// Calls stepThree in tutorial
    /// </summary>
    /// <param name="collision"></param>
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Bullet"))
        {
            Destroy(collision.gameObject);
            Destroy(gameObject);

            if (SceneManager.GetActiveScene().buildIndex >= 3 &&
            SceneManager.GetActiveScene().buildIndex <= 5)
            {
                gm.EnemyDestroyed();
            }
        }

        if (SceneManager.GetActiveScene().buildIndex == 2)
        {
            Tgm.StepThree();
        }
    }

    /// <summary>
    /// When destroyed activateds the platform and checks if scene is active
    /// </summary>
    private void OnDestroy()
    {
        Scene activeScene = SceneManager.GetActiveScene();

        if (activeScene.isLoaded)
        {
            platform.SetActive(true);
        }
        
    }
}
