using System;
using UnityEngine;

public class Judger : ManagerPattern<Judger>
{
    [SerializeField]
    private PlankCounter _plankCounter;

    public event Action OnJudgeDone;
    public event Action OnStageClear;
    public event Action OnStageFail;

    void Start()
    {
        if (Timer.Instance == null)
        {
            Debug.LogError("Timer가 Scene에 없습니다!");
        }
        Timer.Instance.OnTimeTicking += Judge;
    }

    void Judge()
    {
        if (_plankCounter.GetNailedPlank() == 0)
        {
            Debug.Log("Stage Clear!");
            OnJudgeDone?.Invoke();
            OnStageClear?.Invoke();
        }
        else if (Timer.Instance.TimeRemaining <= 0)
        {
            Debug.Log("Stage Fail...");
            OnJudgeDone?.Invoke();
            OnStageFail?.Invoke();
        }
    }
}
