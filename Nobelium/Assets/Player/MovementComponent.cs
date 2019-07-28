using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementComponent
{
    private float speed = 5f;
    private Rigidbody2D rb2d;

    public float getSpeed() { return speed; }
    public void setSpeed(float speed) { this.speed = speed; }

    public MovementComponent(Rigidbody2D rb2d)
    {
        this.rb2d = rb2d;
    }

    public void movement(float horInput, float verInput)
    {
        rb2d.AddForce(new Vector2(horInput, verInput) * speed * Time.deltaTime);
    }
}
