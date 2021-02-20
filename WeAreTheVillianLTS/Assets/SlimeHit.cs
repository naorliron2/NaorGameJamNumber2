using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlimeHit : MonoBehaviour
{
    [SerializeField] float hitCd;
    float hitCDTimer;
    [SerializeField] int dmgAmount;
    // Start is called before the first frame update
    private void Update()
    {
        if (hitCDTimer > 0)
        {
            hitCDTimer -= Time.deltaTime;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.CompareTag("Player") &&hitCDTimer<=0)
        {
            BaseDamagable toDmg = collision.gameObject.GetComponent<BaseDamagable>();
            toDmg.TakeDamage(dmgAmount);
            hitCDTimer = hitCd;
        }
    }
}
