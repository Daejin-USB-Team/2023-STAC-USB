using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Xml;
using UnityEngine.UI;
using TMPro;
using UBlockly;  // DataStruct�� �ν��� �� �ֵ��� UBlockly�� �߰��մϴ�.
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
    private TimeStop timeStop;
    public void ReceiveInputFromTextPrintCmdtor(DataStruct inputData)
    {
        //�ڵ� ����� ���޹޴� ��
        receivedDataString = inputData.ToString();
        Debug.Log("�ٸ� ��ũ��Ʈ���� ���� ���� input ��: " + inputData.ToString());
       
        //������ �´��� üũ�ϴ� if��
        if (count == 0 && receivedDataString == "1")
        {
            //���� �Ͻ����� ����
            timeStop.isPaused = false;
            //���� ����
            buff.TakeBuff();
            //���� ���� ī��Ʈ
            MoveBlockCoding.countNum++; count++;
            BlocklyUI.WorkspaceView.CleanViews();
            //���� ��� �ý�Ʈ ���
            outputText.text = "�����Դϴ�";
            Debug.Log("�����Դϴپ�");
            Invoke("Setfalse", 0.5f);
            Invoke("SetText",2f);
        }
        else if(count == 1 && receivedDataString == "10")
        {
            timeStop.isPaused = false;
            buff.TakeBuff();
            MoveBlockCoding.countNum++; count++;
            BlocklyUI.WorkspaceView.CleanViews();
            outputText.text = "�����Դϴ�";
            Debug.Log("�����Դϴپ�");
            Invoke("Setfalse", 0.5f);
            Invoke("SetText", 2f);
        }
        else if (count == 2 && receivedDataString == "2")
        {
            timeStop.isPaused = false;
            buff.TakeBuff();
            MoveBlockCoding.countNum++; count++;
            BlocklyUI.WorkspaceView.CleanViews();
            outputText.text = "�����Դϴ�";
            Debug.Log("�����Դϴپ�");
            Invoke("Setfalse", 0.5f);
            Invoke("SetText", 2f);
        }
        else
        {
            timeStop.isPaused = false;
            outputText.text = "�����Դϴ�";
            BlocklyUI.WorkspaceView.CleanViews();
            Invoke("Setfalse", 0.5f);
            Invoke("SetText", 2f);
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
            outputText.text = "1.���� 1�� ������ּ���";
        }
        else if (MoveBlockCoding.countNum == 1)
        {
            outputText.text = "1.���� 10���� �������ּ���\n2.���� ������ּ���";
        }
        else if (MoveBlockCoding.countNum == 2)
        {
            outputText.text = "1.������ ������ 1�� �������ּ���\n2.���ÿ� ������ ������ �����ּ���\n3.������ ������ּ���.";
        }
    }
    // Start is called before the first frame update
    private void Start()
    {
        SetText(); 
        timeStop = GetComponent<TimeStop>();
        count = MoveBlockCoding.countNum;
        buff = GetComponent<Buff>();
        // XML ���� �ε�
        TextAsset xmlAsset = Resources.Load<TextAsset>(xmlPath);
        // XmlDocument ��ü ����
        XmlDocument xmlDocument = new XmlDocument();

        // XML ���� �ε�
        xmlDocument.LoadXml(xmlAsset.text);

        // ���� ��� ����
        XmlNodeList variableNodes = xmlDocument.SelectNodes("/xml/variables/variable");

        // ���� ����� id �Ӽ��� ���� ������ Dictionary ��ü ����
        Dictionary<string, string> variables = new Dictionary<string, string>();

        // ���� ����� id�� �� ����
        foreach (XmlNode variableNode in variableNodes)
        {
            string variableId = variableNode.Attributes["id"].Value;
            string variableValue = variableNode.InnerText;

            variables.Add(variableId, variableValue);
        }

        // ���� ����� id�� ���� ���
        foreach (KeyValuePair<string, string> variable in variables)
        {
            Debug.Log("Variable id: " + variable.Key + ", value: " + variable.Value);
        }

        // ���� ���� ��� ����
        XmlNodeList variableSetNodes = xmlDocument.SelectNodes("/xml/block[@type='variables_set']");

        // ���� ���� ��Ͽ��� ���� ���� id�� ���� ������ Dictionary ��ü ����
        Dictionary<string, string> variableSets = new Dictionary<string, string>();

        // ���� ���� ��Ͽ��� ���� ���� id�� ���� ����
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
        
        // ���� ���� ��Ͽ��� ���� ���� id�� ���� ���
        foreach (KeyValuePair<string, string> variableSet in variableSets)
        {
            Debug.Log("Used variable id: " + variableSet.Key + ", value: " + variableSet.Value);
        }
        

    }
}

