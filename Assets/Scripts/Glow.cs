using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class Glow : MonoBehaviour
{
    [SerializeField] LightSource lightSource;
    private Collider2D _collider;

    void OnTriggerEnter2D(Collider2D collision) 
    {   
        if (collision.CompareTag("Player")){
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
    }
    void Start()
    {
        _collider = GetComponent<Collider2D>();
    }

    // Update is called once per frame
    void Update()
    {

    }

}