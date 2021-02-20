using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class SkillChoser : MonoBehaviour
{
    [SerializeField] SkillUser skillChooserScript;
    [SerializeField] TextMeshProUGUI AttackSkillNameText;
    [SerializeField] TextMeshProUGUI UtilitySkillNameText;


    public void ChooseSkills()
    {
        skillChooserScript.ChooseSkills();

        AttackSkillNameText.text = skillChooserScript.AttackSkill.skillName;
        UtilitySkillNameText.text = skillChooserScript.UtilitySkill.skillName;

    }

}
