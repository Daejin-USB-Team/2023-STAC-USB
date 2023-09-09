using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class Buff : MonoBehaviour
{
    public TextMeshProUGUI text;

    void Start()
    {
        OutputScript.outputText = text;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
