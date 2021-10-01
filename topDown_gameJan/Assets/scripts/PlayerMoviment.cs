﻿using System.Collections;
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
    [Space]
    public Animator bodyAnimator;
    public Animator headAnimator;
    public Animator handsAnimator;
    public Animator hairAnimator;
    public Animator armorAnimator;
    public Animator eyesAnimator;
    public Animator glassAnimator;
    public Animator hatAnimator;
    [Space]
    public SpriteRenderer spriteRD;

   

    void Update(){
        ProcessInputs();
        Move();
        Animate();
    }

    void ProcessInputs()
    {
        movimentDir = new Vector2(Input.GetAxis("Horizontal_" + this.gameObject.name), Input.GetAxis("Vertical_" + this.gameObject.name));
        moveSpeed = Mathf.Clamp(movimentDir.magnitude, 0.0f, 1.0f);
        movimentDir.Normalize();
    }

    void Move(){
        rb.velocity = movimentDir * moveSpeed * playerSpeed;
    }

    void Animate(){
        if(movimentDir != Vector2.zero){
            //spriteRD.flipX = (movimentDir.x > 0);
            bodyAnimator.SetFloat("Horizontal", movimentDir.x);
            bodyAnimator.SetFloat("Vertical", movimentDir.y);

            handsAnimator.SetFloat("Horizontal", movimentDir.x);
            handsAnimator.SetFloat("Vertical", movimentDir.y);

            hairAnimator.SetFloat("Horizontal", movimentDir.x);
            hairAnimator.SetFloat("Vertical", movimentDir.y);

            armorAnimator.SetFloat("Horizontal", movimentDir.x);
            armorAnimator.SetFloat("Vertical", movimentDir.y);

            eyesAnimator.SetFloat("Horizontal", movimentDir.x);
            eyesAnimator.SetFloat("Vertical", movimentDir.y);

            glassAnimator.SetFloat("Horizontal", movimentDir.x);
            glassAnimator.SetFloat("Vertical", movimentDir.y);

            hatAnimator.SetFloat("Horizontal", movimentDir.x);
            hatAnimator.SetFloat("Vertical", movimentDir.y);

            headAnimator.SetFloat("Horizontal", movimentDir.x);
            headAnimator.SetFloat("Vertical", movimentDir.y);
        }

        bodyAnimator.SetFloat("Speed", moveSpeed);
        hairAnimator.SetFloat("Speed", moveSpeed);
        armorAnimator.SetFloat("Speed", moveSpeed);
        eyesAnimator.SetFloat("Speed", moveSpeed);
        glassAnimator.SetFloat("Speed", moveSpeed);
        hatAnimator.SetFloat("Speed", moveSpeed);
        headAnimator.SetFloat("Speed", moveSpeed);
        handsAnimator.SetFloat("Speed", moveSpeed);

        changeSkin();
    }

    void changeSkin()
    {
        AnimatorOverrideController Armadura2 = Resources.Load("skin/armor/armor5") as AnimatorOverrideController;
        armorAnimator.runtimeAnimatorController = Armadura2;
    }
}
