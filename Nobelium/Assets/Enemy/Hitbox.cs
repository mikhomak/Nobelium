using System.Collections.Generic;
using UnityEngine;

public class Hitbox : MonoBehaviour, ICharacter {
    [SerializeField] private float damage;
    [SerializeField] private float health = 20f;
    [SerializeField] private float actualDamage;
    [SerializeField] private float minScale = 0.1f;
    [SerializeField] private float maxScale = 0.5f;
    [SerializeField] private float minLifeTime = 2f;
    [SerializeField] private float maxLifeTime = 4f;
    [SerializeField] private float minShootTime = 0.7f;
    [SerializeField] private float maxShootTime = 1.7f;
    [SerializeField] private float shootTime;
    [SerializeField] private float shootTimer;
    [Header("Movement")] [SerializeField] private bool phase3 = false;
    [SerializeField] private float minSpeed = 0.09f;
    [SerializeField] private float maxSpeed = 0.4f;
    [SerializeField] private Vector2 direction;

    [Header("References")] [SerializeField]
    private ParticleSystem deathEffectPrefab;

    [SerializeField] private GameObject bulletPrefab;
    [SerializeField] private List<Transform> bulletPoints;
    [SerializeField] private List<Vector3> bulletDirection = new List<Vector3>();
    private HealthComponent healthComponent;
    private MovementComponent movementComponent;
    private Rigidbody2D rb2d;

    private void Awake() {
        rb2d = GetComponent<Rigidbody2D>();
        setComponents();
        setStats();
    }

    private void setComponents() {
        healthComponent = new HealthComponent(this);
        if (phase3) {
            movementComponent = new MovementComponent(rb2d);
        }
    }

    private void setStats() {
        healthComponent.setHealth(health);
    }

    private void Start() {
        float lifeTime = Random.Range(minLifeTime, maxLifeTime);
        Destroy(gameObject, lifeTime);
        shootTime = Random.Range(minShootTime, maxShootTime);
    }

    private void FixedUpdate() {
        float scale = CommonMethods.getValueInRange(AudioPeer.getAudioBandBuffer(5), minScale, maxScale);
        transform.localScale = new Vector2(scale, scale);
        actualDamage = scale * damage;
        if (shootTimer > shootTime) {
            shoot();
            shootTimer = 0f;
        }

        shootTimer += Time.deltaTime;
        if (phase3) {
            direction = new Vector2(Random.Range(-1, 1), Random.Range(-1, 1));
            movementComponent.movement(direction.x, direction.y);
            movementComponent.setSpeed(CommonMethods.getValueInRange(AudioPeer.getAudioBandBuffer(5), minSpeed,
                maxSpeed));
        }
    }

    private void shoot() {
        if (bulletPoints.Count > 4)
            return;
        for (int i = 0; i < bulletPoints.Count; i++) {
            setDirections();
            GameObject bulletGO = Instantiate(bulletPrefab, bulletPoints[i].transform.position, transform.rotation);
            EnemyBullet bullet = bulletGO.GetComponent<EnemyBullet>();
            bullet.setDirection(bulletDirection[i]);
        }
    }

    private void setDirections() {
        bulletDirection.Clear();
        bulletDirection.Add(transform.up * -1f);
        bulletDirection.Add(transform.up);
        bulletDirection.Add(transform.right * -1f);
        bulletDirection.Add(transform.right);
    }

    private void OnTriggerEnter2D(Collider2D collision) {
        if (collision.gameObject.layer == CommonMethods.HURTBOX_PLAYER) {
            collision.GetComponent<IHurtbox>().takeDamage(actualDamage);
        }
    }

    private void OnDestroy() {
        Instantiate(deathEffectPrefab, transform.position, transform.rotation);
    }

    public void die() {
        Destroy(gameObject);
    }

    public void updateHealth(float health) {
        this.health = health;
    }

    public HealthComponent GetHealthComponent() {
        return healthComponent;
    }
}