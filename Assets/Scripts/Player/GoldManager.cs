using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GoldManager : MonoBehaviour
{
    [SerializeField]
    private TextMeshProUGUI textPlayerGold; // Text - TextMeshPro UI [플레이어의 골드]
    [SerializeField]
    private PlayerGold playerGold;     // 플레이어의 골드 정보

    void Update()
    {
        textPlayerGold.text = playerGold.CurrentGold.ToString();
    }
}
