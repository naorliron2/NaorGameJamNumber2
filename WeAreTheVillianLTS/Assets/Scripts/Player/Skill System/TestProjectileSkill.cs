using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestProjectileSkill : AttackSkill
{
    [SerializeField] GameObject prefab;
    [SerializeField] float force;
    public override void UseSkill()
    {
        base.UseSkill();
        GameObject instance = Instantiate(prefab, transform.position, Quaternion.LookRotation(Input.mousePosition - transform.position));
        Rigidbody2D instanceRB = instance.GetComponent<Rigidbody2D>();
        instanceRB.AddForce(transform.forward * force);
    }

}
