using UnityEngine;

public class TimerDisplay : MonoBehaviour
{
    [SerializeField]
    private Timer _timer;

    private GUIStyle _guiStyle;

    private string reformatIntoMMSS(int time)
    {
        int minute = time / 60;
        int second = time % 60;
        string minuteString = minute < 10 ? "0" + minute.ToString() : minute.ToString();
        string secondString = second < 10 ? "0" + second.ToString() : second.ToString();
        return minuteString + ":" + secondString;
    }

    void Start()
    {
        // GUIStyle 초기화
        _guiStyle = new GUIStyle();
        _guiStyle.fontSize = 100;
        _guiStyle.normal.textColor = Color.white;
        _guiStyle.alignment = TextAnchor.MiddleCenter;
    }

    void OnGUI()
    {
        // GameObject의 월드 좌표를 화면 좌표로 변환
        Vector3 screenPosition = Camera.main.WorldToScreenPoint(transform.position);

        // Unity의 GUI는 화면의 Y축이 반전되어 있으므로 변환
        float guiY = Screen.height - screenPosition.y;

        // 텍스트 표시
        GUI.Label(
            new Rect(screenPosition.x - 100, guiY - 25, 200, 50),
            reformatIntoMMSS(_timer.TimeRemaining),
            _guiStyle
        );
    }
}
