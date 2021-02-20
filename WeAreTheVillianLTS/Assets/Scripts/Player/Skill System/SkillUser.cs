using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkillUser : MonoBehaviour
{

    public UtillitySkill UtilitySkill;
    public AttackSkill AttackSkill;

    UtillitySkill[] UtilitySkills;
     AttackSkill[] AttackSkills;


    void Start()
    {
        UtilitySkills = GetComponents<UtillitySkill>();
        AttackSkills = GetComponents<AttackSkill>();

        ChooseSkills();

    }

    public void ChooseSkills()
    {
        AttackSkill = AttackSkills[Random.Range(0, AttackSkills.Length)];
        UtilitySkill = UtilitySkills[Random.Range(0, UtilitySkills.Length)];
    }

    // Update is called once per frame
    void Update()
    {
        if (!Playbutton.GameStarted) { return; }
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
