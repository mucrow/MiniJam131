using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class Glow : MonoBehaviour
{
    [SerializeField] AudioSource _audioSource;
    [SerializeField] AudioClip _deathSound;

    private int deaths;

    void Start()
    {
        deaths = LevelManager.Instance.GetDeathCount();
        ShrinkLight(deaths);
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            if (collision.GetComponent<Dracula>()._isHuman)
            {
                Destroy(collision.gameObject);
                _audioSource.PlayOneShot(_deathSound);
                LevelManager.Instance.OnPlayerDied();
            }
        }
    }

    void ShrinkLight(int deathCount)
    {
        if (deathCount > 0 && deathCount < 3)
        {
            ScaleCorrectDirection(tag, 0.8f);
        }
        else if (deathCount >= 3 && deathCount < 5)
        {
            ScaleCorrectDirection(tag, 0.7f);
        }
        else if (deathCount >= 5)
        {
            ScaleCorrectDirection(tag, 0.5f);
        }
    }

    void ScaleCorrectDirection(string tag, float amount){
        if (tag == "Horizontal")
            {
                transform.localScale = Vector3.Scale(transform.localScale, new Vector3(1, amount, 1));

            }
            else
            {
                transform.localScale = Vector3.Scale(transform.localScale, new Vector3(amount, 1, 1));
            }
    }

}
