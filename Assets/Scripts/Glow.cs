using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class Glow: MonoBehaviour {
  [SerializeField] AudioSource _audioSource;
  [SerializeField] AudioClip _deathSound;

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
    // transform.localScale (Vector3)
  }

}
