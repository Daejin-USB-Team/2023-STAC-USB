using UnityEngine;
using System.Collections;
using UnityEngine.UI;
public class WaveSystem : MonoBehaviour
{
	public GameObject WinPanel;
	[SerializeField]
	private	Wave[]			waves;					// 현재 스테이지의 모든 웨이브 정보
	[SerializeField]
	private	EnemySpawner	enemySpawner;
	private	int				currentWaveIndex = -1;  // 현재 웨이브 인덱스
	public Text outputText;
	private float waveCount=0;
	private bool waveCheek;
	// 웨이브 정보 출력을 위한 Get 프로퍼티 (현재 웨이브, 총 웨이브)
	public	int				CurrentWave => currentWaveIndex+1;		// 시작이 0이기 때문에 +1
	public	int				MaxWave => waves.Length * 2;
	public void Start()
	{
		WinPanel.SetActive(false);
		StartCoroutine("AutoStartWave");
	}
	private IEnumerator AutoStartWave()
	{
		yield return new WaitForSeconds(20.0f);
	}
    void Update()
    {
        if(waveCount < 0)
        {
			waveCheek = true;
		}
		if(waveCheek == true && currentWaveIndex != 3)
        {
			waveCount = 20f;
			waveCheek = false;
			StartWave();
		}
		if(currentWaveIndex == 2 && enemySpawner.EnemyList.Count == 0)
        {
			WinPanel.SetActive(true);
		}
		waveCount -= Time.deltaTime;
		outputText.text = "다음 웨이브까지 남은 시간 :"+waveCount.ToString("F1");
		Debug.Log(currentWaveIndex);
		Debug.Log(enemySpawner.EnemyList.Count);
    }
    public void StartWave()
	{
		// 현재 맵에 적이 없고, Wave가 남아있으면
		if ( enemySpawner.EnemyList.Count == 0 && currentWaveIndex < waves.Length-1 )
		{
			// 인덱스의 시작이 -1이기 때문에 웨이브 인덱스 증가를 제일 먼저 함
			currentWaveIndex ++;
			// EnemySpawner의 StartWave() 함수 호출. 현재 웨이브 정보 제공
			enemySpawner.StartWave(waves[currentWaveIndex]);
		}
	}
}

[System.Serializable]
public struct AutoWave
{
    public  float        spawnTime;     // 현재 웨이브 적 생성 주기
    public  int          maxEnemyCount; // 현재 웨이브 적 등장 숫자
    public  GameObject[] enemyPrefabs;  // 현재 웨이브 적 등장 종류
}


/*
 * File : WaveSystem.cs
 * Desc
 *	: 웨이브 시스템 정보
 *
 */