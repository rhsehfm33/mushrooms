using System;
using UnityEngine;

public class Judger : MonoBehaviour
{
    public event Action OnJudgeDone;
    public static Judger Instance { get; private set; }

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
        }
        else if (Timer.Instance.TimeRemaining <= 0)
        {
            Debug.Log("Stage Fail...");
            OnJudgeDone?.Invoke();
        }
    }
}
