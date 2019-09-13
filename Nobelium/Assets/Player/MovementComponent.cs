using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementComponent : IComponent
{
    private float speed = 5f;
    private Rigidbody2D rb2d;
    private bool activated = true;

    public float getSpeed() { return speed; }
    public void setSpeed(float speed) { this.speed = speed; }


    public MovementComponent(Rigidbody2D rb2d)
    {
        this.rb2d = rb2d;
        addToListeners();
    }

    public void movement(float horInput, float verInput)
    {
        if (activated)
        {
            rb2d.velocity = new Vector2(horInput, verInput) * speed;
        }
        else
        {
            rb2d.velocity = new Vector2(0, 0);
        }
    }

    public void activate()
    {
        activated = true;
    }

    public void deactivate()
    {
        activated = false;
    }

    public void addToListeners()
    {
        GameManager.instance.addListenerToMainEvents(deactivate, activate);
    }
}
