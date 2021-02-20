using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlimeSightChecker : MonoBehaviour
{
    [SerializeField] float SightDist;
    [SerializeField] Transform player;
    [SerializeField] LayerMask mask;
    public bool PlayerInSight = false;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Vector3.Distance(player.position, (transform.position + new Vector3(0, 0.5f, 0))) < SightDist)
        {
            RaycastHit2D hit;
            if (hit = Physics2D.Raycast(transform.position + new Vector3(0, 0.5f, 0), ((player.position + new Vector3(0, 0.5f, 0)) - (transform.position + new Vector3(0, 0.5f, 0))).normalized, SightDist, mask))
            {
                Debug.DrawLine(transform.position + new Vector3(0, 0.5f, 0), hit.point, Color.red, 1);

                PlayerInSight = hit.collider.CompareTag("Player");
            }

        }
        else
        {
            PlayerInSight = false;
        }
    }
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, SightDist);
    }
}
