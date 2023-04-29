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

  [SerializeField] BoxCollider2D _boxCollider;
  [SerializeField] Vector2 _boxColliderOffsetWhenBat;
  [SerializeField] Vector2 _boxColliderSizeWhenBat;
  [SerializeField] Vector2 _boxColliderOffsetWhenHuman;
  [SerializeField] Vector2 _boxColliderSizeWhenHuman;

  bool _isHuman = true;
  public float speed = 6f;

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

    _rigidbody2D.velocity = moveInput.normalized * speed;
  }

  public void ToggleForm() {
    _isHuman = !_isHuman;
    if (_isHuman) {
      _boxCollider.size = _boxColliderSizeWhenHuman;
      _boxCollider.offset = _boxColliderOffsetWhenHuman;
      _audioSource.PlayOneShot(_transformIntoBatSoundEffect);
      _spriteRenderer.sprite = _humanSprite;
    }
    else {
      _boxCollider.size = _boxColliderSizeWhenBat;
      _boxCollider.offset = _boxColliderOffsetWhenBat;
      _audioSource.PlayOneShot(_transformIntoHumanSoundEffect);
      _spriteRenderer.sprite = _batSprite;
    }
  }
}
