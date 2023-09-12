using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Xml;
using UnityEngine.UI;
using TMPro;
using UBlockly;  // DataStruct를 인식할 수 있도록 UBlockly를 추가합니다.
using UBlockly.UGUI;
using UnityEngine.SceneManagement;
public class OutputScript : MonoBehaviour
{
    public GameObject panel1;
    private string xmlPath = "XmlSave/Default";
    public TextMeshProUGUI outputText;
    private Buff buff;
    private string receivedDataString;
    private int count;
    private MoveBlockCoding moveBlockCoding;
    private TowerWeapon towerWeapon;
    
    public void ReceiveInputFromTextPrintCmdtor(DataStruct inputData)
    {
        receivedDataString = inputData.ToString();
        Debug.Log("다른 스크립트에서 전달 받은 input 값: " + inputData.ToString());
        //outputText.text = receivedDataString; 

        //가능하다면 고정형 튜토리얼 만들어보기
        //문제 3개정도 더 만들기
        //문제 출시버튼을 눌렀을때 어떤문제를 풀어야하는지 적어주기
        //실행을 눌렀을때 정답 오답 처리 택스트 및 해당 씬 탈출
        //버프 지급
        
        if (count == 0 && receivedDataString == "1")
        {
            MoveBlockCoding.countNum++;
            BlocklyUI.WorkspaceView.CleanViews();
            outputText.text = "정답입니다";
            Debug.Log("정답입니다아");
            Invoke("Setfalse", 3f);
            Invoke("SetText",4f);
        }
        else if(count == 1 && receivedDataString == "10")
        {
            MoveBlockCoding.countNum++;
            BlocklyUI.WorkspaceView.CleanViews();
            outputText.text = "정답입니다";
            Debug.Log("정답입니다아");
            Invoke("Setfalse", 3f);
            Invoke("SetText", 4f);
        }
        else if (count == 2 && receivedDataString == "2")
        {
            MoveBlockCoding.countNum++;
            BlocklyUI.WorkspaceView.CleanViews();
            outputText.text = "정답입니다";
            Debug.Log("정답입니다아");
            Invoke("Setfalse", 3f);
            Invoke("SetText", 4f);
        }
        else
        {
            outputText.text = "오답입니다";
            BlocklyUI.WorkspaceView.CleanViews();
            Invoke("Setfalse", 3f);
        }
    }

    private void SetTrue()
    {
        panel1.SetActive(true);
    }
    private void Setfalse()
    {
        panel1.SetActive(false);
    }
    private void SetText()
    {
        if (MoveBlockCoding.countNum == 0)
        {
            outputText.text = "1.숫자 1을 출력해주세요";
        }
        else if (MoveBlockCoding.countNum == 1)
        {
            outputText.text = "1.돌을 10으로 설정해주세요\n2.돌을 출력해주세요";
        }
        else if (MoveBlockCoding.countNum == 2)
        {
            outputText.text = "1.돌과 나무를 각각 1로 설정해주세요\n2.석궁에 돌과 나무를 더해주세요\n3.석궁을 출력해주세요.";
        }
    }
    // Start is called before the first frame update
    private void Start()
    {
        SetText();
        moveBlockCoding = GetComponent<MoveBlockCoding>();
        towerWeapon = GetComponent<TowerWeapon>();
        count = MoveBlockCoding.countNum;
        buff = GetComponent<Buff>();

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
}

