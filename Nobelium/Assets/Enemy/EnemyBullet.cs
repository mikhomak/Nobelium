using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBullet : MonoBehaviour, IComponent
{
    [SerializeField] private bool activated = true;
    [SerializeField] private float minSpeed;
    [SerializeField] private float maxSpeed;
    [SerializeField] private float minDamage;
    [SerializeField] private float maxDamage;
    [SerializeField] private float actualSpeed;
    [SerializeField] private float actualDamage;
    [SerializeField] private float liveTime;
    [SerializeField] private Vector2 direction;
    [SerializeField] private ParticleSystem deathEffect;
    private MovementComponent movementComponent;
    private Rigidbody2D rb2d;

    private void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
        actualDamage = CommonMethods.getValueInRange(AudioPeer.getAudioBandBuffer(5), minDamage, maxDamage);
        actualSpeed = CommonMethods.getValueInRange(AudioPeer.getAudioBandBuffer(5), minSpeed, maxSpeed);
        createComponents();
        setStats();
        Destroy(gameObject, liveTime);
    }

    private void createComponents() {
        movementComponent = new MovementComponent(rb2d);
    }

    private void setStats()
    {
        movementComponent.setSpeed(actualSpeed);
    }

    private void FixedUpdate()
    {
        movement();
    }

    private void movement() {
        movementComponent.movement(direction.x, direction.y);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.layer == CommonMethods.HURTBOX_PLAYER)
        {
            collision.GetComponent<IHurtbox>().takeDamage(actualDamage);
            Destroy(gameObject);
        }
    }

    private void OnDestroy()
    {
        Instantiate(deathEffect, transform.position, transform.rotation);
    }

    public void setDirection(Vector2 direction) { this.direction = direction; }

    public void activate()
    {
        activated = true;
    }

    public void deactivate()
    {
        activated = false;
    }

    public void addToListeners()
    {
        GameManager.instance.addListenerToMainEvents(deactivate, activate);
    }
}
