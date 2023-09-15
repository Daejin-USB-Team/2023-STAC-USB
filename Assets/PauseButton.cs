using UnityEngine;
using UnityEngine.UI;

public class PauseButton : MonoBehaviour
{
    public Text buttonText;
    public GameObject pausePrefab; // 프리팹을 할당할 변수
    private bool isPaused = false;

    private void Start()
    {
        buttonText.text = "일시정지"; // 초기 버튼 텍스트 설정
    }

    public void TogglePause()
    {
        isPaused = !isPaused;
        if (isPaused)
        {
            Time.timeScale = 0f; // 게임 일시 정지
            buttonText.text = "재개";
            ActivatePausePrefab(true); // 프리팹 활성화
        }
        else
        {
            Time.timeScale = 1f; // 게임 재개
            buttonText.text = "일시정지";
            ActivatePausePrefab(false); // 프리팹 비활성화
        }
    }

    // 프리팹을 활성화 또는 비활성화하는 메서드
    private void ActivatePausePrefab(bool activate)
    {
        if (pausePrefab != null)
        {
            pausePrefab.SetActive(activate);
        }
    }
}
