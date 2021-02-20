using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaserEyesSkill : AttackSkill
{
    [SerializeField] LayerMask enemyLayer;
    [SerializeField] float laserRange;
    [SerializeField] int laserDmg;
    RaycastHit2D hit;
    public override void UseSkill()
    {
        if (coolDownCounter > 0) return;
        coolDownCounter = settings.CoolDown;
        Debug.DrawRay(transform.position, transform.right*laserRange, Color.red, 1f);

        hit = Physics2D.Raycast(transform.position, transform.right, laserRange, enemyLayer);
        if (hit.collider != null)
        {
            hit.collider.GetComponent<BaseDamagable>().TakeDamage(laserDmg);
        }
    }
}
