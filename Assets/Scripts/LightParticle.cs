using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class LightParticle: MonoBehaviour {
  [SerializeField] Rigidbody2D _rigidbody;
  [SerializeField] SpriteRenderer _spriteRenderer;

  LightSource _lightSource;
  HorizontalLightSource _horizontalLightSource;

  void Start() {
    var angularSpeed = Random.Range(30f, 90f);
    var angularVelocitySign = Random.Range(0, 2) == 0 ? -1f : 1f;
    _rigidbody.angularVelocity = angularSpeed * angularVelocitySign;
  }

  void OnDestroy() {
    _lightSource.NotifyLightParticleDied(this);
  }

  public void SetParent(LightSource lightSource) {
    _lightSource = lightSource;
  }
  
  public void SetParent(HorizontalLightSource horizontalLightSource) {
    _horizontalLightSource = horizontalLightSource;
  }

  public void SetVelocity(Vector2 velocity) {
    _rigidbody.velocity = velocity;
  }

  public void Show() {
    _spriteRenderer.enabled = true;
  }

  public void Hide() {
    _spriteRenderer.enabled = false;
  }
}
