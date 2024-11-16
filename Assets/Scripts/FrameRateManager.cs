using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FrameRateManager : MonoBehaviour
{
    void Start()
    {
        QualitySettings.vSyncCount = 0; // VSync 끄기
        Application.targetFrameRate = 60; // 60FPS로 설정
    }
}
