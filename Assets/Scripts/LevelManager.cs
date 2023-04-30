using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager: MonoBehaviour {
  [SerializeField] CanvasGroup _howToPlayDialog;
  [SerializeField] CanvasGroup _spaceToStartOverlay;
  [SerializeField] CanvasGroup _deathOverlay;

  enum State {
    ShowingHowToPlay,
    ShowingSpaceToStartOverlay,
    Gameplay,
    Death,
    Victory,
  }

  State _state;

  void Start() {
    ShowDialog(_howToPlayDialog);
    _state = State.ShowingHowToPlay;
  }

  void Update() {
    bool spacePressed = Input.GetKeyDown(KeyCode.Space);
    if (_state == State.ShowingHowToPlay) {
      if (spacePressed) {
        HideDialog(_howToPlayDialog);
        ShowDialog(_spaceToStartOverlay);
        _state = State.ShowingSpaceToStartOverlay;
      }
    }
    else if (_state == State.ShowingSpaceToStartOverlay) {
      if (spacePressed) {
        HideDialog(_spaceToStartOverlay);
        _state = State.Gameplay;
      }
    }
    else if (_state == State.Death) {
      if (spacePressed) {
        HideDialog(_deathOverlay);
        _state = State.Gameplay;
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
      }
    }
  }

  void ShowDialog(CanvasGroup dialog) {
    Time.timeScale = 0f;
    dialog.alpha = 1f;
    dialog.blocksRaycasts = true;
  }

  void HideDialog(CanvasGroup dialog) {
    dialog.blocksRaycasts = false;
    dialog.alpha = 0f;
    Time.timeScale = 1f;
  }

  public void OnPlayerDied() {
    ShowDialog(_deathOverlay);
    _state = State.Death;
  }
}
