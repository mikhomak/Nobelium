using UnityEngine;

public class Enemy : MonoBehaviour, IEnemy {
    [Header("Stats")] [SerializeField] private float speed;
    [SerializeField] private float health;
    [SerializeField] private float secondPhaseHealthEnterPercentage;
    [SerializeField] private float secondPhaseHealthEnter;

    [Header("References")] [SerializeField]
    private GameObject boxPrefab;

    [SerializeField] private BoxPoints boxPoints;

    [Header("Cooldowns")] [SerializeField] private float boxCooldown = 6f;
    [SerializeField] private float boxTimer = 0f;

    private Rigidbody2D rb2d;
    private HealthComponent healthComponent;
    private MovementComponent movementComponent;


    private void OnEnable() {
        rb2d = GetComponent<Rigidbody2D>();
        createComponents();
        setStats();
        calculateSecondPhaseEnter();
    }

    private void FixedUpdate() {
        createBoxes();
    }

    private void createComponents() {
        healthComponent = new HealthComponent(this);
        movementComponent = new MovementComponent(rb2d);
    }

    private void setStats() {
        movementComponent.setSpeed(speed);
        healthComponent.setHealth(health);
    }


    private void createBoxes() {
        if (AudioPeer.getAudioBandBuffer(0) > 0.1f) {
            if (boxTimer > boxCooldown) {
                int random = Random.Range(4, boxPoints.getMaxPoints() - 1);
                boxPoints.updatePointsTaken();
                for (int i = 0; i < random; i++) {
                    Instantiate(boxPrefab, boxPoints.getRandomPosition(), transform.rotation);
                }

                boxTimer = 0f;
            }
        }

        boxTimer += Time.deltaTime;
    }


    public void die() {
        Destroy(gameObject);
    }

    public void updateHealth(float health) {
        this.health = health;
        if (this.health <= secondPhaseHealthEnter) {
            
        }
    }

    public HealthComponent GetHealthComponent() {
        return healthComponent;
    }

    public void setBoxPoints(BoxPoints boxPoints) {
        this.boxPoints = boxPoints;
    }

    private float calculateSecondPhaseEnter() {
        secondPhaseHealthEnter = health * secondPhaseHealthEnterPercentage / 100f;
    }
}