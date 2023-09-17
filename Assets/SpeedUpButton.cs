using UnityEngine;
using UnityEngine.UI;

public class SpeedControl : MonoBehaviour
{
    public Sprite normalImage;
    public Sprite doubledImage;
    public Text speedText;

    private bool isDoubled = false;

    private void Start()
    {
        // �ʱ� �̹��� ����
        UpdateImage();
    }

    public void ToggleSpeed()
    {
        // 2��� ���
        isDoubled = !isDoubled;

        // �̹��� ������Ʈ
        UpdateImage();

        // �ӵ� ������Ʈ
        if (isDoubled)
        {
            Time.timeScale = 2f; // 2������� ����
           // speedText.text = "2x Speed";
        }
        else
        {
            Time.timeScale = 1f; // ���� �ӵ��� ����
           // speedText.text = "1x Speed";
        }
    }

    private void UpdateImage()
    {
        // �̹��� ������Ʈ
        Image image = GetComponent<Image>();
        if (image != null)
        {
            image.sprite = isDoubled ? doubledImage : normalImage;
        }
    }
}
