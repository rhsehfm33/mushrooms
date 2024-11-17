using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class RetryManager : MonoBehaviour
{
    [SerializeField]
    private GameObject _canvas;

    [SerializeField]
    private GameObject _retryMenuSet;

    [SerializeField]
    private GameObject _blocker;

    [SerializeField]
    private Judger _judger;

    void Start()
    {
        _judger.OnStageFail += popupRetryMenu;
    }

    private void popupRetryMenu()
    {
        _blocker.SetActive(true);
        _retryMenuSet.SetActive(true);
        _canvas.SetActive(true);
    }
}
