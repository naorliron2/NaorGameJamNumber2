using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class BaseSkill : MonoBehaviour
{
    public SkillSettings settings;

    float coolDownCounter;
    public virtual void UseSkill()
    {
        if (coolDownCounter <= 0)
        {
            Debug.Log("Skill On CoolDown!");
            coolDownCounter = settings.CoolDown;
        }
    }
    private void Update()
    {
        if (coolDownCounter > 0)
        {
            coolDownCounter -= Time.deltaTime;
        }
    }
}
