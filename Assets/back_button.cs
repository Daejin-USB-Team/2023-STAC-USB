using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class back_button : MonoBehaviour
{
    /// <summary>
    /// ������ �̻��� ������ 2���� �Ȱ��� ������ �ù߳�
    /// </summary>
    public void SceneChange()
    {
        SceneManager.LoadScene("camp");
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
