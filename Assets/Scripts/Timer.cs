using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Timer : MonoBehaviour
{
    public static Timer Instance { get; private set; }

    [SerializeField] // Inspector에서 수정 가능
    private int _timeRemaining = 180;

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
        StartCoroutine(StartTimer());
    }

    private IEnumerator StartTimer()
    {
        while (TimeRemaining > 0)
        {
            yield return new WaitForSeconds(1f);
            TimeRemaining--;
            Debug.Log("Timer Remaining: " + TimeRemaining);
        }
    }
}
