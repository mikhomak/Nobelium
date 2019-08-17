using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour, ICharacter
{
    [Header("Stats")]
    [SerializeField] private float speed;
    private Rigidbody2D rb2d;


    private HealthComponent healthComponent;
    private MovementComponent movementComponent;

    private void Awake()
    {
        rb2d = GetComponent<Rigidbody2D>();
        createComponents();
        setStats();
    }

    private void createComponents()
    {
        movementComponent = new MovementComponent(rb2d);
        healthComponent = new HealthComponent(this);
    }

    private void setStats()
    {
        movementComponent.setSpeed(speed);
    }

    

    public void die()
    {
        Destroy(gameObject);
    }

    public HealthComponent GetHealthComponent()
    {
        return healthComponent;
    }
}
