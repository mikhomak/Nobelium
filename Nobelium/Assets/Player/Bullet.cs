using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField] private float speed = 5f;
    [SerializeField] private Vector2 direction;
    private MovementComponent movementComponent;
    private Rigidbody2D rb2d;

    public void setDirection(Vector2 direction) { this.direction = direction; }

    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
        movementComponent = new MovementComponent(rb2d);
        movementComponent.setSpeed(speed);
    }

    void FixedUpdate()
    {
        movementComponent.movement(direction.x, direction.y);
    }
}
