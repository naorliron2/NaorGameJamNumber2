using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Movement))]
public class BasicAttack : MonoBehaviour
{
    [SerializeField] float radius;
    [SerializeField] float range;
    [SerializeField] LayerMask enemyMask;
    [SerializeField] RaycastHit2D hit;
    [SerializeField] int damage;
    [SerializeField] float delayToHit;
    Movement movement;

    [SerializeField] float cooldownTime;
    [SerializeField] float cooldownTimer;
    
    // Start is called before the first frame update
    void Start()
    {
        movement = GetComponent<Movement>();
        cooldownTimer = cooldownTime;
       
    }

    // Update is called once per frame
    void Update()
    {
        if (cooldownTimer <= 0)
        {
            if (Input.GetMouseButtonDown(0))
            {

                movement.attacking = true; //OMG AVISHAI WHY
                movement.Dash(1f, 0.3f);
                StartCoroutine(Attack());
               
            }
        }
        else
        {
            cooldownTimer -= Time.deltaTime;
        }
       
    }
    IEnumerator Attack()
    {
        yield return new WaitForSeconds(delayToHit);
        hit = Physics2D.CircleCast(transform.position, radius, Movement.PlayerIsFlipped ? transform.right : -transform.right, range, enemyMask);
        if (hit.transform && hit.transform.CompareTag("Enemy"))
        {
            hit.transform.GetComponent<BaseDamagable>().TakeDamage(damage);
        }
        cooldownTimer = cooldownTime;
    }
}
