using System.Collections;
using System.Collections.Generic;
using UnityEngine;



/*
 Scripts for controlling the Player in a Platformer game.
     */
public class PlayerController : MonoBehaviour
{
    public float speed;
    public float jumpSpeed;
    private float moveInput;

    private Rigidbody2D rb;

    private bool facingRight = true;
    private bool isOnGround;
    public Transform groundCheck;
    public float checkRadius;
    public LayerMask whatisGround;

    public int extraJumpsValue;
    private int extraJumps;

    // Start is called before the first frame update
    void Start()
    {
        extraJumps = extraJumpsValue; //allows for double and even triple jumps
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        isOnGround = Physics2D.OverlapCircle(groundCheck.position, checkRadius, whatisGround);
        moveInput = Input.GetAxisRaw("Horizontal");
        rb.velocity = new Vector2(moveInput * speed, rb.velocity.y);
        if(facingRight == false && moveInput > 0)
        {
            flip();
        }
        else if(facingRight == true && moveInput < 0){
            flip();
        }
    }

    private void Update()
    {
        if (isOnGround)
        {
            extraJumps = extraJumpsValue;
        }
        if (Input.GetKeyDown(KeyCode.UpArrow)  && extraJumps > 0)
        {
            rb.velocity = Vector2.up * jumpSpeed;
            extraJumps--;
        }
        else if (Input.GetKeyDown(KeyCode.UpArrow) && extraJumps == 0 && isOnGround)
        {
            rb.velocity = Vector2.up * jumpSpeed;
        }
    }

    void flip()
    {
        facingRight = !facingRight;
        Vector3 scaler = transform.localScale;
        scaler.x *= -1;
        transform.localScale = scaler;
    }
}
