using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class TimeStop : MonoBehaviour
{
    public bool isPaused = false; // 게임 일시 정지 여부

    public string sliderTag = "EnemyHP";
    void Start()
    {
    }
    private void Update()
    {
        if (isPaused)
        {
            // 게임 일시 정지 상태일 때
            Time.timeScale = 0f; // 게임 시간을 멈춤
            DisableSliders();
        }
        else
        {
            // 게임 일시 정지 상태가 아닐 때
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
        // 게임 일시 정지 상태 토글
        isPaused = !isPaused; 
        
    }
}

