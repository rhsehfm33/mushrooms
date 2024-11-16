using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Timer : MonoBehaviour
{
    public static Timer Instance { get; private set; }
    public int TimeRemaining { get; private set; } = 180; // 읽기 전용 프로퍼티

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
            Debug.Log("Timer Remaining: " + TimeRemaining);
            TimeRemaining--;
        }
    }
}
