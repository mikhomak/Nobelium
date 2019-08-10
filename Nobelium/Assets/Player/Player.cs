using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour, ICharacter
{
    [Header("Inputs")]
    [SerializeField] private float horInput;
    [SerializeField] private float verInput;


    [Header("Stats")]
    [SerializeField] private float speed;


    private Rigidbody2D rb2d;

    private MovementComponent movementComponent;



    private void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
        createComponents();
        setStats();
    }

    private void setStats()
    {
        movementComponent.setSpeed(speed);
    }

    private void createComponents()
    {
        movementComponent = new MovementComponent(rb2d);
    }

    private void FixedUpdate()
    {
        movementComponent.movement(horInput, verInput);
    }

    public void setInputs(float horInput, float verInput)
    {
        this.horInput = horInput;
        this.verInput = verInput;
    }

    public void die()
    {
        GameManager.instance.gameOver();
    }
}
