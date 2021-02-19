using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class BaseSkill : MonoBehaviour
{
    public SkillSettings settings;

    [SerializeField]protected float coolDownCounter = 0;
    public virtual void UseSkill()
    {
        if (coolDownCounter > 0) return;
        coolDownCounter = settings.CoolDown;
    }
    private void Update()
    {

        coolDownCounter -= Time.deltaTime;

    }
}
