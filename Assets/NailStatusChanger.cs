using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(SpriteRenderer))]
public class NailStatusChanger : MonoBehaviour
{
    private readonly int NAIL_IN = 0;
    private readonly int NAIL_OUT = 1;

    public Sprite[] sprites; // 변경할 Sprite 배열
    private SpriteRenderer _spriteRenderer;
    private int _currentSpriteIndex = 0;
    private GameObject _myNail;

    private void Start()
    {
        if (sprites == null || sprites.Length == 0)
        {
            Debug.LogError("sprites 배열이 설정되지 않았습니다! 필드를 Inspector에서 설정하세요.");
        }
        _spriteRenderer = GetComponent<SpriteRenderer>();
        _myNail = transform.parent.gameObject;
        NailManager.Instance.OnNailSelectEvent += respondToNailSelect;
    }

    private void respondToNailSelect()
    {
        if (NailManager.Instance.GetSelectedNail() == _myNail)
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
