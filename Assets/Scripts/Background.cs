using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// 배경을 제어하는 스크립트
public class Background : MonoBehaviour
{
    // 배경을 스크롤하는 속도
    public Vector2 m_speed;

    // 매 프레임마다 호출되는 함수
    private void Update()
    {
        // 배경 스프라이트를 표시하는 클래스에 대한 정보를 취득한다
        var spriteRenderer = GetComponent<SpriteRenderer>();

        // 배경 텍스처를 표시하는 마테리얼을 전달받는다
        var material = spriteRenderer.material;

        // 배경 텍스처를 스크롤한다
        material.mainTextureOffset += m_speed * Time.deltaTime;
    }
}
