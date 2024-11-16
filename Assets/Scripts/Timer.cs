using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Timer : ManagerPattern<Timer>
{
    public event Action OnTimeTicking;

    [SerializeField]
    private int _timeRemaining = 180;
    private Coroutine _timerCoroutine;

    public int TimeRemaining
    {
        get => _timeRemaining; // 읽기 전용
        private set => _timeRemaining = value; // 내부에서만 설정 가능
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
