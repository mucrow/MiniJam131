using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Goal : MonoBehaviour
{
    public void OnTriggerEnter2D(Collider2D other)
    {
        {
            int currentScene = SceneManager.GetActiveScene().buildIndex;
            if (other.CompareTag("Player"))
            {
                // TODO: Add dialogue pop-up
                if (currentScene < SceneManager.GetAllScenes().Length)
                {
                    SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
                }
                else
                {
                    SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
                }
            }

        }
    }
}
