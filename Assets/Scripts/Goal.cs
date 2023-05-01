using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Goal : MonoBehaviour {
    [SerializeField] string SceneToLoad;

    public void OnTriggerEnter2D(Collider2D other)
    {
        int currentScene = SceneManager.GetActiveScene().buildIndex;
        if (other.CompareTag("Player"))
        {
                SceneManager.LoadScene(SceneToLoad);
        }

    }
}
