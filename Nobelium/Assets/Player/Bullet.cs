using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField] private float speed = 5f;
    [SerializeField] private Vector2 direction;
    [SerializeField] private float deathTime = 3f;
    [SerializeField] private float damage;
    [SerializeField] private float scale;
    private MovementComponent movementComponent;
    private Rigidbody2D rb2d;

    public void setDirection(Vector2 direction) { this.direction = direction; }

    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
        createComponents();
        setStats();
        Destroy(gameObject, deathTime);
    }

    private void createComponents()
    {
        movementComponent = new MovementComponent(rb2d);
    }

    private void setStats()
    {
        movementComponent.setSpeed(speed);
    }

    void FixedUpdate()
    {
        movementComponent.movement(direction.x, direction.y);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        
    }
}
