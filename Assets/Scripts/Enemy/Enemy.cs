using System.Collections;
using UnityEngine;

public enum EnemyDestroyType { Kill = 0, Arrive }
public enum EnemyType { enemy1, enemy2, enemy3, enemy4, enemy5, }
public class Enemy : MonoBehaviour
{
    public EnemyType enemyType;
    private int wayPointCount;      // 이동 경로 개수
    private int wayPoint01Count;
    private Transform[] wayPoints;          // 이동 경로 정보
    private Transform[] wayPoints01;
    private int currentIndex = 0;   // 현재 목표지점 인덱스
    private Movement2D movement2D;          // 오브젝트 이동 제어
    private EnemySpawner enemySpawner;      // 적의 삭제를 본인이 하지 않고 EnemySpawner에 알려서 삭제
    [SerializeField]
    private int gold = 30;          // 적 사망 시 획득 가능한 골드

    public void Setup(EnemySpawner enemySpawner, Transform[] wayPoints)
    {
        movement2D = GetComponent<Movement2D>();
        this.enemySpawner = enemySpawner;

        // 적 이동 경로 WayPoints 정보 설정
        if (enemyType == EnemyType.enemy1)
        {
            wayPointCount = wayPoints.Length;
            this.wayPoints = new Transform[wayPointCount];
            this.wayPoints = wayPoints;
            // 적의 위치를 첫번째 wayPoint 위치로 설정
            transform.position = wayPoints[currentIndex].position;
        }
        else if (enemyType == EnemyType.enemy2)
        {
            wayPointCount = wayPoints.Length;
            this.wayPoints = new Transform[wayPointCount];
            this.wayPoints = wayPoints;
            // 적의 위치를 첫번째 wayPoint 위치로 설정
            transform.position = wayPoints[currentIndex].position;
        }


        // 적 이동/목표지점 설정 코루틴 함수 시작
        StartCoroutine("OnMove");
    }
    public void Setup01(EnemySpawner enemySpawner, Transform[] wayPoints01)
    {
        movement2D = GetComponent<Movement2D>();
        this.enemySpawner = enemySpawner;

        // 적 이동 경로 WayPoints 정보 설정
        if (enemyType == EnemyType.enemy1)
        {
            wayPoint01Count = wayPoints01.Length;
            this.wayPoints01 = new Transform[wayPoint01Count];
            this.wayPoints01 = wayPoints01;
            // 적의 위치를 첫번째 wayPoint 위치로 설정
            transform.position = wayPoints01[currentIndex].position;
        }
        else if (enemyType == EnemyType.enemy2)
        {
            wayPoint01Count = wayPoints01.Length;
            this.wayPoints01 = new Transform[wayPoint01Count];
            this.wayPoints01 = wayPoints01;
            // 적의 위치를 첫번째 wayPoint 위치로 설정
            transform.position = wayPoints01[currentIndex].position;
        }


        // 적 이동/목표지점 설정 코루틴 함수 시작
        StartCoroutine("OnMove01");
    }
    private IEnumerator OnMove()
    {
        // 다음 이동 방향 설정
        NextMoveTo();

        while (true)
        {


            // 적의 현재위치와 목표위치의 거리가 0.02 * movement2D.MoveSpeed보다 작을 때 if 조건문 실행
            // Tip. movement2D.MoveSpeed를 곱해주는 이유는 속도가 빠르면 한 프레임에 0.02보다 크게 움직이기 때문에
            // if 조건문에 걸리지 않고 경로를 탈주하는 오브젝트가 발생할 수 있다.
            if (Vector3.Distance(transform.position, wayPoints[currentIndex].position) < 0.02f * movement2D.MoveSpeed)
            {
                // 다음 이동 방향 설정
                NextMoveTo();
            }
            yield return null;
        }
    }
    private IEnumerator OnMove01()
    {
        // 다음 이동 방향 설정
        NextMoveTo01();

        while (true)
        {


            // 적의 현재위치와 목표위치의 거리가 0.02 * movement2D.MoveSpeed보다 작을 때 if 조건문 실행
            // Tip. movement2D.MoveSpeed를 곱해주는 이유는 속도가 빠르면 한 프레임에 0.02보다 크게 움직이기 때문에
            // if 조건문에 걸리지 않고 경로를 탈주하는 오브젝트가 발생할 수 있다.
            if (Vector3.Distance(transform.position, wayPoints01[currentIndex].position) < 0.02f * movement2D.MoveSpeed)
            {
                // 다음 이동 방향 설정
                NextMoveTo01();
            }



            yield return null;
        }
    }
    private void NextMoveTo()
    {
        // 아직 이동할 wayPoints가 남아있다면
        if (currentIndex < wayPointCount - 1)
        {
            // 적의 위치를 정확하게 목표 위치로 설정
            transform.position = wayPoints[currentIndex].position;
            // 이동 방향 설정 => 다음 목표지점(wayPoints)
            currentIndex++;
            Vector3 direction = (wayPoints[currentIndex].position - transform.position).normalized;
            movement2D.MoveTo(direction);
        }
        else
        {
            OnDie(EnemyDestroyType.Arrive);
        }
    }
    private void NextMoveTo01()
    {
        // 아직 이동할 wayPoints가 남아있다면
        if (currentIndex < wayPoint01Count - 1)
        {
            // 적의 위치를 정확하게 목표 위치로 설정
            transform.position = wayPoints01[currentIndex].position;
            // 이동 방향 설정 => 다음 목표지점(wayPoints01)
            currentIndex++;
            Vector3 direction = (wayPoints01[currentIndex].position - transform.position).normalized;
            movement2D.MoveTo(direction);
        }
        else
        {
            OnDie(EnemyDestroyType.Arrive);
        }
    }

    public void OnDie(EnemyDestroyType type)
    {
        // EnemySpawner에서 리스트로 적 정보를 관리하기 때문에 Destroy()를 직접하지 않고
        // EnemySpawner에게 본인이 삭제될 때 필요한 처리를 하도록 DestroyEnemy() 함수 호출
        enemySpawner.DestroyEnemy(type, this, gold);
    }
}


/*
 * File : Enemy.cs
 * Desc
 *	: 지정된 경로(wayPoints)를 따라 이동하는 적
 *	
 * Functions
 *	: Setup() - 초기화 함수
 *	: OnMove() - 경로를 따라 적 이동
 *	: NextMoveTo() - 다음 목표 위치 설정 or 마지막 위치이면 적 삭제
 *	: OnDie() - 적 사망 시 호출. EnemySpawner에게 본인을 삭제하도록 요청
 *	
 */