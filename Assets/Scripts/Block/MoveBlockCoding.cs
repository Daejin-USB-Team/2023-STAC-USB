using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class MoveBlockCoding : MonoBehaviour
{
    public static int countNum = 0;

    //�� ��ȯ�ϸ鼭
    public void moveCodingScene()
    {
        SceneManager.LoadScene("UGUIDemo");
    }
    //����ġ ������ xmlview ���Ͽ��� �ٷ� ���ϴ� ������ �ҷ��;���
    //�׸��� �纻�� ���� �纻���ٰ� ������ ���̶� �� �޾ƿ���
    
    public void addCount()
    {
        countNum++;
    }
}
