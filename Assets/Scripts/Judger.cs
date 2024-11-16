using System;
using UnityEngine;

public class Judger : ManagerPattern<Judger>
{
    public event Action OnJudgeDone;
    public event Action OnStageClear;
    public event Action OnStageFail;

    void Start()
    {
        if (PlankCounter.Instance == null)
        {
            Debug.LogError("PlankCounter가 Scene에 없습니다!");
        }
        if (Timer.Instance == null)
        {
            Debug.LogError("Timer가 Scene에 없습니다!");
        }
        Timer.Instance.OnTimeTicking += Judge;
    }

    void Judge()
    {
        if (PlankCounter.Instance != null && PlankCounter.Instance.GetNailedPlank() == 0)
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
