using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

//new inputsystem�� ����Ͽ� ����
//�ڵ� ���� �÷��̾� rigidbody�� ���̳����� �ƴ� ��� ������ ��ֹ� ���� �߻�


public class PlayerController : MonoBehaviour
{
    public Tilemap map;
    [SerializeField] private float movementSpeed;
    MouseInput mouseInput;

    private Vector3 destination;
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

    }

    private void MouseClick()
    {
        Vector2 mousePosition = mouseInput.Mouse.MousePosition.ReadValue<Vector2>();
        mousePosition = Camera.main.ScreenToWorldPoint(mousePosition);
        Vector3Int gridPosition = map.WorldToCell(mousePosition);
        if (map.HasTile(gridPosition))
        {
            destination = map.GetCellCenterWorld(gridPosition);
            //destination = mousePosition;
        }
    }

    void FixedUpdate()
    {
        if (Vector3.Distance(transform.position, destination) > 0.1f)
        transform.position = Vector3.MoveTowards(transform.position, destination, movementSpeed * Time.deltaTime);


        //if (Vector3.Distance(transform.position, destination) > 0.1f)
        //{
        //    Vector3 currentPosition = transform.position;
        //    Vector3 currentVelocity = destination;
        //    transform.position = Vector3.SmoothDamp(currentPosition, destination, ref currentVelocity, movementSpeed);
        //}
    }

}