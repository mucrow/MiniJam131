using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Curtain : MonoBehaviour
{
    float _curtainOpenTimer = 2f;

    [SerializeField] Sprite _openCurtainSprite;
    [SerializeField] Sprite _closedCurtainSprite;
    [SerializeField] SpriteRenderer _spriteRenderer;
    [SerializeField] LightSource _lightSource;
    [SerializeField] HorizontalLightSource _horizontalLightSource;

    [SerializeField] bool _isOpen = false;

    void Start()
    {
        OnIsOpenChanged();
    }

    // Update is called once per frame
    void Update()
    {
        _curtainOpenTimer -= Time.deltaTime;
        if (_curtainOpenTimer <= 0f)
        {
            _curtainOpenTimer = 2f;
            ToggleOpen();
        }
    }

    void ToggleOpen()
    {
        _isOpen = !_isOpen;
        OnIsOpenChanged();
    }

    void OnIsOpenChanged()
    {
        if (_isOpen)
        {
            _spriteRenderer.sprite = _openCurtainSprite;
            if (_lightSource is not null)
            {
                _lightSource.Show();

            }
            if (_horizontalLightSource is not null)
            {
                _horizontalLightSource.Show();
            }
        }
        else
        {
            _spriteRenderer.sprite = _closedCurtainSprite;
            if (_lightSource is not null)
            {
                _lightSource.Hide();

            }
            if (_horizontalLightSource is not null)
            {
                _horizontalLightSource.Hide();
            }
        }
    }
}
