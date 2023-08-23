using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Xml;
using UnityEngine.UI;
using TMPro;
using UBlockly;  // DataStruct를 인식할 수 있도록 UBlockly를 추가합니다.
public class OutputScript : MonoBehaviour
{
    private string xmlPath = "XmlSave/Default";
    public TextMeshProUGUI outputText;
    public void ReceiveInputFromTextPrintCmdtor(DataStruct inputData)
    {
        string receivedDataString = inputData.ToString();
        Debug.Log("다른 스크립트에서 전달 받은 input 값: " + inputData.ToString());
        outputText.text = receivedDataString;
    }
    // Start is called before the first frame update
    private void Start()
    {
        // XML 파일 로드
        TextAsset xmlAsset = Resources.Load<TextAsset>(xmlPath);
        // XmlDocument 객체 생성
        XmlDocument xmlDocument = new XmlDocument();

        // XML 파일 로드
        xmlDocument.LoadXml(xmlAsset.text);

        // 변수 노드 선택
        XmlNodeList variableNodes = xmlDocument.SelectNodes("/xml/variables/variable");

        // 변수 노드의 id 속성과 값을 저장할 Dictionary 객체 생성
        Dictionary<string, string> variables = new Dictionary<string, string>();

        // 변수 노드의 id와 값 저장
        foreach (XmlNode variableNode in variableNodes)
        {
            string variableId = variableNode.Attributes["id"].Value;
            string variableValue = variableNode.InnerText;

            variables.Add(variableId, variableValue);
        }

        // 변수 노드의 id와 값을 출력
        foreach (KeyValuePair<string, string> variable in variables)
        {
            Debug.Log("Variable id: " + variable.Key + ", value: " + variable.Value);
        }

        // 변수 설정 블록 선택
        XmlNodeList variableSetNodes = xmlDocument.SelectNodes("/xml/block[@type='variables_set']");

        // 변수 설정 블록에서 사용된 변수 id와 값을 저장할 Dictionary 객체 생성
        Dictionary<string, string> variableSets = new Dictionary<string, string>();

        // 변수 설정 블록에서 사용된 변수 id와 값을 저장
        foreach (XmlNode variableSetNode in variableSetNodes)
        {
            XmlNode variableNode = variableSetNode.SelectSingleNode("./field[@name='VAR']");
            if (variableNode == null)
            {
                continue;
            }

            string variableId = variableNode.Attributes["id"].Value;
            string variableValue = variableNode.InnerText;

            XmlNode valueNode = variableSetNode.SelectSingleNode("./value[@name='VALUE']/block/field[@name='NUM']");
            if (valueNode != null)
            {
                variableValue = valueNode.InnerText;
            }

            variableSets.Add(variableId, variableValue);
        }

        // 변수 설정 블록에서 사용된 변수 id와 값을 출력
        foreach (KeyValuePair<string, string> variableSet in variableSets)
        {
            Debug.Log("Used variable id: " + variableSet.Key + ", value: " + variableSet.Value);
        }

    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
