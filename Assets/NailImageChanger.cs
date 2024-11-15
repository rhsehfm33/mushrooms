using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NailImageChanger : MonoBehaviour
{
    private readonly int NAIL_IN = 0;
    private readonly int NAIL_OUT = 1;

    public Sprite[] sprites; // 변경할 Sprite 배열
    private SpriteRenderer _spriteRenderer;
    private int _currentSpriteIndex = 0;
    private GameObject _myNail;

    private void Start()
    {
        // 현재 GameObject의 SpriteRenderer 가져오기
        _spriteRenderer = GetComponent<SpriteRenderer>();
        if (_spriteRenderer == null)
        {
            Debug.LogError("SpriteRenderer가 이 GameObject에 없습니다!");
        }

        _myNail = transform.parent.gameObject;
        NailManager.Instance.OnNailSelectEvent += respondToNailSelect;
    }

    private void respondToNailSelect()
    {
        if (NailManager.Instance.selectedNail == _myNail)
        {
            _currentSpriteIndex = NAIL_OUT; 
        }
        else
        {
            _currentSpriteIndex = NAIL_IN;
        }
        _spriteRenderer.sprite = sprites[_currentSpriteIndex];
    }

    private void OnMouseDown()
    {
        Debug.Log("Nail을 클릭했습니다!");
        if (_currentSpriteIndex == NAIL_IN)
        {
            NailManager.Instance.SelectNail(_myNail);
        }
        else if (_currentSpriteIndex == NAIL_OUT)
        {
            NailManager.Instance.SelectNail(null);
        }
    }
}
