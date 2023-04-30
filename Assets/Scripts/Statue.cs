using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Statue : MonoBehaviour
{
    Dracula _dracula;
    [SerializeField] private bool triggerActive = false;

    public void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            _dracula = other.GetComponent<Dracula>();
            Debug.Log("Entered");
            triggerActive = true;
        }
    }

    public void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            triggerActive = false;
        }
    }
    private void Update()
    {
        var transformKeyDown = Input.GetKeyDown(KeyCode.Space);

        if (triggerActive && transformKeyDown)
        {
            _dracula.ToggleForm();
        }
    }

}
