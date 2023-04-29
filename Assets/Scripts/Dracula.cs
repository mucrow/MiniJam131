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
  public float speed = 4f;

  void Update() {
    var transformKeyDown = Input.GetKeyDown(KeyCode.Space);
    var runDown = Input.GetKey(KeyCode.S);
    var runUp = Input.GetKey(KeyCode.W);
    var runLeft = Input.GetKey(KeyCode.A);
    var runRight = Input.GetKey(KeyCode.D);

    var moveInput = transform.position;

    if (runLeft) {
      moveInput.x -= speed * Time.deltaTime;
    }
    if (runRight) {
      moveInput.x += speed * Time.deltaTime;
    }
    if (runDown) {
      moveInput.y -= speed * Time.deltaTime;
    }
    if (runUp) {
      moveInput.y += speed * Time.deltaTime;
    }

    // if (transformKeyDown) {
    //   ToggleForm();
    // }

    transform.position = moveInput;
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
