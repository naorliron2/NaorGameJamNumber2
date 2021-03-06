﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : BaseDamagable
{
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
}
