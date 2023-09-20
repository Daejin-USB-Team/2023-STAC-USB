using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
public class Buff : MonoBehaviour
{
    public TowerWeapon towerWeapon;
    public GameObject buffIcon;
    private bool buff = false;
    private void Start()
    {
        towerWeapon = GetComponent<TowerWeapon>();
    }
    public void TakeBuff()
    {
        StartCoroutine(OnBuffCoroutine(10));
    }
    IEnumerator OnBuffCoroutine(int time)
    {
        buffIcon.SetActive(true);
        while (time > 0)
        {
            GameObject[] towers = GameObject.FindGameObjectsWithTag("Tower");
            for (int i = 0; i < towers.Length; ++i)
            {
                TowerWeapon weapon = towers[i].GetComponent<TowerWeapon>();
                // 공격이 가능한 캐논, 레이저 타워이면
                if (time > 1)
                {
                    // 버프에 의해 공격력 증가
                    weapon.AddedDamage = weapon.Damage + 5f;
                }
                else
                {
                    weapon.AddedDamage = weapon.Damage - 5f;
                }
            }
            time--;
            yield return new WaitForSeconds(10);
        }
        buffIcon.SetActive(false);
    }
    private void Update()
    {
    }
}
