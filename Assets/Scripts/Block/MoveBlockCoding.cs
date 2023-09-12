using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class MoveBlockCoding : MonoBehaviour
{
    public static int countNum =  0;
    public GameObject BuffButton1;
    public GameObject panel1;
    //씬 전환하면서
    public void moveCodingScene()
    {
        panel1.SetActive(true);
        //SceneManager.LoadScene("UGUIDemo");
    }
    private void Update()
    {
        if (countNum == 3)
            BuffButton1.SetActive(false);
    }

}
