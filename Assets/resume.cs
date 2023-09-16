using UnityEngine;
using UnityEngine.UI;

public class Resume : MonoBehaviour
{
    public GameObject pausePanel; // �Ͻ� ���� �г� ������Ʈ ����

    public void ResumeGame()
    {
        // ���� �ð��� �������� �ӵ��� ����
        Time.timeScale = 1f;

        // �Ͻ� ���� �г��� ��Ȱ��ȭ
        if (pausePanel != null)
        {
            pausePanel.SetActive(false);
        }
    }
}
