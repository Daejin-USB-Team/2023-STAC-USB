using UnityEngine;
using UnityEngine.UI;

public class PauseButton : MonoBehaviour
{
    public Text buttonText;
    private bool isPaused = false;

    private void Start()
    {
        buttonText.text = "�Ͻ�����"; // �ʱ� ��ư �ؽ�Ʈ ����
    }

    public void TogglePause()
    {
        isPaused = !isPaused;
        if (isPaused)
        {
            Time.timeScale = 0f; // ���� �Ͻ� ����
            buttonText.text = "�簳";
        }
        else
        {
            Time.timeScale = 1f; // ���� �簳
            buttonText.text = "�Ͻ�����";
        }
    }
}