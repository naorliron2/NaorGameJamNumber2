using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class BaseDamagable : MonoBehaviour
{
    public int health = 100;
    public int maxHealth = 100;
    public virtual void TakeDamage(int amount)
    {
        Debug.Log("Take Damage");
        if (amount <= 0) return;
        health -= amount;
        if (health < 0)
            Die();
    }

    public virtual void Heal(int amount)
    {
        if (amount <= 0) return;
        health += amount;
        health = health > maxHealth ? maxHealth : health;

    }
    protected abstract void Die();
}
