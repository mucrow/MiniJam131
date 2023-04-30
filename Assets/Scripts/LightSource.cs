using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightSource: MonoBehaviour {
  [SerializeField] BoxCollider2D _collider;

  [SerializeField] GameObject[] _particlePrefabs;
  [SerializeField] Transform _particlesFolder;

  [SerializeField] SpriteRenderer _glowSpriteRenderer;

  [SerializeField] float _emitTimerDuration;

  List<LightParticle> _particles = new List<LightParticle>();

  private Vector3 _previousSize;

  float _emitTimer;
  public bool _isHidden = false;

  void Start() {
    _emitTimer = _emitTimerDuration;
  }

  void Update() {
    _emitTimer -= Time.deltaTime;
    if (_emitTimer <= 0f) {
      _emitTimer += _emitTimerDuration;
      if (_particles.Count < 100) {
        CreateParticle();
      }
    }

    var particleDeathThreshold = _collider.bounds.min.y - 0.25f;
    foreach (var particle in _particles) {
      var particleY = particle.transform.position.y;
      if (particleY <= particleDeathThreshold) {
        Destroy(particle.gameObject);
      }
    }
  }

  void CreateParticle() {
    GameObject particlePrefab = PickRandomParticlePrefab();
    var initPosition = GetRandomizedParticleInitPosition();
    var particleObject = Instantiate(particlePrefab, initPosition, Quaternion.identity, _particlesFolder);
    var particle = particleObject.GetComponent<LightParticle>();
    _particles.Add(particle);
    particle.SetParent(this);
    if (_isHidden) {
      particle.Hide();
    }
    else {
      particle.Show();
    }
    particle.SetVelocity(Vector2.down);
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

  public void NotifyLightParticleDied(LightParticle particle) {
    _particles.Remove(particle);
  }

  public void Show() {
    _isHidden = false;
    _glowSpriteRenderer.enabled = true;
    _collider.size = _previousSize;
    foreach (var particle in _particles) {
      particle.Show();
    }
  }

  public void Hide() {
    _isHidden = true;
    _glowSpriteRenderer.enabled = false;
    _previousSize = _collider.size;
    _collider.size = new Vector3(0, 0, 0);
    foreach (var particle in _particles) {
      particle.Hide();
    }
  }
}
