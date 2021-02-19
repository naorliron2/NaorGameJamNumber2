using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkillUser : MonoBehaviour
{
    // Start is called before the first frame update
    public UtillitySkill UtilitySkill;
    public AttackSkill AttackSkill;

    UtillitySkill[] UtilitySkills;
    AttackSkill[] AttackSkills;


    void Start()
    {
        UtilitySkills = GetComponents<UtillitySkill>();
        AttackSkills = GetComponents<AttackSkill>();
        Debug.Log(Random.Range(0, AttackSkills.Length));

    }

    public void ChooseSkills()
    {
        AttackSkill = AttackSkills[Random.Range(0, AttackSkills.Length)];
        UtilitySkill = UtilitySkills[Random.Range(0, UtilitySkills.Length)];
    }

    // Update is called once per frame
    void Update()
    {

        if (Input.GetMouseButtonDown(0))
        {
            if (AttackSkill != null)
                AttackSkill.UseSkill();
        }
        if (Input.GetMouseButtonDown(2))
        {
            if (UtilitySkill != null)
                UtilitySkill.UseSkill();
        }
    }
}
