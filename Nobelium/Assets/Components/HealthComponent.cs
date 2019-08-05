using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthComponent : MonoBehaviour, IComponent
{
    private float health = 100f;
    private bool activated = true;
    private void takeDamage(float health, float damage)
    {
        if (activated == false)
            return;
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

    public void activate()
    {
        activated = true;
    }

    public void desactivate()
    {
        activated = false;
    }
}
