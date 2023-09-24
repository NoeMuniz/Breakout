using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class paddle_movement : MonoBehaviour
{
    public float paddle_speed;
    Rigidbody2D rb;
    private Vector2 moveDir;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }
    
    // Update is called once per frame
    void Update()
    {
        //processing input
        ProcessInputs();
    }
    void FixedUpdate()
    {
        //physics calucations
        Move();
    }
    void ProcessInputs()
    {
        float moveX = Input.GetAxisRaw("Horizontal");

        moveDir = new Vector2(moveX, 0).normalized;
    }
    void Move()
    {
        rb.velocity = new Vector2(moveDir.x * paddle_speed, 0);
    }
}
