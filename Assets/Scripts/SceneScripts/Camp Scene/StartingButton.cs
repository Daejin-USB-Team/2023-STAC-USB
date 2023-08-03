using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class StartingButton : MonoBehaviour
{
    public GameObject panel1;
    public GameObject panel2;

    void Start()
    {
        panel1.SetActive(false);
        panel2.SetActive(false);
    }
    void Update()
    {
        
    }

    public void UnityButtonClicked()
    {
        panel1.SetActive(true);
        panel2.SetActive(false);
    }

    public void UnrieButtonClicked()
    {
        panel1.SetActive(false);
        panel2.SetActive(true);
    }

    public void BackButtonClicked()
    {
        SceneManager.LoadScene(0);
    }

    public void runButtonClicked()
    {
        SceneManager.LoadScene(2);
    }
}
