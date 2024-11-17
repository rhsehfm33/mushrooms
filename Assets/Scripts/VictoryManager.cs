using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VictoryManager : MonoBehaviour
{
    [SerializeField]
    private GameObject _victorySign;

    [SerializeField]
    private Judger _judger;

    void Start()
    {
        _judger.OnStageClear += ShowVictorySign;
    }

    void ShowVictorySign()
    {
        Instantiate( _victorySign );
    }
}
