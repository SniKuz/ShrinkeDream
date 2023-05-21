using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;
using Game;

//new inputsystem을 사용하여 구현
//코드 문제 플레이어 rigidbody가 다이내믹이 아닌 경우 떨림과 장애물 막힘 발생


public class MonsterAI : MonoBehaviour
{
    public Tilemap map;
    [SerializeField] private float movementSpeed;

    public Transform target;
    private Vector3 destination;
    private SpriteRenderer spriteRenderer;
    public float mainTime = 2f;
    public GameObject MainPrefab;

    private void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    void FixedUpdate()
    {
        destination = target.position;
        Vector3 currentPosition = transform.position;

        if (Vector3.Distance(transform.position, destination) > 1f)
        transform.position = Vector3.MoveTowards(transform.position, destination, movementSpeed * Time.deltaTime);

        if (destination.x > currentPosition.x)
        {
            spriteRenderer.flipX = true; // 왼쪽으로 이동하면 스프라이트 뒤집기
        }
        else if (destination.x < currentPosition.x)
        {
            spriteRenderer.flipX = false; // 오른쪽으로 이동하면 스프라이트 원래대로
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        //GameManager.Instance.ItemCount++;
        if (collision.gameObject.tag == "Player")
        {
            System.Console.WriteLine("충돌");
            //지금까지 먹은 아이템 초기화
            GameManager.Instance.ItemCount = 0;

            //mainroom씬으로 사출
            //GameManager.Instance.SceneController.LoadScene(3);

            MainChange();
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
    }

}
