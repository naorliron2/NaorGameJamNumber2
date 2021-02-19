using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : BaseDamagable
{
    protected override void Die()
    {
        throw new System.NotImplementedException();
    }
    public override void TakeDamage(int amount)
    {
        Debug.Log("Take Damage");
        if (amount <= 0) return;
        health -= amount;
        if (health <= 0)
            Die();
    }
    public override void Heal(int amount)
    {
        base.Heal(amount);
    }
}
