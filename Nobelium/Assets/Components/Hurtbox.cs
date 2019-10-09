using UnityEngine;

public class Hurtbox : MonoBehaviour, IHurtbox {
    private ICharacter character;
    private HealthComponent healthComponent;
    [SerializeField] private bool activated = true;
    [SerializeField] private float damageMultiplier = 1;

    private void Start() {
        character = GetComponentInParent<ICharacter>();
        healthComponent = character.GetHealthComponent();
    }

    public void deactivate() {
        activated = false;
    }

    public void activate() {
        activated = true;
    }

    public void addToListeners() {
        GameManager.instance.addListenerToMainEvents(deactivate, activate);
    }

    public void takeDamage(float damage) {
        if (healthComponent == null) {
            Debug.Log("Health Component is null at" + character);
        }
        healthComponent?.takeDamage(damage * damageMultiplier);
    }
}