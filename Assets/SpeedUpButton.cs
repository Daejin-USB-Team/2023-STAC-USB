using UnityEngine;
using UnityEngine.UI;

public class ImageAndSpeedSwitcher : MonoBehaviour
{
    public Image image;
    public Sprite spritea;
    public Sprite spriteb;
    private bool isSprite1 = true;
    private bool isFastForward = false;

    private void Start()
    {
        // �̹��� ������Ʈ ��������
        image = GameObject.Find("Image").GetComponent<Image>();

        // �ʱ� �̹��� ����
        image.sprite = spritea;
    }

    public void OnButtonClick()
    {
        // �̹��� ����
        if (isSprite1)
        {
            image.sprite = spriteb;
        }
        else
        {
            image.sprite = spritea;
        }

        // ���� �ӵ� ����
        isSprite1 = !isSprite1;
        ToggleGameSpeed();
    }

    private void ToggleGameSpeed()
    {
        // ���� �ӵ� ���� (2��� ���)
        if (!isFastForward)
        {
            Time.timeScale = 2f; // 2���
        }
        else
        {
            Time.timeScale = 1f; // ���� �ӵ�
        }

        isFastForward = !isFastForward;
    }
}
