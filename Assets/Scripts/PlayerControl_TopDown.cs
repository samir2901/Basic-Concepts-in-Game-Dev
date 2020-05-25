using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Script for player control in Enemy_Follow_Player Scene

public class PlayerControl_TopDown : MonoBehaviour
{
    public float speed;
    Rigidbody2D rb;    
    Vector2 movement;
    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }
    private void Update()
    {
        movement.x = Input.GetAxisRaw("Horizontal");
        movement.y = Input.GetAxisRaw("Vertical");
    }
    private void FixedUpdate()
    {
        rb.MovePosition(rb.position + movement * speed * Time.deltaTime);
    }

}
