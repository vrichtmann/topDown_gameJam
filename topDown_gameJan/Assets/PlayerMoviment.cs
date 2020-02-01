using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMoviment : MonoBehaviour
{
    [Header("Input settigs:")]
    public float moveSpeed = 0.5f;

    [Space]
    [Header("Character Atributes")]
    public float playerSpeed = 20;

    [Space]
    [Header("Character Statistics:")]   
    Vector2 movimentDir;

    [Space]
    [Header("References")]
    public Rigidbody2D rb;
    public Animator animator;
    public SpriteRenderer spriteRD;

    void Update(){
        ProcessInputs();
        Move();
        Animate();
    }


    void ProcessInputs()
    {
        Debug.Log("this.gameObject.name : " + this.gameObject.name);
        movimentDir = new Vector2(Input.GetAxis("Horizontal_" + this.gameObject.name), Input.GetAxis("Vertical_" + this.gameObject.name));
        moveSpeed = Mathf.Clamp(movimentDir.magnitude, 0.0f, 1.0f);
        movimentDir.Normalize();
    }

    void Move(){
        rb.velocity = movimentDir * moveSpeed * playerSpeed;
    }

    void Animate(){
        if(movimentDir != Vector2.zero){
            spriteRD.flipX = (movimentDir.x < 0);
            animator.SetFloat("Horizontal", movimentDir.x);
            animator.SetFloat("Vertical", movimentDir.y);
        }
       
        animator.SetFloat("Speed", moveSpeed);
    }
}
