using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField] private float speed;
    [SerializeField] private Vector2 direction;
    [SerializeField] private float deathTime = 3f;
    [SerializeField] private float damage;
    [SerializeField] private float minSpeed=3;
    [SerializeField] private float maxSpeed=5;
    [SerializeField] private float minScale=1;
    [SerializeField] private float maxScale=3;
    private MovementComponent movementComponent;
    private Rigidbody2D rb2d;

    public void setDirection(Vector2 direction) { this.direction = direction; }
    public void setSpeed(float speed) { this.speed = speed; }

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

    public void setScaleMultiplier(float multiplier)
    {
        float scale = CommonMethods.getValueInRange(multiplier, minScale, maxScale);
        transform.localScale = new Vector3(1,1,1)*scale;
    }

    public void setSpeedMultiplier(float multiplier)
    {
        speed =  CommonMethods.getValueInRange(multiplier, minSpeed, maxSpeed);
    }

}
