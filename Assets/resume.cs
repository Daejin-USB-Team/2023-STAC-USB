using UnityEngine;
using UnityEngine.UI;

public class Resume : MonoBehaviour
{
    public GameObject pausePanel; // 일시 정지 패널 오브젝트 참조

    public void ResumeGame()
    {
        // 게임 시간을 정상적인 속도로 복원
        Time.timeScale = 1f;

        // 일시 정지 패널을 비활성화
        if (pausePanel != null)
        {
            pausePanel.SetActive(false);
        }
    }
}
