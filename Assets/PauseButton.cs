using UnityEngine;
using UnityEngine.UI;

public class PauseButton : MonoBehaviour
{
    public Text buttonText;
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
        }
        else
        {
            Time.timeScale = 1f; // 게임 재개
            buttonText.text = "일시정지";
        }
    }
}