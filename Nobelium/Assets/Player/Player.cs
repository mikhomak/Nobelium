using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
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
    }

    private void createComponents()
    {
        movementComponent = new MovementComponent(rb2d);
    }

    private void FixedUpdate()
    {
        movementComponent.movement(horInput);
    }

    public void setInputs(float horInput, float verInput)
    {
        this.horInput = horInput;
        this.verInput = verInput;
    }

}
