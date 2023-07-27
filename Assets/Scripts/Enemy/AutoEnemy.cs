using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AutoEnemy : MonoBehaviour
{
	public EnemyType enemyType;
	private int wayPointCount;      // �̵� ��� ����
	private int wayPoint01Count;
	private Transform[] wayPoints;          // �̵� ��� ����
	private Transform[] wayPoints01;
	private int currentIndex = 0;   // ���� ��ǥ���� �ε���
	private Movement2D movement2D;          // ������Ʈ �̵� ����
	private AutoEnemySpawner enemySpawner;      // ���� ������ ������ ���� �ʰ� EnemySpawner�� �˷��� ����
	[SerializeField]
	private int gold = 10;          // �� ��� �� ȹ�� ������ ���

	public void Setup(AutoEnemySpawner enemySpawner, Transform[] wayPoints)
	{
		movement2D = GetComponent<Movement2D>();
		this.enemySpawner = enemySpawner;

		// �� �̵� ��� WayPoints ���� ����
		if (enemyType == EnemyType.enemy1)
		{
			wayPointCount = wayPoints.Length;
			this.wayPoints = new Transform[wayPointCount];
			this.wayPoints = wayPoints;
			// ���� ��ġ�� ù��° wayPoint ��ġ�� ����
			transform.position = wayPoints[currentIndex].position;
		}
		else if (enemyType == EnemyType.enemy2)
		{
			wayPointCount = wayPoints.Length;
			this.wayPoints = new Transform[wayPointCount];
			this.wayPoints = wayPoints;
			// ���� ��ġ�� ù��° wayPoint ��ġ�� ����
			transform.position = wayPoints[currentIndex].position;
		}


		// �� �̵�/��ǥ���� ���� �ڷ�ƾ �Լ� ����
		StartCoroutine("OnMove");
	}
	public void Setup01(AutoEnemySpawner enemySpawner, Transform[] wayPoints01)
	{
		movement2D = GetComponent<Movement2D>();
		this.enemySpawner = enemySpawner;

		// �� �̵� ��� WayPoints ���� ����
		if (enemyType == EnemyType.enemy1)
		{
			wayPoint01Count = wayPoints01.Length;
			this.wayPoints01 = new Transform[wayPoint01Count];
			this.wayPoints01 = wayPoints01;
			// ���� ��ġ�� ù��° wayPoint ��ġ�� ����
			transform.position = wayPoints01[currentIndex].position;
		}
		else if (enemyType == EnemyType.enemy2)
		{
			wayPoint01Count = wayPoints01.Length;
			this.wayPoints01 = new Transform[wayPoint01Count];
			this.wayPoints01 = wayPoints01;
			// ���� ��ġ�� ù��° wayPoint ��ġ�� ����
			transform.position = wayPoints01[currentIndex].position;
		}


		// �� �̵�/��ǥ���� ���� �ڷ�ƾ �Լ� ����
		StartCoroutine("OnMove01");
	}
	private IEnumerator OnMove()
	{
		// ���� �̵� ���� ����
		NextMoveTo();

		while (true)
		{
			// �� ������Ʈ ȸ��
			transform.Rotate(Vector3.forward * 10);

			// ���� ������ġ�� ��ǥ��ġ�� �Ÿ��� 0.02 * movement2D.MoveSpeed���� ���� �� if ���ǹ� ����
			// Tip. movement2D.MoveSpeed�� �����ִ� ������ �ӵ��� ������ �� �����ӿ� 0.02���� ũ�� �����̱� ������
			// if ���ǹ��� �ɸ��� �ʰ� ��θ� Ż���ϴ� ������Ʈ�� �߻��� �� �ִ�.
			if (Vector3.Distance(transform.position, wayPoints[currentIndex].position) < 0.02f * movement2D.MoveSpeed)
			{
				// ���� �̵� ���� ����
				NextMoveTo();
			}
			yield return null;
		}
	}
	private IEnumerator OnMove01()
	{
		// ���� �̵� ���� ����
		NextMoveTo01();

		while (true)
		{
			// �� ������Ʈ ȸ��
			transform.Rotate(Vector3.forward * 10);

			// ���� ������ġ�� ��ǥ��ġ�� �Ÿ��� 0.02 * movement2D.MoveSpeed���� ���� �� if ���ǹ� ����
			// Tip. movement2D.MoveSpeed�� �����ִ� ������ �ӵ��� ������ �� �����ӿ� 0.02���� ũ�� �����̱� ������
			// if ���ǹ��� �ɸ��� �ʰ� ��θ� Ż���ϴ� ������Ʈ�� �߻��� �� �ִ�.
			if (Vector3.Distance(transform.position, wayPoints01[currentIndex].position) < 0.02f * movement2D.MoveSpeed)
			{
				// ���� �̵� ���� ����
				NextMoveTo01();
			}



			yield return null;
		}
	}
	private void NextMoveTo()
	{
		// ���� �̵��� wayPoints�� �����ִٸ�
		if (currentIndex < wayPointCount - 1)
		{
			// ���� ��ġ�� ��Ȯ�ϰ� ��ǥ ��ġ�� ����
			transform.position = wayPoints[currentIndex].position;
			// �̵� ���� ���� => ���� ��ǥ����(wayPoints)
			currentIndex++;
			Vector3 direction = (wayPoints[currentIndex].position - transform.position).normalized;
			movement2D.MoveTo(direction);
		}
		else
		{
			// ��ǥ������ �����ؼ� ����� ���� ���� ���� �ʵ���
			gold = 0;
			// �� ������Ʈ ����
			OnDie(EnemyDestroyType.Arrive);
		}// ���� �̵��� wayPoints�� �����ִٸ�
	}
	private void NextMoveTo01()
	{
		// ���� �̵��� wayPoints�� �����ִٸ�
		if (currentIndex < wayPoint01Count - 1)
		{
			// ���� ��ġ�� ��Ȯ�ϰ� ��ǥ ��ġ�� ����
			transform.position = wayPoints01[currentIndex].position;
			// �̵� ���� ���� => ���� ��ǥ����(wayPoints01)
			currentIndex++;
			Vector3 direction = (wayPoints01[currentIndex].position - transform.position).normalized;
			movement2D.MoveTo(direction);
		}
		else
		{
			// ��ǥ������ �����ؼ� ����� ���� ���� ���� �ʵ���
			gold = 0;
			// �� ������Ʈ ����
			OnDie(EnemyDestroyType.Arrive);
		}// ���� �̵��� wayPoints�� �����ִٸ�
	}

	public void OnDie(EnemyDestroyType type)
	{
		// EnemySpawner���� ����Ʈ�� �� ������ �����ϱ� ������ Destroy()�� �������� �ʰ�
		// EnemySpawner���� ������ ������ �� �ʿ��� ó���� �ϵ��� DestroyEnemy() �Լ� ȣ��
		enemySpawner.DestroyEnemy(type, this, gold);
	}
}
