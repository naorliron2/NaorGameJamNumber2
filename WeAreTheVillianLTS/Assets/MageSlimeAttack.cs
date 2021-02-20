using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MageSlimeAttack : MonoBehaviour
{
    [SerializeField] Transform player;
    [SerializeField] SlimeSightChecker sightChecker;
    [SerializeField] float attackCoolDown;
    [SerializeField] GameObject prefab;
    [SerializeField] float projectileSpeed;
    [SerializeField] SpriteRenderer spriteRenderer;
    [SerializeField] float attackCoolDownTimer;

    [SerializeField] Transform wandSpot;
    [SerializeField] EnemyHealth health;

    private void Start()
    {
        player = FindObjectOfType<PlayerHealth>().transform;
        sightChecker = GetComponent<SlimeSightChecker>();
    }

    private void Update()
    {
        if (health.isDead) return;
        if (attackCoolDown > 0)
        {
            attackCoolDownTimer -= Time.deltaTime;
        }
        if (sightChecker.PlayerInSight)
        {
            if (attackCoolDownTimer <= 0)
            {
                GameObject instace = Instantiate(prefab, wandSpot.position, Quaternion.identity);
                Rigidbody2D instanceRB = instace.GetComponent<Rigidbody2D>();
                Vector3 dir = (player.position + new Vector3(0,0.5f,0)) - wandSpot.position;
                if (dir.x > 0)
                {
                    spriteRenderer.flipX = true;
                }
                else
                {
                    spriteRenderer.flipX = false;
                }
                instanceRB.AddForce(dir.normalized * projectileSpeed, ForceMode2D.Impulse);
                attackCoolDownTimer = attackCoolDown;

            }
        }
    }
}

