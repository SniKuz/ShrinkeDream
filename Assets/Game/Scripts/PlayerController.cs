using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;
using UnityEngine.EventSystems;

//new inputsystem�� ����Ͽ� ����
//�ڵ� ���� �÷��̾� rigidbody�� ���̳����� �ƴ� ��� ������ ��ֹ� ���� �߻�


public class PlayerController : MonoBehaviour
{
    public Animator Animator;
    [Header("Tile")]
    public Tilemap map;
    [SerializeField] private float movementSpeed;
    MouseInput mouseInput;

    private Camera mainCamera;

    private Vector3 destination;
    private bool isMove = false;



    private void Awake()
    {
        mouseInput = new MouseInput();
    }

    private void OnEnable()
    {
        mouseInput.Enable();
    }

    private void OnDisable()
    {
        mouseInput.Disable();
    }
    void Start()
    {
        destination = transform.position;
        mouseInput.Mouse.MouseClick.performed += _ => MouseClick();
        mainCamera = Camera.main;
    }

    private void MouseClick()
    {
        // UI ���� ������ ���� (����, �ٸ� ��������Ʈ ������Ʈ���� ����)
        //if (EventSystem.current.IsPointerOverGameObject()) return;

        if (Input.GetMouseButtonDown(0))
        {
            Vector2 mp = mainCamera.ScreenToWorldPoint(Input.mousePosition);
            RaycastHit2D hit = Physics2D.Raycast(mp, Vector2.zero);

            if (hit)
            {
                GameObject hitObject = hit.collider.gameObject;

                // ������Ʈ�� ��ȣ�ۿ��ϴ� ������ �ۼ��մϴ�.
                Debug.Log("Clicked object: " + hitObject.name);

                if (hit.transform.CompareTag("Trigger"))
                {
                    isMove = true;
                } else
                {
                    isMove = false;
                }
            } else
            {
                isMove = true;
            }
        }

        if (isMove) {
            Vector2 mousePosition = mouseInput.Mouse.MousePosition.ReadValue<Vector2>();
            mousePosition = Camera.main.ScreenToWorldPoint(mousePosition);
            Vector3Int gridPosition = map.WorldToCell(mousePosition);
            if (map.HasTile(gridPosition))
            {
                destination = map.GetCellCenterWorld(gridPosition);
                //destination = mousePosition;
            } 
        }
    }

    void FixedUpdate()
    {
        float distance = Vector3.Distance(transform.position, destination);
        Animator.SetFloat("distance", distance);
        if (distance > 0.1f)
            transform.position = Vector3.MoveTowards(transform.position, destination, movementSpeed * Time.deltaTime);

        if (destination.x > transform.position.x)
        {
            // ���� ��������Ʈ�� �����Ͽ��� x�ุ ����
            transform.localScale = new Vector3(-Mathf.Abs(transform.localScale.x), transform.localScale.y, transform.localScale.z);
        }
        else if (destination.x < transform.position.x)
        {
            // ���� ��������Ʈ�� �������� �״�� ����
            transform.localScale = new Vector3(Mathf.Abs(transform.localScale.x), transform.localScale.y, transform.localScale.z);
        }

        //if (Vector3.Distance(transform.position, destination) > 0.1f)
        //{
        //    Vector3 currentPosition = transform.position;
        //    Vector3 currentVelocity = destination;
        //    transform.position = Vector3.SmoothDamp(currentPosition, destination, ref currentVelocity, movementSpeed);
        //}
    }

}