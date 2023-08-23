using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Xml;
using UnityEngine.UI;
using TMPro;
using UBlockly;  // DataStruct�� �ν��� �� �ֵ��� UBlockly�� �߰��մϴ�.
public class OutputScript : MonoBehaviour
{
    private string xmlPath = "XmlSave/Default";
    public TextMeshProUGUI outputText;
    public void ReceiveInputFromTextPrintCmdtor(DataStruct inputData)
    {
        string receivedDataString = inputData.ToString();
        Debug.Log("�ٸ� ��ũ��Ʈ���� ���� ���� input ��: " + inputData.ToString());
        outputText.text = receivedDataString;
    }
    // Start is called before the first frame update
    private void Start()
    {
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
    // Update is called once per frame
    void Update()
    {
        
    }
}
