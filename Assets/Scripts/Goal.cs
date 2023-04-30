using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Goal : MonoBehaviour
{
    [SerializeField] Dracula _dracula;
    [SerializeField] private bool triggerActive = false;
    
    public void OnTriggerEnter2D(Collider2D other) {
        {
            if (other.CompareTag("Player"))
            {
                Debug.Log("Entered");
                triggerActive = true;
            }
        }
    }
 
    public void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            triggerActive = false;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
