using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// ����� �����ϴ� ��ũ��Ʈ
public class Background : MonoBehaviour
{
    // ����� ��ũ���ϴ� �ӵ�
    public Vector2 m_speed;

    // �� �����Ӹ��� ȣ��Ǵ� �Լ�
    private void Update()
    {
        // ��� ��������Ʈ�� ǥ���ϴ� Ŭ������ ���� ������ ����Ѵ�
        var spriteRenderer = GetComponent<SpriteRenderer>();

        // ��� �ؽ�ó�� ǥ���ϴ� ���׸����� ���޹޴´�
        var material = spriteRenderer.material;

        // ��� �ؽ�ó�� ��ũ���Ѵ�
        material.mainTextureOffset += m_speed * Time.deltaTime;
    }
}
