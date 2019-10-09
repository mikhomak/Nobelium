public interface ICharacter {
    void die();

    void updateHealth(float health);
    HealthComponent GetHealthComponent();
}