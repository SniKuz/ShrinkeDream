using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;
using Game;

//new inputsystem�� ����Ͽ� ����
//�ڵ� ���� �÷��̾� rigidbody�� ���̳����� �ƴ� ��� ������ ��ֹ� ���� �߻�


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
            spriteRenderer.flipX = true; // �������� �̵��ϸ� ��������Ʈ ������
        }
        else if (destination.x < currentPosition.x)
        {
            spriteRenderer.flipX = false; // ���������� �̵��ϸ� ��������Ʈ �������
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        //GameManager.Instance.ItemCount++;
        if (collision.gameObject.tag == "Player")
        {
            System.Console.WriteLine("�浹");
            //���ݱ��� ���� ������ �ʱ�ȭ
            GameManager.Instance.ItemCount = 100;

            //mainroom������ ����
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

        //itemcount�� ���� ���� �̻��̸� MainRoom�� �ؽ�Ʈ �߰�
    }

}
