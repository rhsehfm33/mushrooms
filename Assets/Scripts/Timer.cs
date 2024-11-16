using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Timer : MonoBehaviour
{
    public event Action OnTimeTicking;
    public static Timer Instance { get; private set; }

    [SerializeField]
    private int _timeRemaining = 180;
    private Coroutine _timerCoroutine;

    public int TimeRemaining
    {
        get => _timeRemaining; // 읽기 전용
        private set => _timeRemaining = value; // 내부에서만 설정 가능
    }

    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
            return;
        }

        Instance = this;
    }
    
    void Start()
    {
        _timerCoroutine = StartCoroutine(StartTimer());
        Judger.Instance.OnJudgeDone += StopTimer;
    }

    private IEnumerator StartTimer()
    {
        while (TimeRemaining > 0)
        {
            yield return new WaitForSeconds(1f);
            TimeRemaining--;
            OnTimeTicking?.Invoke();
        }
    }

    private void StopTimer()
    {
        StopCoroutine(_timerCoroutine); // 타이머 코루틴 중지
    }
}
