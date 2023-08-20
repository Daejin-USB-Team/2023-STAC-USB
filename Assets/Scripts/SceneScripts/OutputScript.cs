using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UBlockly;  // DataStruct�� �ν��� �� �ֵ��� UBlockly�� �߰��մϴ�.
public class OutputScript : MonoBehaviour
{
    public TextMeshProUGUI outputText;
    public void ReceiveInputFromTextPrintCmdtor(DataStruct inputData)
    {
        string receivedDataString = inputData.ToString();
        Debug.Log("�ٸ� ��ũ��Ʈ���� ���� ���� input ��: " + inputData.ToString());
        outputText.text = receivedDataString;
    }
    // Start is called before the first frame update

    // Update is called once per frame
    void Update()
    {
        
    }
}
