using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [Header("Stats")]
    [SerializeField] private float speed;
    private Rigidbody2D rb2d;
    private InputController playerPos;

    private MovementComponent movementComponent;

    private void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
        createComponents();
        setStats();
    }

    private void FixedUpdate()
    {
    }

    private void shoot(Vector3 direction)
    {
    }

    private float getDirection()
    {
        return 0f;
    }
    private void setStats()
    {
        movementComponent.setSpeed(speed);
    }

    private void createComponents()
    {
        movementComponent = new MovementComponent(rb2d);
    }

}
