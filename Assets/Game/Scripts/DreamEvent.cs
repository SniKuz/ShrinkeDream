using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Game;
using UnityEngine.SceneManagement;

public class DreamEvent : MonoBehaviour
{
    public GameObject chart;
    public GameObject monster;


    private void OnTriggerEnter2D(Collider2D collision)
    {
        GameManager.Instance.ItemCount++;
        if (collision.gameObject.tag == "Player" && SceneManager.GetActiveScene().name == "Dream")
            chart.SetActive(true);
        gameObject.SetActive(false);
    }

    public void BtnClick()
    {
        if (SceneManager.GetActiveScene().name == "Dream2")
            monster.SetActive(true);
        chart.gameObject.SetActive(false);
    }
}
