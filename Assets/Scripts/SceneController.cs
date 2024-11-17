using UnityEngine.SceneManagement;
using UnityEngine;

public class SceneController : MonoBehaviour
{
    public void ReloadCurrentScene()
    {
        // 현재 활성화된 씬의 이름을 가져와서 로드
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void LoadNextScene()
    {
        // 현재 씬의 다음 씬을 가져와 로드
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
}
