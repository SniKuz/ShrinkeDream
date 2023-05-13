using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    public float moveSpeed;

    private Rigidbody2D rb;
    private Vector2 vector2;
    private float speed;
    private SpriteRenderer spriteRenderer;


    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    void Update()
    {
        vector2.x = Input.GetAxisRaw("Horizontal");
        vector2.y = Input.GetAxisRaw("Vertical");
        //transform.Translate(new Vector2(InputX, InputY) * Time.deltaTime * moveSpeed) ;
        rb.velocity = vector2.normalized * moveSpeed;
        if (vector2.x < 0)
        {
            spriteRenderer.flipX = false;
        }
        else if (vector2.x > 0)
        {
            spriteRenderer.flipX = true;
        }


    }

    private void OnTriggerEnter(Collider other)
    {
        moveSpeed = 0;
    }
}
