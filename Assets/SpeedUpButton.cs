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
        // 초기 이미지 설정
        UpdateImage();
    }

    public void ToggleSpeed()
    {
        // 2배속 토글
        isDoubled = !isDoubled;

        // 이미지 업데이트
        UpdateImage();

        // 속도 업데이트
        if (isDoubled)
        {
            Time.timeScale = 2f; // 2배속으로 설정
           // speedText.text = "2x Speed";
        }
        else
        {
            Time.timeScale = 1f; // 정상 속도로 설정
           // speedText.text = "1x Speed";
        }
    }

    private void UpdateImage()
    {
        // 이미지 업데이트
        Image image = GetComponent<Image>();
        if (image != null)
        {
            image.sprite = isDoubled ? doubledImage : normalImage;
        }
    }
}
