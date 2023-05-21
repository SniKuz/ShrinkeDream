using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Game;
using UnityEngine.SceneManagement;

public class DreamEvent : MonoBehaviour
{
    public GameObject btn;
    public GameObject monster;


    private void OnTriggerEnter2D(Collider2D collision)
    {
        GameManager.Instance.ItemCount++;

        if (SceneManager.GetActiveScene().name == "Dream")
            gameObject.SetActive(false);

        if (SceneManager.GetActiveScene().name == "Dream2")
        {
            if (collision.gameObject.tag == "Player")
            {
                btn.SetActive(true);
            }
        }
    }

    public void BtnClick()
    {
        monster.SetActive(true);
        gameObject.SetActive(false);
        btn.gameObject.SetActive(false);
    }
}
