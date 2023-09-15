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
        // 이미지 컴포넌트 가져오기
        image = GameObject.Find("Image").GetComponent<Image>();

        // 초기 이미지 설정
        image.sprite = spritea;
    }

    public void OnButtonClick()
    {
        // 이미지 변경
        if (isSprite1)
        {
            image.sprite = spriteb;
        }
        else
        {
            image.sprite = spritea;
        }

        // 게임 속도 변경
        isSprite1 = !isSprite1;
        ToggleGameSpeed();
    }

    private void ToggleGameSpeed()
    {
        // 게임 속도 변경 (2배속 토글)
        if (!isFastForward)
        {
            Time.timeScale = 2f; // 2배속
        }
        else
        {
            Time.timeScale = 1f; // 원래 속도
        }

        isFastForward = !isFastForward;
    }
}
