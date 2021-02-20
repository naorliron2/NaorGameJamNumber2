using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Explosion : MonoBehaviour
{
    [SerializeField] float explosionSize;
    [SerializeField] LayerMask layersToHit;
    [SerializeField] GameObject explostionGraphics;
    public int damage;
    private void OnCollisionEnter2D(Collision2D collision)
    {

        Explode();
    }

    void Explode()
    {
        Collider2D[] hitObj = Physics2D.OverlapCircleAll(transform.position, explosionSize, layersToHit);
        GameObject instace = Instantiate(explostionGraphics, transform.position, Quaternion.identity);
        instace.transform.localScale = new Vector3(explosionSize * 10, explosionSize * 10, 1);

        foreach (var col in hitObj)
        {
            if (col.TryGetComponent<PlayerHealth>(out PlayerHealth toDamage))
            {
                Debug.Log(toDamage.gameObject.name);

                toDamage.TakeDamage(damage);
            }
        }
        Destroy(this.gameObject);
    }
}
