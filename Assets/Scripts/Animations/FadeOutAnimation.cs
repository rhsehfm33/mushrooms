using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(SpriteRenderer))]
public class FadeOutAnimation : MonoBehaviour
{
    [SerializeField] private float _fadeDuration = 2.0f;  // fade out 시간 (초)
    private SpriteRenderer _spriteRenderer;
    private float _fadeSpeed;

    void Start()
    {
        // SpriteRenderer 컴포넌트 가져오기
        _spriteRenderer = GetComponent<SpriteRenderer>();

        // fade out 속도 계산 (알파 값이 1에서 0까지 감소해야 하므로 1 나누기 시간)
        _fadeSpeed = 1.0f / _fadeDuration;
    }

    public IEnumerator StartAnimation()
    {
        while (_spriteRenderer.color.a > 0)
        {
            // 현재 알파 값을 감소시킴
            Color color = _spriteRenderer.color;
            color.a -= _fadeSpeed * Time.deltaTime;

            // 알파 값이 0 이하로 떨어지지 않게 설정
            color.a = Mathf.Clamp01(color.a);

            // 변경된 알파 값을 SpriteRenderer에 반영
            _spriteRenderer.color = color;

            yield return null; // 다음 프레임까지 대기
        }
    }
}
