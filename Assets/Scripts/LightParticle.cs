using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightParticle: MonoBehaviour {
  [SerializeField] Rigidbody2D _rigidbody;

  void Start() {
    var angularSpeed = Random.Range(30f, 90f);
    var angularVelocitySign = Random.Range(0, 2) == 0 ? -1f : 1f;
    _rigidbody.angularVelocity = angularSpeed * angularVelocitySign;
  }

  public void SetVelocity(Vector2 velocity) {
    _rigidbody.velocity = velocity;
  }
}
