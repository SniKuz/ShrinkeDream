using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

//new inputsystem을 사용하여 구현
//코드 문제 플레이어 rigidbody가 다이내믹이 아닌 경우 떨림과 장애물 막힘 발생


public class MonsterAI : MonoBehaviour
{
    public Tilemap map;
    [SerializeField] private float movementSpeed;

    public Transform target;
    private Vector3 destination;

    void FixedUpdate()
    {
        destination = target.position;
        if (Vector3.Distance(transform.position, destination) > 1f)
        transform.position = Vector3.MoveTowards(transform.position, destination, movementSpeed * Time.deltaTime);
    }

}
