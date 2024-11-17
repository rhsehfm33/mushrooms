using System;
using UnityEngine;

public class Judger : MonoBehaviour
{
    [SerializeField]
    private PlankCounter _plankCounter;

    [SerializeField]
    private Timer _timer;

    public event Action OnJudgeDone;
    public event Action OnStageClear;
    public event Action OnStageFail;

    void Start()
    {
        if (_timer == null)
        {
            Debug.LogError("Timer가 Scene에 없습니다!");
        }
        _timer.OnTimeTicking += Judge;
    }

    void Judge()
    {
        if (_plankCounter.GetNailedPlank() == 0)
        {
            Debug.Log("Stage Clear!");
            OnJudgeDone?.Invoke();
            OnStageClear?.Invoke();
        }
        else if (_timer.TimeRemaining <= 0)
        {
            Debug.Log("Stage Fail...");
            OnJudgeDone?.Invoke();
            OnStageFail?.Invoke();
        }
    }
}
