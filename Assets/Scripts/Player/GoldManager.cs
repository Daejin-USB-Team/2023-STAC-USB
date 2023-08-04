using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GoldManager : MonoBehaviour
{
    [SerializeField]
    private TextMeshProUGUI textPlayerGold; // Text - TextMeshPro UI [�÷��̾��� ���]
    [SerializeField]
    private PlayerGold playerGold;     // �÷��̾��� ��� ����

    void Update()
    {
        textPlayerGold.text = playerGold.CurrentGold.ToString();
    }
}
