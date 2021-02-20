using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaserEyesSkill : AttackSkill
{
    [SerializeField] LayerMask enemyLayer;
    [SerializeField] float laserRange;
    [SerializeField] int laserDmg;
    [SerializeField] Transform eyesPos;
    [SerializeField] LineRenderer lineRenderer;

    [SerializeField] float laserStayontime;
    float laserStayontimer;

    RaycastHit2D hit;
    private void Start()
    {
        lineRenderer = GetComponent<LineRenderer>();
    }
    private void Update()
    {
        coolDownCounter -= Time.deltaTime;

        if (lineRenderer.enabled == true)
        {
            laserStayontimer -= Time.deltaTime;
        }
        if (laserStayontimer <= 0)
        {
            lineRenderer.enabled = false;

        }
    }
    public override void UseSkill()
    {
        if (coolDownCounter > 0) return;
        coolDownCounter = CoolDown;
        hit = new RaycastHit2D();
        Vector3 mousePos = Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, -Camera.main.transform.position.z));
        hit = Physics2D.Raycast(eyesPos.position, (mousePos - eyesPos.position).normalized, laserRange, enemyLayer);

        //Debug.DrawLine(eyesPos.position, hit.point, Color.red, 1f);

        laserStayontimer = laserStayontime;
        lineRenderer.enabled = true;
        lineRenderer.SetPosition(0, eyesPos.position);
        lineRenderer.SetPosition(1, hit.collider != null ? new Vector3(hit.point.x, hit.point.y, 0) : (mousePos - eyesPos.position).normalized * laserRange);

        if (hit.collider != null)
        {
            if (hit.collider.TryGetComponent<BaseDamagable>(out BaseDamagable toDmg))
            {
                toDmg.TakeDamage(laserDmg);
            }
        }
    }
}
