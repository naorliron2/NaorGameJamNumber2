using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class HUD : MonoBehaviour
{
    [SerializeField] PlayerHealth health;
    [SerializeField] SkillUser skills;


    [SerializeField] Image healthBar;
    [SerializeField] Image SkillAttack;
    [SerializeField] Image SkillUtil;


    // Update is called once per frame
    void Update()
    {
        SkillAttack.fillAmount = 1 - (Mathf.InverseLerp(0, skills.AttackSkill.CoolDown, skills.AttackSkill.coolDownCounter));
        SkillUtil.fillAmount = 1 - (Mathf.InverseLerp(0, skills.UtilitySkill.CoolDown, skills.UtilitySkill.coolDownCounter));
        healthBar.fillAmount = Mathf.InverseLerp(0, health.maxHealth, health.health);
    }
}
