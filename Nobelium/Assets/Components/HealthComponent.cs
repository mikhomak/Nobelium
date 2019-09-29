public class HealthComponent : IComponent {
    private float health = 100f;
    private bool activated = true;
    private ICharacter character;

    public void setHealth(float health) { this.health = health; }

    public HealthComponent(ICharacter character) {
        this.character = character;
        addToListeners();
    }

    public void takeDamage(float damage) {
        if (activated == false)
            return;
        health -= damage;
        if (health <= 0) {
            die();
        }
    }

    private void die() {
        character.die();
    }

    public void activate() {
        activated = true;
    }

    public void deactivate() {
        activated = false;
    }

    public void addToListeners() {
        GameManager.instance.addListenerToMainEvents(deactivate, activate);
    }
}
