using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VictoryManager : MonoBehaviour
{
    [SerializeField]
    private GameObject _victorySign;

    void Start()
    {
        if (Judger.Instance == null)
        {
            Debug.LogError("Judger가 null입니다.");
        }
        else
        {
            Judger.Instance.OnStageClear += ShowVictorySign;
        }
    }

    void ShowVictorySign()
    {
        Instantiate( _victorySign );
    }
}
