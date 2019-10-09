using UnityEngine;

public class Player : MonoBehaviour, ICharacter {
    [Header("Inputs")] [SerializeField] private float horInput;
    [SerializeField] private float verInput;


    [Header("Stats")] [SerializeField] private float speed;
    [SerializeField] private float health;


    private Rigidbody2D rb2d;

    private MovementComponent movementComponent;
    private HealthComponent healthComponent;


    private void Awake() {
        rb2d = GetComponent<Rigidbody2D>();
        createComponents();
        setStats();
    }

    private void setStats() {
        movementComponent.setSpeed(speed);
    }

    private void createComponents() {
        movementComponent = new MovementComponent(rb2d);
        healthComponent = new HealthComponent(this);
    }

    private void FixedUpdate() {
        movementComponent.movement(horInput, verInput);
    }

    public void setInputs(float horInput, float verInput) {
        this.horInput = horInput;
        this.verInput = verInput;
    }

    public void die() {
        GameManager.instance.gameOver();
    }

    public void updateHealth(float health) {
        this.health = health;
    }

    public HealthComponent GetHealthComponent() {
        return healthComponent;
    }
}