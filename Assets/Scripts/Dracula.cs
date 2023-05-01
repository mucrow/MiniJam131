using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Dracula: MonoBehaviour {
  [SerializeField] Rigidbody2D _rigidbody2D;
  [SerializeField] LoopingSpriteAnimator _spriteAnimator;

  [SerializeField] Sprite[] _humanIdleDownAnimationFrames;
  [SerializeField] Sprite[] _batIdleDownAnimationFrames;

  [SerializeField] AudioClip _transformIntoBatSoundEffect;
  [SerializeField] AudioClip _transformIntoHumanSoundEffect;
  [SerializeField] AudioSource _audioSource;

  [SerializeField] BoxCollider2D _boxCollider;
  [SerializeField] Vector2 _boxColliderOffsetWhenBat;
  [SerializeField] Vector2 _boxColliderSizeWhenBat;
  [SerializeField] Vector2 _boxColliderOffsetWhenHuman;
  [SerializeField] Vector2 _boxColliderSizeWhenHuman;

  [SerializeField] DraculaPoseSet _idlePoseSet;
  [SerializeField] DraculaPoseSet _walkPoseSet;
  [SerializeField] DraculaPoseSet _batPoseSet;
  DraculaPoseSet _activePoseSet;

  public bool _isHuman = true;
  [SerializeField] float speed = 1.6f;

  float _batTimer = 0f;

  Vector2 _moveInputBeforeIdle = Vector2.down;
  Vector2 _previousMoveInput = Vector2.zero;
  Vector2 _moveInput = Vector2.zero;

  void Awake() {
    _activePoseSet = _idlePoseSet;
  }

  void Start() {
    UpdatePoseSet();
  }

  void Update() {
    if (!_isHuman) {
      _batTimer -= Time.deltaTime;
      if (_batTimer <= 0f) {
        ToggleForm();
      }
    }

    var transformKeyDown = Input.GetKeyDown(KeyCode.Space);

    var runDown = Input.GetKey(KeyCode.S);
    var runUp = Input.GetKey(KeyCode.W);
    var runLeft = Input.GetKey(KeyCode.A);
    var runRight = Input.GetKey(KeyCode.D);

    _previousMoveInput = _moveInput;
    _moveInput = Vector2.zero;
    if (runLeft) {
      _moveInput.x -= 1;
    }
    if (runRight) {
      _moveInput.x += 1;
    }
    if (runDown) {
      _moveInput.y -= 1;
    }
    if (runUp) {
      _moveInput.y += 1;
    }

    if (_moveInput != _previousMoveInput) {
      if (_moveInput == Vector2.zero) {
        _moveInputBeforeIdle = _previousMoveInput;
      }
      UpdatePoseSet();
    }

    _rigidbody2D.velocity = _moveInput.normalized * speed;
  }

  public void ToggleForm() {
    _isHuman = !_isHuman;
    if (_isHuman) {
      AudioManager.Instance.SwitchToASide();
      _boxCollider.size = _boxColliderSizeWhenHuman;
      _boxCollider.offset = _boxColliderOffsetWhenHuman;
      _audioSource.PlayOneShot(_transformIntoBatSoundEffect);
      UpdatePoseSet();
    }
    else {
      AudioManager.Instance.SwitchToBSide();
      _boxCollider.size = _boxColliderSizeWhenBat;
      _boxCollider.offset = _boxColliderOffsetWhenBat;
      _audioSource.PlayOneShot(_transformIntoHumanSoundEffect);
      UpdatePoseSet();
      _batTimer = 2f;
    }
  }

  void UpdatePoseSet() {
    var isMoving = _moveInput != Vector2.zero;
    var direction = isMoving ? _moveInput : _moveInputBeforeIdle;

    if (!_isHuman) {
      _activePoseSet = _batPoseSet;
    }
    else {
      _activePoseSet = isMoving ? _walkPoseSet : _idlePoseSet;
    }

    var anim = GetAnimationFromPoseSet(_activePoseSet, direction);
    _spriteAnimator.SetAnimationFrames(anim);
  }

  Sprite[] GetAnimationFromPoseSet(DraculaPoseSet poseSet, Vector2 direction) {
    if (direction.y < 0f) {
      return poseSet.Down;
    }
    if (direction.y > 0f) {
      return poseSet.Up;
    }
    if (direction.x < 0f) {
      return poseSet.Left;
    }
    if (direction.x > 0f) {
      return poseSet.Right;
    }
    return poseSet.Down;
  }
}
