using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TeleportSkill : UtillitySkill
{
    Rigidbody2D rb;
    Movement movement;
    Camera cam;
    [SerializeField] float range;

    private void Start()
    {
        movement = GetComponent<Movement>();
        rb = GetComponent<Rigidbody2D>();
        cam = Camera.main;
    }
    public override void UseSkill()
    {

        if (coolDownCounter > 0) return;

        coolDownCounter = settings.CoolDown;
        Vector2 mousePositionWorldSpace = cam.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, -cam.transform.position.z));

        Vector2 playerToMouse = mousePositionWorldSpace - rb.position;
        Vector2 newPosition = playerToMouse.magnitude > range ?
            rb.position + playerToMouse.normalized * range :
            mousePositionWorldSpace;

        rb.position = newPosition;
        movement.ResetVelocity();

    }
}
