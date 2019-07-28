using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthComponent : MonoBehaviour
{
    private float health = 100f;
    private float damage = 10f;

    private void takeDamage(float health)
    {
        health -= damage;
    }

    private void die()
    {
        Destroy(this.gameObject);
    }
}
