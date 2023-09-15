using UnityEngine;
using UnityEngine.UI;

public class PauseButton : MonoBehaviour
{
    public Text buttonText;
    public GameObject pausePrefab; // �������� �Ҵ��� ����
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
            ActivatePausePrefab(true); // ������ Ȱ��ȭ
        }
        else
        {
            Time.timeScale = 1f; // ���� �簳
            buttonText.text = "�Ͻ�����";
            ActivatePausePrefab(false); // ������ ��Ȱ��ȭ
        }
    }

    // �������� Ȱ��ȭ �Ǵ� ��Ȱ��ȭ�ϴ� �޼���
    private void ActivatePausePrefab(bool activate)
    {
        if (pausePrefab != null)
        {
            pausePrefab.SetActive(activate);
        }
    }
}
