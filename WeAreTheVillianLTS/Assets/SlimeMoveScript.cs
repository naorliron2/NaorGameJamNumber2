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
    int timesNotJumped;
    float tryMoveTimer;
    // Start is called before the first frame update
    void Start()
    {
        tryMoveTimer = tryMoveTime;
    }

    // Update is called once per frame
    void Update()
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
                rb.AddForce(((player.position - transform.position).normalized + Vector3.up) * Random.Range((int)minJumpForce, (int)maxJumpForce), ForceMode2D.Impulse);
            }
            else
            {
                timesNotJumped++;
            }
        }
    }
}
