using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class Enemy : MonoBehaviour, IEnemy {
    [Header("Stats")] [SerializeField] private float speed;
    [SerializeField] private float health;
    [SerializeField] private List<Phase> phases;
    [SerializeField] private int currentPhase = 0;

    [Header("References")] 

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
        phases.ForEach(e => e.calculateHealthEntrance(health));
        phases = phases.OrderBy(e => e.getEnterHealth()).ToList();
        Debug.Log(phases);
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
        if (AudioPeer.getAudioBandBuffer(0) > 0.3f) {
            if (boxTimer > boxCooldown) {
                int random = Random.Range(4, boxPoints.getMaxPoints() - 1);
                boxPoints.updatePointsTaken();
                for (int i = 0; i < random; i++) {
                    EnemyFabric.instance.spawnCubes(boxPoints.getRandomPosition(), transform.rotation);
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
        if (phases.Count > 0 && phases.First().getEnterHealth() >= health) {
            EnemyFabric.instance.changeCurrentPhase(++currentPhase);
            phases.RemoveAt(0);
            Debug.Log("Changed phase");
        }
    }

    public HealthComponent GetHealthComponent() {
        return healthComponent;
    }

    public void setBoxPoints(BoxPoints boxPoints) {
        this.boxPoints = boxPoints;
    }

    [System.Serializable]
    private class Phase {
        public float enterPercentageHealth;
        private float enterHealth;

        public float getEnterHealth() {
            return enterHealth;
        }

        public float calculateHealthEntrance(float maxHealth) {
            enterHealth = maxHealth * enterPercentageHealth / 100f;
            return enterHealth;
        }
    }
}