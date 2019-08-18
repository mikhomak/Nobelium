﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class Enemy : MonoBehaviour, ICharacter
{
    [Header("Stats")]
    [SerializeField] private float speed;
    [SerializeField] private float health;
    [Header("References")]
    [SerializeField] private GameObject boxPrefab;
    [SerializeField] private BoxPoints boxPoints;

    [Header("Cooldowns")]
    [SerializeField] private float boxCooldown = 6f;
    [SerializeField] private float boxTimer = 0f;


    private Rigidbody2D rb2d;


    private HealthComponent healthComponent;
    private MovementComponent movementComponent;

    private void Awake()
    {
        rb2d = GetComponent<Rigidbody2D>();
        createComponents();
        setStats();
    }

    private void FixedUpdate() {
        createBoxes();
    }

    private void createComponents()
    {
        movementComponent = new MovementComponent(rb2d);
        healthComponent = new HealthComponent(this);
    }

    private void setStats()
    {
        movementComponent.setSpeed(speed);
        healthComponent.setHealth(health);
    }


    private void createBoxes() {
        if (AudioPeer.getAudioBandBuffer(0) > 0.1f) {
            if (boxTimer > boxCooldown)
            {
                int random = Random.Range(0,boxPoints.getMaxPoints()-1);
                boxPoints.updatePointsTaken();
                for(int i = 0; i < random; i++)
                {
                    Instantiate(boxPrefab, boxPoints.getRandomPosition(), transform.rotation);
                }
                boxTimer = 0f;
            }
        }
        boxTimer += Time.deltaTime;
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
