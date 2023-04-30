using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager: MonoBehaviour {
  [SerializeField] CanvasGroup _howToPlayDialog;
  [SerializeField] CanvasGroup _spaceToStartOverlay;

  enum State {
    ShowingHowToPlay,
    ShowingSpaceToStartOverlay,
    Gameplay,
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
}
