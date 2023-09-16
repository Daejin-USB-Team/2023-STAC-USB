using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class tutorial : MonoBehaviour
{
    public GameObject[] ttPanel;
    public int numPanel = 0;

    private int count;
    void Awake()
    {
        count = MoveBlockCoding.countNum;
        if (count == 0)
        {
            for (int i = 0; i < ttPanel.Length; i++)
                ttPanel[i].SetActive(false);
            ttPanel[0].SetActive(true);
        }

    }
    void Update()
    {
        if(count == 0)
        {
            if (Input.GetMouseButtonDown(0))
            {
                ttPanel[numPanel].SetActive(false);
                numPanel++;
                ttPanel[numPanel].SetActive(true);
            }
        }
    }
}
