﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    Rigidbody2D rb;

    [SerializeField] LayerMask groundCheckMask;
    [SerializeField] SpriteRenderer _sprite;
    [SerializeField] Animator _animator;
    [SerializeField] float walkSpeed;
    [SerializeField] float runSpeed;
    [SerializeField] float jumpForce;
    [SerializeField] float gravity;

    Vector2 velocity;
    bool grounded = true;
    bool pointsRight = false;

    InputData currentFrameInputs;


    struct InputData
    {
        public Vector2 inputDir;
        public bool space;
        public bool shift;

    }

    InputData GetInputs()
    {
        InputData inputs;
        inputs.inputDir = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));
        inputs.space = Input.GetButtonDown("Jump");
        inputs.shift = Input.GetKeyDown(KeyCode.LeftShift);

        return inputs;
    }

    void GetComponentReferences()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Start is called before the first frame update
    void Start()
    {
        GetComponentReferences();
    }

    // Update is called once per frame

    public void ResetVelocity()
    {
        velocity = Vector3.zero;
    }
    void Update()
    {
        CheckGrounded();

        currentFrameInputs = GetInputs();

        float speed = currentFrameInputs.shift ? runSpeed : walkSpeed;
        speed *= currentFrameInputs.inputDir.x;
        velocity.x = speed;


        velocity.y = (currentFrameInputs.space && grounded) ? jumpForce : velocity.y;

        velocity.y += gravity * Time.deltaTime;

        rb.velocity = velocity;

        HandleAnimations();
        HandleFlip();
    }

    private void CheckGrounded()
    {
        RaycastHit2D hit;
        if (hit = Physics2D.Raycast(transform.position, -Vector2.up, 0.1f, groundCheckMask))
        {
            grounded = true;           
        }
        else
        {
             grounded = false;
        }
    }

    private void HandleAnimations()
    {
        if (grounded == false)
        {
            _animator.SetBool("Jump", true);
            _animator.SetBool("Walk", false);
        }
        else if (velocity.x > 0.1f || velocity.x < -0.1f)
        {
            _animator.SetBool("Jump", false);
            _animator.SetBool("Walk", true);
        }
        else
        {
            _animator.SetBool("Jump", false);
            _animator.SetBool("Walk", false);
        }
    }

    private void HandleFlip()
    {
        if (currentFrameInputs.inputDir.x > 0)
        {
            pointsRight = true;
        }
        else if (currentFrameInputs.inputDir.x < 0)
        {
            pointsRight = false;
        }
        _sprite.flipX = pointsRight;

    }
}
