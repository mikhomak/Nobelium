using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BodyHitbox : MonoBehaviour, IComponent
{
    [SerializeField] private bool activated = true;
    [SerializeField] private float damage;


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.layer == CommonMethods.HURTBOX_PLAYER)
        {
            collision.GetComponent<IHurtbox>().takeDamage(damage);
        }
    }

    public void activate()
    {
        activated = true;
    }

    public void addToListeners()
    {
        GameManager.instance.addListenerToMainEvents(deactivate, activate);
    }

    public void deactivate()
    {
        activated = false;
    }
}
