using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NailImageChanger : MonoBehaviour
{
    private readonly int NAIL_IN = 0;
    private readonly int NAIL_OUT = 1;

    public Sprite[] sprites; // 변경할 Sprite 배열
    private SpriteRenderer spriteRenderer;
    private int currentSpriteIndex = 0;

    private void Start()
    {
        // 현재 GameObject의 SpriteRenderer 가져오기
        spriteRenderer = GetComponent<SpriteRenderer>();
        if (spriteRenderer == null)
        {
            Debug.LogError("SpriteRenderer가 이 GameObject에 없습니다!");
        }
    }

    private void OnMouseDown()
    {
        Debug.Log("Nail을 클릭했습니다!");
        if (spriteRenderer != null && sprites.Length > 0)
        {
            if (currentSpriteIndex == NAIL_IN)
            {
                currentSpriteIndex = NAIL_OUT;
            }
            else if (currentSpriteIndex == NAIL_OUT)
            {
                currentSpriteIndex = NAIL_IN;
            }
            spriteRenderer.sprite = sprites[currentSpriteIndex];
        }
    }
}
