using UnityEngine;
using UnityEngine.UI;

public class StopButton : MonoBehaviour
{
    public GameObject pausePanel; // 일시 정지 패널 오브젝트

    private bool isPaused = false; // 게임 일시 정지 여부

    private void Start()
    {
        // 게임 시작 시 일시 정지 패널을 비활성화
        if (pausePanel != null)
        {
            pausePanel.SetActive(false);
        }
    }

    private void Update()
    {
        // 게임 일시 정지 토글
        if (Input.GetKeyDown(KeyCode.Escape)) // ESC 키를 누르면 일시 정지 토글
        {
            TogglePause();
        }
    }

    public void TogglePause()
    {
        // 게임 일시 정지 상태 토글
        isPaused = !isPaused;

        if (isPaused)
        {
            // 게임 일시 정지 상태일 때
            Time.timeScale = 0f; // 게임 시간을 멈춤
            if (pausePanel != null)
            {
                pausePanel.SetActive(true); // 일시 정지 패널 활성화
            }
        }
        else
        {
            // 게임 일시 정지 상태가 아닐 때
            Time.timeScale = 1f; // 정상적인 게임 속도로 복원
            if (pausePanel != null)
            {
                pausePanel.SetActive(false); // 일시 정지 패널 비활성화
            }
        }
    }
}
