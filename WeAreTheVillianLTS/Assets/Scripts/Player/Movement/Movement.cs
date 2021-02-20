using System.Collections;
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
    [SerializeField] bool grounded = true;
    [SerializeField] public bool attacking = false;
    bool pointsRight = false;

    InputData currentFrameInputs;

    public static bool PlayerIsFlipped;
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
        inputs.shift = Input.GetKey(KeyCode.LeftShift);

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


        currentFrameInputs = GetInputs();

        CheckGrounded();

        float speed = currentFrameInputs.shift ? runSpeed : walkSpeed;
        speed *= currentFrameInputs.inputDir.x;
        velocity.x = speed;

        if (grounded)
        {

            if (currentFrameInputs.space)
            {
                velocity.y = jumpForce;
            }
            else
            {
                if (velocity.y <= 0)
                    velocity.y = 0;
            }
        }
        else
        {
            velocity.y += gravity * Time.deltaTime;
        }






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

    public void Dash(float dashDistance,float dashTime)
    {
        Vector2 dashVector = currentFrameInputs.inputDir.x* dashDistance * Vector2.right;
        StartCoroutine(DashCorutine(dashVector, dashTime));
    }

    IEnumerator DashCorutine(Vector2 dashVector, float dashTime)
    {
        float timer = dashTime;
        Vector2 smoothDampVelocity = Vector2.zero;
        Vector2 destination = rb.position + dashVector;
        while (timer>=0)
        {
            ResetVelocity(); //??? THIS IS SO UGLY AND BUGGY ???
            rb.position = Vector2.SmoothDamp(rb.position, destination, ref smoothDampVelocity, dashTime);
            timer -= Time.deltaTime;
            yield return null;
        }
    }

    private void HandleAnimations()
    {
        _animator.SetBool("Jump", false);
        _animator.SetBool("Walk", false);

        if (attacking == true)
        {
            //TODO: MAKE SURE THE TRIGGER HAPPENS ONLY ONCE PER ATTACK
            //DASH FROWARD ONLY HAPPENS AFTER THE WINDUP FRAMES
            _animator.SetTrigger("Attack");
            attacking = false;
        }
        else
        {
            if (grounded == false)
            {
                _animator.SetBool("Jump", true);
            }
            else if (velocity.x > 0.1f || velocity.x < -0.1f)
            {
                _animator.SetBool("Walk", true);
            }
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
        PlayerIsFlipped = _sprite.flipX;

    }
}
