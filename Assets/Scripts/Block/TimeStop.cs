using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class TimeStop : MonoBehaviour
{
    public bool isPaused = false; // ���� �Ͻ� ���� ����

    public string sliderTag = "EnemyHP";
    void Start()
    {
    }
    private void Update()
    {
        if (isPaused)
        {
            // ���� �Ͻ� ���� ������ ��
            Time.timeScale = 0f; // ���� �ð��� ����
            DisableSliders();
        }
        else
        {
            // ���� �Ͻ� ���� ���°� �ƴ� ��
            Time.timeScale = 1f;
            OnableSliders();
        }
    }
    private void DisableSliders()
    {
        GameObject[] sliders = GameObject.FindGameObjectsWithTag(sliderTag);

        foreach (GameObject slider in sliders)
        {
            slider.SetActive(false);
        }
    }
    private void OnableSliders()
    {
        GameObject[] sliders = GameObject.FindGameObjectsWithTag(sliderTag);

        foreach (GameObject slider in sliders)
        {
            slider.SetActive(true);
        }
    }
    public void TogglePause()
    {
        // ���� �Ͻ� ���� ���� ���
        isPaused = !isPaused; 
        
    }
}

