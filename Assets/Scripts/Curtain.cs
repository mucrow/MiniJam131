using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Curtain : MonoBehaviour
{
    float _curtainOpenTimer = 2f;
    
    [SerializeField] Sprite _openCurtainSprite;
    [SerializeField] Sprite _closedCurtainSprite;
    SpriteRenderer spriteRenderer;
    
    
    bool _isOpen = true;

    // Start is called before the first frame update
    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
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
            spriteRenderer.sprite = _closedCurtainSprite;
        }
        else {
            
            spriteRenderer.sprite = _openCurtainSprite;
        }
        _isOpen = !_isOpen;
    }

}
