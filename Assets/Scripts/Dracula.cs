using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dracula: MonoBehaviour {
  [SerializeField] Sprite _humanSprite;
  [SerializeField] Sprite _batSprite;
  [SerializeField] SpriteRenderer _spriteRenderer;

  [SerializeField] AudioClip _transformIntoBatSoundEffect;
  [SerializeField] AudioClip _transformIntoHumanSoundEffect;
  [SerializeField] AudioSource _audioSource;

  bool _isHuman = true;

  void Update() {
    var transformKeyDown = Input.GetKeyDown(KeyCode.Space);
    var runDown = Input.GetKey(KeyCode.A);
    var runUp = Input.GetKey(KeyCode.W);
    var runLeft = Input.GetKey(KeyCode.A);
    var runRight = Input.GetKey(KeyCode.D);

    var moveInput = new Vector2();
    if (runLeft) {
      moveInput.x -= 1f;
    }
    if (runRight) {
      moveInput.x += 1f;
    }
    if (runDown) {
      moveInput.y -= 1f;
    }
    if (runUp) {
      moveInput.y += 1f;
    }

    if (transformKeyDown) {
      ToggleForm();
    }
  }

  void ToggleForm() {
    _isHuman = !_isHuman;
    if (_isHuman) {
      _audioSource.PlayOneShot(_transformIntoBatSoundEffect);
      _spriteRenderer.sprite = _humanSprite;
    }
    else {
      _audioSource.PlayOneShot(_transformIntoHumanSoundEffect);
      _spriteRenderer.sprite = _batSprite;
    }
  }
}
