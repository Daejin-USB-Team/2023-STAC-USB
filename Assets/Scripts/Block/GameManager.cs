using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    private static GameManager instance;

    // ���� ���� �̸��� �����ϴ� ����
    private string previousSceneName;

    public static GameManager Instance
    {
        get { return instance; }
    }

    private void Awake()
    {
        if (instance != null && instance != this)
        {
            Destroy(gameObject);
            return;
        }

        instance = this;
        DontDestroyOnLoad(gameObject);
    }

    public void SetPreviousScene(string sceneName)
    {
        previousSceneName = sceneName;
    }

    public string GetPreviousScene()
    {
        return previousSceneName;
    }
}

