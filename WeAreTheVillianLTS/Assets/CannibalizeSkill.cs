using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CannibalizeSkill : UtillitySkill
{
    [SerializeField] int amountToMegaChomp;
    [SerializeField] float radius;
    [SerializeField] float range;
    [SerializeField] ContactFilter2D enemyMask;
    [SerializeField] PlayerHealth healthManager;
    [SerializeField] int amountToHeal;
    RaycastHit2D hit;
    [SerializeField] int megaChompDmg;
    [SerializeField] float enragedTime=5;
    [SerializeField] float enragedTimer=0;
    [SerializeField] float enragedBiteCooldown = 0.5f;
    [SerializeField] float enragedBiteCooldownTimer=0;
    int amountToMegaChompCounter;
    [SerializeField] bool enraged=false;


    private void Start()
    {
        healthManager = GetComponent<PlayerHealth>();
    }

    public override void UseSkill()
    {
        if (coolDownCounter > 0 && !enraged) return;
        coolDownCounter = CoolDown;
        //eating corpses
        if (amountToMegaChompCounter < amountToMegaChomp || (enraged &&enragedBiteCooldownTimer<=0)) //THIS IS SO UGLY
        {
            enragedBiteCooldownTimer = enragedBiteCooldown;

            hit = Physics2D.CircleCast(transform.position, radius, Movement.PlayerIsFlipped ? transform.right : -transform.right, range, enemyMask.layerMask);
            if (hit.collider != null)
            {


                if (hit.collider.gameObject.GetComponent<BaseDamagable>().isDead)
                {
                    Destroy(hit.collider.gameObject);
                    amountToMegaChompCounter++;
                    healthManager.Heal(amountToHeal);
                }
            }
        }
        else //become enraged
        {
            Debug.Log("ENRAGED");
            StartCoroutine(Enrage());
        }

        hit = Physics2D.CircleCast(transform.position, radius, transform.right, range, enemyMask.layerMask);
        if (hit.collider != null)
        {

            hit.collider.gameObject.GetComponent<BaseDamagable>().TakeDamage(megaChompDmg);
            healthManager.Heal(amountToHeal);
        }
    }

    IEnumerator Enrage()
    {
        enraged = true;
        enragedTimer = enragedTime;
        enragedBiteCooldownTimer = enragedBiteCooldown;
        while (enragedTimer > 0)
        {
            
            enragedTimer -= Time.deltaTime;
            enragedBiteCooldownTimer -= Time.deltaTime;

            yield return null;
        }

        amountToMegaChompCounter = 0;
        enraged = false;
    }

}
