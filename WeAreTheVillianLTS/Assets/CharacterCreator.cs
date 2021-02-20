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
        attackSkillName.text = skillUserScript.AttackSkill.skillName;
        utilitySkillName.text = skillUserScript.UtilitySkill.skillName;
    }
}
