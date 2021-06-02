using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Move2D : MonoBehaviour
{
    private Collider2D coll;
    public float moveSpeed = 2f;
    public bool isGrounded = false;
    public float FlyPower = 200f;
    public float jumpSpeed = 5;
    private Rigidbody2D rb;
    private Animator animator;
    private bool landed = true;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        coll = GetComponent<BoxCollider2D>();
        animator = GetComponent<Animator>();
        animator.Play("Pneutral");
            animator.Update(0f);
    }
    void FixedUpdate() 
    {
        bool jetpackActive = Input.GetButton("Fire2");

        if (jetpackActive && isGrounded){
            rb.AddForce(new Vector2(0, FlyPower));
        }
    }

    void Update()
    {
        
        rb = GetComponent<Rigidbody2D>();
        Vector2 move = rb.velocity;
        float hor = Input.GetAxis ("Horizontal");
        move.x = hor * moveSpeed;
        if (Input.GetButton("Jump") && isGrounded == true)
        {
            move.y = jumpSpeed;
            animator.Play("Jump");
            animator.Update(0f);

        }
        if(isGrounded){
            landed = true;
        }
        rb.velocity = move;
        Vector3 movement = new Vector3(Input.GetAxis("Horizontal"), 0f, 0f);
        transform.position += movement * Time.deltaTime * moveSpeed;
    }

    public void OnCollisionEnter2D(Collision2D collision){
        if(landed == true){
            animator.Play("Pneutral");
            animator.Update(0f);
        }
        if(collision.collider.tag == "DeathBlock"){
            SceneManager.LoadScene("Menu");
        }
        if(collision.collider.tag == "Finish"){
            Application.Quit();
        }
        if(collision.collider.tag == "Boost"){
            jumpSpeed = 10;
        }
        if(collision.collider.tag == "Ground"){
            jumpSpeed=5;
        }

    }
}