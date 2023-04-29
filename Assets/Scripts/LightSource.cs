using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightSource: MonoBehaviour {
  [SerializeField] BoxCollider2D _collider;

  [SerializeField] GameObject[] _particlePrefabs;
  [SerializeField] Transform _particlesFolder;

  [SerializeField] SpriteRenderer _glowSpriteRenderer;

  [SerializeField] float _emitTimerDuration;

  float _emitTimer;

  void Start() {
    _emitTimer = _emitTimerDuration;
  }

  void Update() {
    _emitTimer -= Time.deltaTime;
    if (_emitTimer <= 0f) {
      _emitTimer += _emitTimerDuration;
      GameObject particlePrefab = PickRandomParticlePrefab();
      var initPosition = GetRandomizedParticleInitPosition();
      var particleObject = Instantiate(particlePrefab, initPosition, Quaternion.identity, _particlesFolder);
      var particle = particleObject.GetComponent<LightParticle>();
      particle.SetVelocity(Vector2.down);
    }
  }

  GameObject PickRandomParticlePrefab() {
    var numParticlePrefabs = _particlePrefabs.Length;
    return _particlePrefabs[Random.Range(0, numParticlePrefabs)];
  }

  Vector3 GetRandomizedParticleInitPosition() {
    float padding = 0.1f;
    var bounds = _collider.bounds;

    float minX = Mathf.Min(bounds.min.x + padding, bounds.center.x);
    float maxX = Mathf.Max(bounds.max.x - padding, bounds.center.x);

    float x = Random.Range(minX, maxX);
    float y = Mathf.Max(bounds.max.y - padding, bounds.center.y);

    return new Vector3(x, y, 0);
  }

  public void Show() {
    _glowSpriteRenderer.enabled = true;
    _particlesFolder.gameObject.SetActive(true);
  }

  public void Hide() {
    _glowSpriteRenderer.enabled = false;
    _particlesFolder.gameObject.SetActive(false);
  }
}
