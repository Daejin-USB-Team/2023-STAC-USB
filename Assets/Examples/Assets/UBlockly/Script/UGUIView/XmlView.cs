/****************************************************************************

Copyright 2016 sophieml1989@gmail.com

Licensed under the Apache License, Version 2.0 (the "License");
you may not use this file except in compliance with the License.
You may obtain a copy of the License at

    http://www.apache.org/licenses/LICENSE-2.0

Unless required by applicable law or agreed to in writing, software
distributed under the License is distributed on an "AS IS" BASIS,
WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
See the License for the specific language governing permissions and
limitations under the License.

****************************************************************************/


using System;
using System.Collections;
using System.IO;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.Networking;
using UnityEngine.UI;

namespace UBlockly.UGUI
{
    /// <summary>
    /// Deal with Workspace - XML save and load
    /// </summary>
    public class XmlView : MonoBehaviour
    {
        [SerializeField] protected Button m_SaveBtn;
        [SerializeField] protected Button m_LoadBtn;

        [SerializeField] protected GameObject m_SavePanel;
        [SerializeField] protected InputField m_SaveNameInput;
        [SerializeField] protected Button m_SaveOkBtn;

        [SerializeField] protected GameObject m_LoadPanel;
        [SerializeField] protected RectTransform m_ScrollContent;
        [SerializeField] protected GameObject m_XmlBtnPrefab;

        protected bool mIsSavePanelShow
        {
            get { return m_SavePanel.activeInHierarchy; }
        }

        protected bool mIsLoadPanelShow
        {
            get { return m_LoadPanel.activeInHierarchy; }
        }
        
        protected string mSavePath;
            // Resources 폴더 경로
        private const string ResourcePath = "XmlSave";
           // Resources 폴더에 저장된 파일 경로 가져오기
        private string GetResourcePath(string fileName)
        {
            return Path.Combine(ResourcePath, fileName);
        }
        private void Awake()
        {
            //LoadXml();
            HideSavePanel();
            HideLoadPanel();
            m_SaveBtn.onClick.AddListener(SaveXml);
            m_LoadBtn.onClick.AddListener(LoadXml);
            /*
            m_SaveBtn.onClick.AddListener(() =>
            {
                
                if (!mIsSavePanelShow) ShowSavePanel();
                else HideSavePanel();
                
            });
            
            */
            /*
            m_LoadBtn.onClick.AddListener(() =>
            {
                if (!mIsLoadPanelShow) ShowLoadPanel();
                else HideLoadPanel();
            });
            */
            //m_SaveOkBtn.onClick.AddListener(SaveXml);
        }

        protected virtual void ShowSavePanel()
        {
            m_SavePanel.SetActive(true);
            m_LoadPanel.SetActive(false);
        }

        protected virtual void HideSavePanel()
        {
            m_SavePanel.SetActive(false);
        }
        
        protected virtual void ShowLoadPanel()
        {
            m_LoadPanel.SetActive(true);
            m_SavePanel.SetActive(false);
            /*
            TextAsset[] xmlFiles = Resources.LoadAll<TextAsset>(ResourcePath);
            for (int i = 0; i < xmlFiles.Length; i++)
            {
                string fileName = Path.GetFileNameWithoutExtension(xmlFiles[i].name);
                if (!string.IsNullOrEmpty(fileName))
                {
                    GameObject btnXml = GameObject.Instantiate(m_XmlBtnPrefab, m_ScrollContent, false);
                    btnXml.SetActive(true);
                    btnXml.GetComponentInChildren<Text>().text = fileName;
                    string tempFileName = fileName; // 클로저 문제 해결을 위해 임시 변수에 할당
                    btnXml.GetComponent<Button>().onClick.AddListener(() => LoadXml());
                }
            }
            */
        }
        


        protected virtual void HideLoadPanel()
        {
            m_LoadPanel.SetActive(false);

            for (int i = 1; i < m_ScrollContent.childCount; i++)
            {
                GameObject.Destroy(m_ScrollContent.GetChild(i).gameObject);
            }
        }

        protected virtual void SaveXml()
        {
            var dom = UBlockly.Xml.WorkspaceToDom(BlocklyUI.WorkspaceView.Workspace);
            string text = UBlockly.Xml.DomToText(dom);

            // 저장할 파일 이름 설정 (InputField의 값을 사용하려면 주석 해제)
            //string fileName = !string.IsNullOrEmpty(m_SaveNameInput.text) ? 
            //                  $"{m_SaveNameInput.text}.xml" : "Default.xml";

            string fileName = "Default.xml";  // 기본 파일 이름은 Default.xml로 설정

            string resourceFilePath = GetResourcePath(fileName);

            TextAsset existingFile = Resources.Load<TextAsset>(resourceFilePath);

            if (existingFile != null)
            {
                Debug.Log("파일이 이미 존재합니다. 덮어쓰시겠습니까?");
                return;  // 이미 동일한 이름의 파일이 존재하면 중복 저장하지 않음.
            }

            string saveFolderPath = Path.Combine(Application.dataPath, "Resources", ResourcePath);

            if (!Directory.Exists(saveFolderPath))
                Directory.CreateDirectory(saveFolderPath);

            StreamWriter writer =
               new StreamWriter(Path.Combine(saveFolderPath, fileName));

            writer.Write(text);

            writer.Close();

            HideSavePanel();
        }


        public TextAsset[] xmlFiles; // Inspector에서 할당할 XML 파일들

        protected virtual void LoadXml()
        {
            //TextAsset[] xmlFiles = Resources.LoadAll<TextAsset>(ResourcePath);
            for (int i = 0; i < xmlFiles.Length; i++)
            {
                string fileName = Path.GetFileNameWithoutExtension(xmlFiles[i].name);
                if (!string.IsNullOrEmpty(fileName))
                {
                    GameObject btnXml = GameObject.Instantiate(m_XmlBtnPrefab, m_ScrollContent, false);
                    btnXml.SetActive(true);
                    btnXml.GetComponentInChildren<Text>().text = fileName;
                    string tempFileName = fileName; // 클로저 문제 해결을 위해 임시 변수에 할당
                    //btnXml.GetComponent<Button>().onClick.AddListener(() => LoadXml());
                }
            }
            int index = MoveBlockCoding.countNum;
            Debug.Log(index);
            if (xmlFiles != null && index >= 0 && index < xmlFiles.Length)
            {
                StartCoroutine(AsyncLoadXml(xmlFiles[index]));
            }

        }

        IEnumerator AsyncLoadXml(TextAsset xmlData)
        {
            BlocklyUI.WorkspaceView.CleanViews();

            if (xmlData == null)
            {
                Debug.Log("파일을 찾을 수 없습니다.");
                yield break;
            }

            var dom = UBlockly.Xml.TextToDom(xmlData.text);

            UBlockly.Xml.DomToWorkspace(dom, BlocklyUI.WorkspaceView.Workspace);

            BlocklyUI.WorkspaceView.BuildViews();

            //HideLoadPanel();
        }

    }
}
