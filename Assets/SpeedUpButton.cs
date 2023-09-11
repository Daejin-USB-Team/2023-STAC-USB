using UnityEngine;
using UnityEngine.UI;

public class SpeedUpButton : MonoBehaviour
{
    private bool isSpeedingUp = false;

    private void Start()
    {
        // 초기 버튼 텍스트 설정
        UpdateButtonText();
    }

    public void ToggleSpeed()
    {
        isSpeedingUp = !isSpeedingUp;

        if (isSpeedingUp)
        {
            Time.timeScale = 2f; // 게임 진행 속도 2배
        }
        else
        {
            Time.timeScale = 1f; // 기본 게임 진행 속도
        }

        // 버튼 텍스트 업데이트
        UpdateButtonText();
    }

    private void UpdateButtonText()
    {
        Text buttonText = GetComponentInChildren<Text>();

        if (isSpeedingUp)
        {
            buttonText.text = "1배 속도";
        }
        else
        {
            buttonText.text = "2배 속도";
        }
    }
}