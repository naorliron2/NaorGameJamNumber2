using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkillUser : MonoBehaviour
{
    
    UtillitySkill UtilitySkill;
    [SerializeField] AttackSkill AttackSkill;

    UtillitySkill[] UtilitySkills;
    [SerializeField] AttackSkill[] AttackSkills;


    void Start()
    {
        UtilitySkills = GetComponents<UtillitySkill>();
        AttackSkills = GetComponents<AttackSkill>();

        AttackSkill = AttackSkills[Random.Range(0, AttackSkills.Length)];
        UtilitySkill = UtilitySkills[Random.Range(0, UtilitySkills.Length)];

        Debug.Log(Random.Range(0, AttackSkills.Length));

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            AttackSkill.UseSkill();
        }
        if (Input.GetMouseButtonDown(1))
        {
            UtilitySkill.UseSkill();
        }
    }
}
