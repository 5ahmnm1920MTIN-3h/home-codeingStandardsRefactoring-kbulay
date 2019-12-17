﻿using UnityEngine;

public class PlayerController : MonoBehaviour
{
    Rigidbody2D rididbodySanta;
    Animator animator;
    bool isGrounded;
    bool isGameOver = false;
    [SerializeField] float jumpForce;

    private void Awake()
    {
        rididbodySanta = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
    }

    // Start is called before the first frame update
    void Start()
    { 
    }
    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButton(0) && !isGameOver)
        {
            if (isGrounded == true)
            {
                jump();
            }
        }
    }
    void jump()
    {
        isGrounded = false;
        rigidbodySanta.velocity = Vector2.up * jumpForce;
        animator.SetTrigger("Jump");
        GameManager.instance.IncrementScore();
        Debug.Log("DeleteMe");
    }

    private bool SetGameOverTrue()
    {
        return true;
    }

    private void OnCollisionEnter2D(Collision2D collision)   {
        if(collision.gameObject.tag == "Ground")
        {
            isGrounded = true;}
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Obstacle"){
            GameManager.instance.GameOver();
            Destroy(collision.gameObject);
            animator.Play("SantaDeath");
            isGameOver = SetGameOverTrue();
        }
    }




}
