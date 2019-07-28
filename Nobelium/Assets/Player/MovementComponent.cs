using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementComponent
{
    private float speed = 5f;
    private float jumpForce = 5f;
    private Rigidbody2D rb2d;
    private float fallSpeed = 3f;

    public float getSpeed() { return speed; }
    public void setSpeed(float speed) { this.speed = speed; }

    public void setFallSpeed(float fallSpeed) { this.fallSpeed = fallSpeed; }
    public float getFallSpeed() { return fallSpeed; }

    public float getJumpForce() { return jumpForce; }
    public void setJumpForce(float jumpForce) { this.jumpForce = jumpForce; }


    public MovementComponent(Rigidbody2D rb2d)
    {
        this.rb2d = rb2d;
    }

    public void movement(float horInput)
    {
        rb2d.AddForce(new Vector2(horInput,0) * speed);
        acceleratedJump();
    }

    public void jump()
    {
        rb2d.AddForce(new Vector2(0, 1) * jumpForce);
    }

    public void acceleratedJump()
    {
        if(rb2d.velocity.y < 0)
        {
            rb2d.velocity += Vector2.up * Physics2D.gravity.y * fallSpeed * Time.deltaTime;
        }
    }


}
