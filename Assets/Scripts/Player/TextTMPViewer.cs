using UnityEngine;
using TMPro;

public class TextTMPViewer : MonoBehaviour
{
    [SerializeField]
    private TextMeshProUGUI textWave;       // Text - TextMeshPro UI [현재 웨이브 / 총 웨이브]
    [SerializeField]
    private TextMeshProUGUI textEnemyCount; // Text - TextMeshPro UI [현재 적 숫자 / 최대 적 숫자]
    [SerializeField]
    private WaveSystem      waveSystem;     // 웨이브 정보
    [SerializeField]
    private EnemySpawner    enemySpawner;   // 적 정보

    private void Update()
    {
        textWave.text       = waveSystem.CurrentWave + "/" + waveSystem.MaxWave;
        textEnemyCount.text = enemySpawner.CurrentEnemyCount + "/" + enemySpawner.MaxEnemyCount;
    }
}


/*
 * File : TextTMPViewer.cs
 * Desc
 *	: Text-TextMeshPro UI로 표현되는 여러 정보 업데이트
 *	
 */