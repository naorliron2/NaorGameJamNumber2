using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BombSkill : AttackSkill
{
    [SerializeField] GameObject bombPrefab;
    [SerializeField] float throwForce = 8f;
    [SerializeField] float throwTorque = 5f;
    [SerializeField] int damage;
    public override void UseSkill()
    {
        if (coolDownCounter > 0) return;
        coolDownCounter = CoolDown;
        GameObject instance = Instantiate(bombPrefab, transform.position + new Vector3(0,0.5f,0), Quaternion.identity);
        Rigidbody2D instanceRB = instance.GetComponent<Rigidbody2D>();
        Explosion explodeScipt = instance.GetComponent<Explosion>();

        explodeScipt.damage = damage;

        Vector3 mouseWorldpos = Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, -Camera.main.transform.position.z));
        Vector2 throwDirection = (mouseWorldpos - transform.position).normalized;

        instanceRB.AddForce(throwDirection * throwForce, ForceMode2D.Impulse);
        instanceRB.AddTorque(throwDirection.x * throwTorque,ForceMode2D.Impulse);

        Debug.DrawRay(transform.position, (mouseWorldpos.normalized - transform.position) * throwForce, Color.red, 5);
    }

}
