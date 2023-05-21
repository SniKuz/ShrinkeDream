using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Game;
using UnityEngine.SceneManagement;

public class Exit : MonoBehaviour
{
    public float mainTime = 2f;
    public GameObject MainPrefab;
    public GameObject player;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            //퍼즐, 아이템 두개 먹고 탈출
            if (SceneManager.GetActiveScene().name == "Dream")
            {
                if (GameManager.Instance.ItemCount >= 2)
                {
                    GameManager.Instance.CurruntDay++;
                    GameManager.Instance.ItemCount = 0;
                    MainChange();
                }
            }
            //추격, 아이템 하나만 먹고 탈출
            if (SceneManager.GetActiveScene().name == "Dream2")
            {
                if (GameManager.Instance.ItemCount > 0)
                {
                    player.SetActive(false); // 플레이어와 몬스터 충돌 방지
                    Debug.Log("귀환");
                    GameManager.Instance.CurruntDay++;
                    GameManager.Instance.ItemCount = 0;
                    MainChange();
                }
            }

        }
    }

    public void MainChange()
    {
        if (MainPrefab == null) return;

        Instantiate(MainPrefab);
        mainTime = 2f;
        StartCoroutine(IEMainChange());
    }

    IEnumerator IEMainChange()
    {
        yield return new WaitForSeconds(mainTime);
        GameManager.Instance.SceneController.LoadScene("MainRoom");

        //itemcount가 일정 개수 이상이면 MainRoom에 텍스트 추가
    }
}
