using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class MoveBlockCoding : MonoBehaviour
{
    public static int countNum =  0;
    public GameObject panel1;
    //�� ��ȯ�ϸ鼭
    public void moveCodingScene()
    {
        panel1.SetActive(true);
        //SceneManager.LoadScene("UGUIDemo");
    }
    
}
