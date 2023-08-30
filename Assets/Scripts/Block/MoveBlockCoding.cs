using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class MoveBlockCoding : MonoBehaviour
{
    public static int countNum = 0;

    //씬 전환하면서
    public void moveCodingScene()
    {
        SceneManager.LoadScene("UGUIDemo");
    }
    //스위치 씬으로 xmlview 파일에서 바로 원하는 파일을 불러와야함
    //그리고 사본을 만들어서 사본에다가 파일의 값이랑 다 받아오기
    
    public void addCount()
    {
        countNum++;
    }
}
