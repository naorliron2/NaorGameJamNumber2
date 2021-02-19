using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    Rigidbody2D rb;
    [SerializeField] float walkSpeed;
    [SerializeField] float runSpeed;
    [SerializeField] float jumpForce;
    [SerializeField] float gravity;

    Vector2 velocity;
    bool grounded=false;

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
    void Update()
    {
        currentFrameInputs = GetInputs();

        float speed = currentFrameInputs.shift ? runSpeed : walkSpeed;
        speed *= currentFrameInputs.inputDir.x;
        velocity.x = speed;


        velocity.y = (currentFrameInputs.space && grounded) ? jumpForce : velocity.y;

        velocity.y += gravity * Time.deltaTime;

        rb.velocity = velocity;
        
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        grounded = true;
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        grounded = false;
    }
}
