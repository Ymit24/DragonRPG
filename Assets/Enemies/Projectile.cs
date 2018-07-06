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

    void OnTriggerEnter(Collider col)
    {
        var damageable = col.GetComponent(typeof(IDamageable));
        if (damageable != null)
        {
            (damageable as IDamageable).TakeDamage(damageCaused);
        }
    }

}
