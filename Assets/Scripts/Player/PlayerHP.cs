using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class PlayerHP : MonoBehaviour
{
    [SerializeField]
    private Image imageScreen;    // 전체화면을 덮는 빨간색 이미지
    public static int health = 5;
    public Image[] hearts;
    public Sprite fullHp;
    public Sprite emptyHp;
    public GameObject gameOverPanel;
    private void Start()
    {
        gameOverPanel.SetActive(false);
    }
    public void TakeDamage(int damage)
    {
        // 현재 체력을 damage만큼 감소
        HpManager.health -= damage;

        // 체력이 0이 되면 게임오버
        if (HpManager.health <= 0)
        {
            gameObject.SetActive(false);
            gameOverPanel.SetActive(true);
        }
    }

    private IEnumerator HitAlphaAnimation()
    {
        // 전체화면 크기로 배치된 imageScreen의 색상을 color 변수에 저장
        // imageScreen의 투명도를 40%로 설정
        Color color = imageScreen.color;
        color.a = 0.4f;
        imageScreen.color = color;

        // 투명도가 0%가 될때까지 감소
        while (color.a >= 0.0f)
        {
            color.a -= Time.deltaTime;
            imageScreen.color = color;

            yield return null;
        }
    }
}


/*
 * File : PlayerHP.cs
 * Desc
 *   : 플레이어 캐릭터의 체력
 *   
 * Functions
 *   : TakeDamage() - 체력 감소
 *   : HitAlphaAnimation() - 전체화면 크기로 배치된 이미지 투명도 변경 (40% -> 0%)
 */