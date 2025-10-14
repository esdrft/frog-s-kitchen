using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class player_control : MonoBehaviour
{
    public float speed;
    private float moveInput;

    private Animator anim;
    private Rigidbody2D rb;
    private bool facingUp = true;
 

    private void Start ()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();

    }


    private void FixedUpdate()
    {
        moveInput = Input.GetAxis("Horizontal");
        rb.velocity = new Vector3(moveInput * speed, moveInput * speed);
        if (facingUp == false && moveInput > 0)
        {
            Flip();
        }
        else if (facingUp == true && moveInput < 0)
        {
            Flip();
        }
    }

    void Flip()
    {
        facingUp = !facingUp;
        Vector3 Scaler = transform.localScale;
        Scaler.y *= -1;
        transform.localScale = Scaler;

    }
}
