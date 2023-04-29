using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dracula: MonoBehaviour {
  [SerializeField] Rigidbody2D _rigidbody2D;

  [SerializeField] Sprite _humanSprite;
  [SerializeField] Sprite _batSprite;
  [SerializeField] SpriteRenderer _spriteRenderer;

  [SerializeField] AudioClip _transformIntoBatSoundEffect;
  [SerializeField] AudioClip _transformIntoHumanSoundEffect;
  [SerializeField] AudioSource _audioSource;

  bool _isHuman = true;
  public float speed = 4f;

  void Update() {
    var transformKeyDown = Input.GetKeyDown(KeyCode.Space);
    var runDown = Input.GetKey(KeyCode.S);
    var runUp = Input.GetKey(KeyCode.W);
    var runLeft = Input.GetKey(KeyCode.A);
    var runRight = Input.GetKey(KeyCode.D);

    var moveInput = Vector2.zero;

    if (runLeft) {
      moveInput.x -= 1;
    }
    if (runRight) {
      moveInput.x += 1;
    }
    if (runDown) {
      moveInput.y -= 1;
    }
    if (runUp) {
      moveInput.y += 1;
    }

    // if (transformKeyDown) {
    //   ToggleForm();
    // }

    _rigidbody2D.velocity = moveInput.normalized * speed;
  }

  public void ToggleForm() {
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
