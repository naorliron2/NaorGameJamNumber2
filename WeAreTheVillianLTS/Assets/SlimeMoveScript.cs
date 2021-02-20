using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlimeMoveScript : MonoBehaviour
{
    [SerializeField] Transform player;
    [SerializeField] Rigidbody2D rb;
    [SerializeField] float tryMoveTime;
    [SerializeField] int tryMoveChance;
    [SerializeField] float minJumpForce;
    [SerializeField] float maxJumpForce;
    [SerializeField] int maxMissedIntervals;
    [SerializeField] BaseDamagable myDamagable;
    [SerializeField] SpriteRenderer myRenderer;
    [SerializeField] LayerMask groundCheckMask;
    [SerializeField] SlimeSightChecker sightChecker;
    int timesNotJumped;
    float tryMoveTimer;
    bool grounded;
    // Start is called before the first frame update
    void Start()
    {
        tryMoveTimer = tryMoveTime;
        sightChecker = GetComponent<SlimeSightChecker>();
        myDamagable = GetComponent<BaseDamagable>();
        myRenderer = GetComponentInChildren<SpriteRenderer>();
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
    // Update is called once per frame
    void Update()
    {
        CheckGrounded();
        Debug.Log(sightChecker.PlayerInSight);
        if (!myDamagable.isDead && grounded && sightChecker.PlayerInSight)
        {
            if (tryMoveTimer > 0)
            {
                tryMoveTimer -= Time.deltaTime;
            }
            if (tryMoveTimer <= 0)
            {
                tryMoveTimer = tryMoveTime;
                int rand = Random.Range(0, 100);
                if (rand > tryMoveChance || timesNotJumped > maxMissedIntervals)
                {
                    Vector3 dir = (player.position - transform.position).normalized;


                    myRenderer.flipX = dir.x > 0;

                    rb.AddForce((dir + Vector3.up) * Random.Range((int)minJumpForce, (int)maxJumpForce), ForceMode2D.Impulse);
                }
                else
                {
                    timesNotJumped++;
                }
            }
        }
    }
}
