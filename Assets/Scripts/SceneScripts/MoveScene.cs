using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MoveScene : MonoBehaviour
{
    /*
    ��Ʈ��(ȭ�� ��ġ �� �̵�) �� ĳ���� ����(ĳ���� ������ ���۹�ư ������ �̵�)

    �� ���� ����(�ƹ� ���� �̹��� ������ �̵�)

    �� �������� ����(�������� �̹��� ������ �̵�) �� �ڵ� ȭ��(���� ��ư ������ �̵�) ���� ���� 

    �� �¸� and �й� â(Ȯ�� ��ư ������ �̵�)

    �� �������� ����
    */

    //�̵��� �� �̸�
    public string transferMapName;
    //��ư�� Ŭ���� �� �̵�
    public void ButtonClicked()
    {
        SceneManager.LoadScene(transferMapName);
    }
}
