using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class Glow: MonoBehaviour {
  [SerializeField] AudioSource _audioSource;
  [SerializeField] AudioClip _deathSound;


  Vector3 scaleChange = new Vector3(0.5f, 0f, 0f);

  private int deaths;

  void Start() {
    deaths = LevelManager.Instance.GetDeathCount();
    ShrinkLight(deaths);
  }

  void OnTriggerEnter2D(Collider2D collision) {
    if (collision.CompareTag("Player")) {
      if (collision.GetComponent<Dracula>()._isHuman) {
        Destroy(collision.gameObject);
        _audioSource.PlayOneShot(_deathSound);
        LevelManager.Instance.OnPlayerDied();
      }
    }
  }

  void ShrinkLight(int deathCount)
  {
    if (deathCount > 0 && deathCount < 3) {
        transform.localScale = Vector3.Scale(transform.localScale, new Vector3(0.8f, 1, 1));
    } else if ( deathCount >= 3 && deathCount < 5) {
        transform.localScale = Vector3.Scale(transform.localScale, new Vector3(0.7f, 1, 1));
    } else if ( deathCount >= 5){
        transform.localScale = Vector3.Scale(transform.localScale, new Vector3(0.5f, 1, 1));
    } 
  }

}
