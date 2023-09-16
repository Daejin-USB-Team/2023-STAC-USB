using UnityEngine;
using UnityEngine.UI;

public class StopButton : MonoBehaviour
{
    public GameObject pausePanel; // �Ͻ� ���� �г� ������Ʈ

    private bool isPaused = false; // ���� �Ͻ� ���� ����

    private void Start()
    {
        // ���� ���� �� �Ͻ� ���� �г��� ��Ȱ��ȭ
        if (pausePanel != null)
        {
            pausePanel.SetActive(false);
        }
    }

    private void Update()
    {
        // ���� �Ͻ� ���� ���
        if (Input.GetKeyDown(KeyCode.Escape)) // ESC Ű�� ������ �Ͻ� ���� ���
        {
            TogglePause();
        }
    }

    public void TogglePause()
    {
        // ���� �Ͻ� ���� ���� ���
        isPaused = !isPaused;

        if (isPaused)
        {
            // ���� �Ͻ� ���� ������ ��
            Time.timeScale = 0f; // ���� �ð��� ����
            if (pausePanel != null)
            {
                pausePanel.SetActive(true); // �Ͻ� ���� �г� Ȱ��ȭ
            }
        }
        else
        {
            // ���� �Ͻ� ���� ���°� �ƴ� ��
            Time.timeScale = 1f; // �������� ���� �ӵ��� ����
            if (pausePanel != null)
            {
                pausePanel.SetActive(false); // �Ͻ� ���� �г� ��Ȱ��ȭ
            }
        }
    }
}
