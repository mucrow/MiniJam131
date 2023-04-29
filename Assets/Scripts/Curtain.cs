using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Curtain : MonoBehaviour
{
    float _curtainOpenTimer = 2f;
    SpriteRenderer sprite;
    bool _isOpen = true;

    // Start is called before the first frame update
    void Start()
    {
        sprite = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        _curtainOpenTimer -= Time.deltaTime;
        if (_curtainOpenTimer <= 0f) {
            _curtainOpenTimer = 2f;
            ToggleOpen();
        }
    }

    void ToggleOpen()
    {
        if (_isOpen){
            // open it
            sprite.color = new Color(1, 0, 0, 1);
        }
        else {
            // close it
            sprite.color = new Color(1, 1, 1, 1);
        }
        _isOpen = !_isOpen;
    }

}
