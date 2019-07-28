using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthComponent : MonoBehaviour
{
    private float health = 100f;

    private void takeDamage(float health, float damage)
    {
        health -= damage;
        if (health <= 0)
        {
            die();
        }
    }

    private void die()
    {
        Destroy(this.gameObject);
    }
}
