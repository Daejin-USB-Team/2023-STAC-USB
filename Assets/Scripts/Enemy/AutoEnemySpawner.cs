using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AutoEnemySpawner : MonoBehaviour
{


	[SerializeField]
	private GameObject enemyHPSliderPrefab; // �� ü���� ��Ÿ���� Slider UI ������
	[SerializeField]
	private Transform canvasTransform;      // UI�� ǥ���ϴ� Canvas ������Ʈ�� Transform
	[SerializeField]
	private Transform[] wayPoints;              // ���� ���������� �̵� ���
	[SerializeField]
	private Transform[] wayPoints01;
	[SerializeField]
	private PlayerHP playerHP;              // �÷��̾��� ü�� ����
	[SerializeField]
	private PlayerGold playerGold;              // �÷��̾��� ��� ����
	private AutoWave currentWave;           // ���� ���̺� ����
	private int currentEnemyCount;      // ���� ���̺꿡 �����ִ� �� ���� (���̺� ���۽� max�� ����, �� ��� �� -1)
	private List<AutoEnemy> enemyList;              // ���� �ʿ� �����ϴ� ��� ���� ����

	// ���� ������ ������ EnemySpawner���� �ϱ� ������ Set�� �ʿ� ����.
	public List<AutoEnemy> EnemyList => enemyList;
	// ���� ���̺��� �����ִ� ��, �ִ� �� ����
	public int CurrentEnemyCount => currentEnemyCount;
	public int MaxEnemyCount => currentWave.maxEnemyCount;

	private void Awake()
	{
		// �� ����Ʈ �޸� �Ҵ�
		enemyList = new List<AutoEnemy>();
	}

	public void StartWave(AutoWave wave)
	{
		// �Ű������� �޾ƿ� ���̺� ���� ����
		currentWave = wave;
		// ���� ���̺��� �ִ� �� ���ڸ� ����
		currentEnemyCount = currentWave.maxEnemyCount;
		// ���� ���̺� ����
		StartCoroutine("SpawnEnemy");
		StartCoroutine("SpawnEnemy01");
	}

	private IEnumerator SpawnEnemy()
	{
		// ���� ���̺꿡�� ������ �� ����
		int spawnEnemyCount = 0;


		// ���� ���̺꿡�� �����Ǿ�� �ϴ� ���� ���ڸ�ŭ ���� �����ϰ� �ڷ�ƾ ����
		while (spawnEnemyCount < currentWave.maxEnemyCount)
		{
			// ���̺꿡 �����ϴ� ���� ������ ���� ������ �� ������ ���� �����ϵ��� �����ϰ�, �� ������Ʈ ����
			int enemyIndex = Random.Range(0, currentWave.enemyPrefabs.Length);
			GameObject clone = Instantiate(currentWave.enemyPrefabs[enemyIndex]);
			AutoEnemy enemy = clone.GetComponent<AutoEnemy>();  // ��� ������ ���� Enemy ������Ʈ

			// this�� �� �ڽ� (�ڽ��� EnemySpawner ����)
			enemy.Setup(this, wayPoints);            // wayPoint ������ �Ű������� Setup() ȣ��
			enemyList.Add(enemy);                                   // ����Ʈ�� ��� ������ �� ���� ����

			SpawnEnemyHPSlider(clone);                              // �� ü���� ��Ÿ���� Slider UI ���� �� ����

			// ���� ���̺꿡�� ������ ���� ���� +1
			spawnEnemyCount++;

			// �� ���̺긶�� spawnTime�� �ٸ� �� �ֱ� ������ ���� ���̺�(currentWave)�� spawnTime ���
			yield return new WaitForSeconds(currentWave.spawnTime); // spawnTime �ð� ���� ���
		}

	}
	private IEnumerator SpawnEnemy01()
	{
		// ���� ���̺꿡�� ������ �� ����
		int spawnEnemyCount = 0;

		while (spawnEnemyCount < currentWave.maxEnemyCount)
		{
			// ���̺꿡 �����ϴ� ���� ������ ���� ������ �� ������ ���� �����ϵ��� �����ϰ�, �� ������Ʈ ����
			int enemyIndex = Random.Range(0, currentWave.enemyPrefabs.Length);
			GameObject clone = Instantiate(currentWave.enemyPrefabs[enemyIndex]);
			AutoEnemy enemy = clone.GetComponent<AutoEnemy>();  // ��� ������ ���� Enemy ������Ʈ

			// this�� �� �ڽ� (�ڽ��� EnemySpawner ����)
			enemy.Setup01(this, wayPoints01);            // wayPoint ������ �Ű������� Setup() ȣ��
			enemyList.Add(enemy);                                   // ����Ʈ�� ��� ������ �� ���� ����

			SpawnEnemyHPSlider(clone);                              // �� ü���� ��Ÿ���� Slider UI ���� �� ����

			// ���� ���̺꿡�� ������ ���� ���� +1
			spawnEnemyCount++;

			// �� ���̺긶�� spawnTime�� �ٸ� �� �ֱ� ������ ���� ���̺�(currentWave)�� spawnTime ���
			yield return new WaitForSeconds(currentWave.spawnTime); // spawnTime �ð� ���� ���
		}
	}

	public void DestroyEnemy(EnemyDestroyType type, AutoEnemy enemy, int gold)
	{
		// ���� ��ǥ�������� �������� ��
		if (type == EnemyDestroyType.Arrive)
		{
			// �÷��̾��� ü�� -1
			playerHP.TakeDamage(1);
		}
		// ���� �÷��̾��� �߻�ü���� ������� ��
		else if (type == EnemyDestroyType.Kill)
		{
			// ���� ������ ���� ��� �� ��� ȹ��
			playerGold.CurrentGold += gold;
		}

		// ���� ����� ������ ���� ���̺��� ���� �� ���� ���� (UI ǥ�ÿ�)
		currentEnemyCount--;
		// ����Ʈ���� ����ϴ� �� ���� ����
		enemyList.Remove(enemy);
		// �� ������Ʈ ����
		Destroy(enemy.gameObject);
	}

	private void SpawnEnemyHPSlider(GameObject enemy)
	{
		// �� ü���� ��Ÿ���� Slider UI ����
		GameObject sliderClone = Instantiate(enemyHPSliderPrefab);
		// Slider UI ������Ʈ�� parent("Canvas" ������Ʈ)�� �ڽ����� ����
		// Tip. UI�� ĵ������ �ڽĿ�����Ʈ�� �����Ǿ� �־�� ȭ�鿡 ���δ�
		sliderClone.transform.SetParent(canvasTransform);
		// ���� �������� �ٲ� ũ�⸦ �ٽ� (1, 1, 1)�� ����
		sliderClone.transform.localScale = Vector3.one;

		// Slider UI�� �Ѿƴٴ� ����� �������� ����
		sliderClone.GetComponent<SliderPositionAutoSetter>().Setup(enemy.transform);
		// Slider UI�� �ڽ��� ü�� ������ ǥ���ϵ��� ����
		sliderClone.GetComponent<EnemyHPViewer>().Setup(enemy.GetComponent<EnemyHP>());
	}
}
