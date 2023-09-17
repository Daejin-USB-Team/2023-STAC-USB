using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HpManager : MonoBehaviour
{
    public static int health = 5;
    public Image[] hearts;
    public Sprite fullHp;
    public Sprite emptyHp;

    void Update()
    {
        foreach (Image img in hearts)
        {
            img.sprite = emptyHp;
        }
        for (int i = 0; i < health; i++)
        {
            hearts[i].sprite = fullHp;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.transform.tag == "Enemy")
        {
            gameObject.SetActive(false);
        }

    }
}