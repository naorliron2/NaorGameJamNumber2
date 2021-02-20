using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BombSkill : AttackSkill
{
    [SerializeField] GameObject bombPrefab;
    [SerializeField] float throwForce;
    [SerializeField] int damage;
    public override void UseSkill()
    {
        if (coolDownCounter > 0) return;
        coolDownCounter = settings.CoolDown;
        GameObject instance = Instantiate(bombPrefab, transform.position + new Vector3(0,0.5f,0), Quaternion.identity);
        Rigidbody2D instanceRB = instance.GetComponent<Rigidbody2D>();
        Explosion explodeScipt = instance.GetComponent<Explosion>();
        explodeScipt.damage = damage;
        Vector3 mouseWorldpos = Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, -Camera.main.transform.position.z));
        instanceRB.AddForce((mouseWorldpos - transform.position).normalized * throwForce, ForceMode2D.Impulse);
        Debug.DrawRay(transform.position, (mouseWorldpos.normalized - transform.position) * throwForce, Color.red, 5);
    }

}
