using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private Rigidbody2D rb; 
    public bool isJumping;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }
    // Update is called once per frame
    void Update()
    {
        float dirX = Input.GetAxis("Horizontal");
        rb.velocity = new Vector2(dirX * 7f, rb.velocity.y);

        if(Input.GetButtonDown("Jump") && isJumping == false)
        {
            rb.velocity = new Vector2(rb.velocity.x, 16f);
        }
    }

    private void OnCollisionEnter2D (Collision2D other)
    {
        if(other.gameObject.CompareTag("Floor"))
        {
            isJumping = false;
        }
    }

        private void OnCollisionExit2D (Collision2D other)
    {
        if(other.gameObject.CompareTag("Floor"))
        {
            isJumping = true;
        }
    }
}
