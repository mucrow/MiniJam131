using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager: MonoBehaviour {
  public static LevelManager Instance;

  bool _introShown = false;

  [SerializeField] CanvasGroup _howToPlayDialog;
  [SerializeField] CanvasGroup _spaceToStartOverlay;
  [SerializeField] CanvasGroup _deathOverlay;
  [SerializeField] CanvasGroup _winPanel;
  [SerializeField] TMP_Text _winText;

  [SerializeField] AudioClip _introMusic;
  [SerializeField] AudioClip _gameplayMusic;
  [SerializeField] AudioClip _batGameplayMusic;

  [SerializeField] Timer _timer;

  enum State {
    ShowingHowToPlay,
    ShowingSpaceToStartOverlay,
    Gameplay,
    Death,
    Victory,
  }

  State _state;

  int deathCount;

  void Awake() {
    if (Instance == null) {
      DontDestroyOnLoad(gameObject);
      Instance = this;
    }
    else {
      Destroy(gameObject);
    }
  }

  void Start() {
    if (_introShown) {
      _state = State.Gameplay;
    }
    else {
      AudioManager.Instance.PlaySongWithBSide(_gameplayMusic, _batGameplayMusic);
      ShowDialog(_howToPlayDialog);
      _state = State.ShowingHowToPlay;
    }
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
        _introShown = true;
        _timer.StartTimer();
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
    deathCount+=1;
    Debug.Log("Deaths: " + deathCount);
  }

  public int GetDeathCount() {
    return deathCount;
  }

  public void ShowWinScreenUI() {
    _timer.StopTimer();
    AudioManager.Instance.PlaySong(_introMusic);
    var formattedTime = _timer.FormatTime(_timer.TimeElapsed);
    _winText.text = "Total time: " + formattedTime + "\nTotal deaths: " + deathCount;
    ShowDialog(_winPanel);
  }
}
