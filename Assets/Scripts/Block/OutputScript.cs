using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Xml;
using UnityEngine.UI;
using TMPro;
using UBlockly;  // DataStruct�� �ν��� �� �ֵ��� UBlockly�� �߰��մϴ�.
using UnityEngine.SceneManagement;
public class OutputScript : MonoBehaviour
{
    public GameObject panel1;
    private string xmlPath = "XmlSave/Default";
    public static TextMeshProUGUI outputText;
    private Buff buff;
    private string receivedDataString;
    private int count;
    private MoveBlockCoding moveBlockCoding;
    private TowerWeapon towerWeapon;
    
    public void ReceiveInputFromTextPrintCmdtor(DataStruct inputData)
    {
        receivedDataString = inputData.ToString();
        Debug.Log("�ٸ� ��ũ��Ʈ���� ���� ���� input ��: " + inputData.ToString());
        //outputText.text = receivedDataString; 
        if (count == 0 && receivedDataString == "10")
        {
            MoveBlockCoding.countNum++;
            outputText.text = "�����Դϴ�";
            Debug.Log("�����Դϴپ�"); 
            panel1.SetActive(false);
        }
        else if(count == 1 && receivedDataString == "11")
        {
            MoveBlockCoding.countNum++;

        }
        //�����ϴٸ� ������ Ʃ�丮�� ������
        //���� 3������ �� �����
        //���� ��ù�ư�� �������� ������� Ǯ����ϴ��� �����ֱ�
        //������ �������� ���� ���� ó�� �ý�Ʈ �� �ش� �� Ż��
        //���� ����
        else
        {
            outputText.text = "�����Դϴ�";
        }
    }
    // Start is called before the first frame update
    private void Start()
    {
        moveBlockCoding = GetComponent<MoveBlockCoding>();
        towerWeapon = GetComponent<TowerWeapon>();
        count = MoveBlockCoding.countNum;
        buff = GetComponent<Buff>();

        GameManager.Instance.SetPreviousScene("InGame");
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

