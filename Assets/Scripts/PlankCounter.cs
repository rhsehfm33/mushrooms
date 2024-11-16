using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlankCounter : MonoBehaviour
{
    public static PlankCounter Instance { get; private set; }
    private int _nailedPlanks = 0;

    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
            return;
        }

        Instance = this;
    }

    public int GetNailedPlank()
    {
        return _nailedPlanks;
    }

    public void IncreaseNailedPlank()
    {
        ++_nailedPlanks;
        Debug.Log("나무 판자 증가");
        Debug.Log(_nailedPlanks + "나무 판자가 걸려있습니다.");
    }

    public void DecreaseNailedPlank()
    {
        --_nailedPlanks;
        Debug.Log("나무 판자 감소");
        Debug.Log(_nailedPlanks + "나무 판자가 걸려있습니다.");
    }
}
