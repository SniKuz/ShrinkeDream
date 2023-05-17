using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Game;

public class DreamEvent : MonoBehaviour
{
    public GameObject btn;
    public GameObject monster;
    // Start is called before the first frame update
    void Start()
    {
        //GameManager.Instance.SceneController.LoadScene("LobbyScene");
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        //GameManager.Instance.ItemCount++;
        if(collision.gameObject.tag == "Player")
        {
            btn.SetActive(true);
        }
    }

    public void BtnClick()
    {
        monster.SetActive(true);
        gameObject.SetActive(false);
        btn.gameObject.SetActive(false);
    }
}
