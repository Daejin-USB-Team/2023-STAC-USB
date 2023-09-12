using UnityEngine;
using UnityEngine.UI;

public class SpeedUpButton : MonoBehaviour
{
    private bool isSpeedingUp = false;

    private void Start()
    {
        // �ʱ� ��ư �ؽ�Ʈ ����
        UpdateButtonText();
    }

    public void ToggleSpeed()
    {
        isSpeedingUp = !isSpeedingUp;

        if (isSpeedingUp)
        {
            Time.timeScale = 2f; // ���� ���� �ӵ� 2��
        }
        else
        {
            Time.timeScale = 1f; // �⺻ ���� ���� �ӵ�
        }

        // ��ư �ؽ�Ʈ ������Ʈ
        UpdateButtonText();
    }

    private void UpdateButtonText()
    {
        Text buttonText = GetComponentInChildren<Text>();

        if (isSpeedingUp)
        {
            buttonText.text = "1�� �ӵ�";
        }
        else
        {
            buttonText.text = "2�� �ӵ�";
        }
    }
}