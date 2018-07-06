using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour {

    public float projectileSpeed;

    float damageCaused;

    public void SetDamage(float damage)
    {
        damageCaused = damage;
    }

    void OnCollisionEnter(Collision col)
    {
        var damageable = col.gameObject.GetComponent(typeof(IDamageable));
        if (damageable != null)
        {
            (damageable as IDamageable).TakeDamage(damageCaused);
        }
        Destroy(gameObject, 0.01f);
    }

}
