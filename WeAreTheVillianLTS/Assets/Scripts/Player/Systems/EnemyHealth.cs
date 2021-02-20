using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : BaseDamagable
{
    [SerializeField] GameObject aliveRenderer;
    [SerializeField] GameObject deadRenderer;
    protected override void Die()
    {
        isDead = true;
    }
    public override void TakeDamage(int amount)
    {

        if (amount <= 0) return;
        health -= amount;
        if (health <= 0)
            Die();
    }
    public override void Heal(int amount)
    {
        base.Heal(amount);
    }
    private void Update()
    {
        if (isDead)
        {
            deadRenderer.SetActive(true);
            aliveRenderer.SetActive(false);
        }
    }
}
