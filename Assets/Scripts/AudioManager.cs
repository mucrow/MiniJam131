using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager: MonoBehaviour {
  public static AudioManager Instance;

  [SerializeField] AudioSource _musicSourceA;
  [SerializeField] AudioSource _musicSourceB;

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
    SwitchToASide();
    _musicSourceB.Stop();
    _musicSourceA.clip = song;
    _musicSourceA.Play();
  }

  public void PlaySongWithBSide(AudioClip sideA, AudioClip sideB) {
    _musicSourceA.clip = sideA;
    _musicSourceB.clip = sideB;
    _musicSourceA.volume = 1f;
    _musicSourceB.volume = 0f;
    _musicSourceA.PlayScheduled(AudioSettings.dspTime + 0.1);
    _musicSourceB.PlayScheduled(AudioSettings.dspTime + 0.1);
  }

  public void SwitchToASide() {
    _musicSourceA.volume = 1f;
    _musicSourceB.volume = 0f;
  }

  public void SwitchToBSide() {
    _musicSourceA.volume = 0f;
    _musicSourceB.volume = 1f;
  }
}
