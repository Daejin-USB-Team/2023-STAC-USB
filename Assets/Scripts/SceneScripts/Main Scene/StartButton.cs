using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class StartButton : MonoBehaviour
{
    /*
     ��Ʈ��(ȭ�� ��ġ �� �̵�) �� ĳ���� ����(ĳ���� ������ ���۹�ư ������ �̵�) 

�� ���� ����(�ƹ� ���� �̹��� ������ �̵�) 

�� �������� ����(�������� �̹��� ������ �̵�) �� �ڵ� ȭ��(���� ��ư ������ �̵�) ���� ���� 

�� �¸� and �й� â(Ȯ�� ��ư ������ �̵�)

�� �������� ����
     */
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void StartButtonClicked()
    {
        SceneManager.LoadScene(1);
    }
}
