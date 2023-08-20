using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UBlockly;  // DataStruct를 인식할 수 있도록 UBlockly를 추가합니다.
public class OutputScript : MonoBehaviour
{
    public TextMeshProUGUI outputText;
    public void ReceiveInputFromTextPrintCmdtor(DataStruct inputData)
    {
        string receivedDataString = inputData.ToString();
        Debug.Log("다른 스크립트에서 전달 받은 input 값: " + inputData.ToString());
        outputText.text = receivedDataString;
    }
    // Start is called before the first frame update

    // Update is called once per frame
    void Update()
    {
        
    }
}
