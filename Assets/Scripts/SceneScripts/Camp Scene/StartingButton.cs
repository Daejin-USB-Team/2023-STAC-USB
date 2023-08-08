using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
public class StartingButton : MonoBehaviour
{
    public GameObject panel1;
    public GameObject panel2;
    public GameObject text;

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
        text.SetActive(false);
    }

    public void UnrieButtonClicked()
    {
        panel1.SetActive(false);
        panel2.SetActive(true);
        text.SetActive(false);
    }

    public void UserBackButtonClicked()
    {
        panel1.SetActive(false);
        panel2.SetActive(false);
        text.SetActive(true);
    }
}
