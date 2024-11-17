using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VictoryManager : MonoBehaviour
{
    [SerializeField]
    private GameObject _victorySign;

    [SerializeField]
    private Judger _judger;

    [SerializeField]
    private SceneController _sceneController;

    void Start()
    {
        _judger.OnStageClear += triggerVictory;
    }

    void triggerVictory()
    {
        StartCoroutine(proceedVictory());
    }

    IEnumerator proceedVictory()
    {
        yield return showVictorySign();
        _sceneController.LoadNextScene();
    }

    IEnumerator showVictorySign()
    {
        GameObject victorySign = Instantiate(_victorySign);

        // FadeOutAnimation 컴포넌트 초기화를 위해 프레임이 끝날 때까지 대기
        yield return new WaitForEndOfFrame();

        FadeOutAnimation fadeOutAnimation = victorySign.GetComponent<FadeOutAnimation>();
        yield return fadeOutAnimation.StartAnimation();
    }
}
