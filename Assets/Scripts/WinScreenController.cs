using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WinScreenController : MonoBehaviour
{
    void Start() {
        LevelManager.Instance.ShowWinScreenUI();
    }
}
