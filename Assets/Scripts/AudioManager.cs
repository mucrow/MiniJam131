using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager: MonoBehaviour {
  public static AudioManager Instance;

  [SerializeField] AudioSource _musicSource;

  void Awake() {
    if (Instance == null) {
      DontDestroyOnLoad(gameObject);
      Instance = this;
    }
    else {
      Destroy(gameObject);
    }
  }

  public void PlaySong(AudioClip song) {
    _musicSource.clip = song;
    _musicSource.Play();
  }
}
