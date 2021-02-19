using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class CharacterCreator : MonoBehaviour
{
    [SerializeField] SkillUser skillUserScript;
    [SerializeField] TextMeshProUGUI attackSkillName;
    [SerializeField] TextMeshProUGUI utilitySkillName;


    public void UpdateText()
    {
        attackSkillName.text = skillUserScript.AttackSkill.settings.skillName;
        attackSkillName.text = skillUserScript.AttackSkill.settings.skillName;
        utilitySkillName.text = skillUserScript.UtilitySkill.settings.skillName;
    }
}
