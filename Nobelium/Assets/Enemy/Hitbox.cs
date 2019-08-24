using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hitbox : MonoBehaviour, ICharacter
{
    [SerializeField] private float damage;
    [SerializeField] private float health = 20f;
    [SerializeField] private float actualDamage;
    [SerializeField] private float minScale = 0.1f;
    [SerializeField] private float maxScale = 0.5f;
    [SerializeField] private float minLifeTime = 2f;
    [SerializeField] private float maxLifeTime = 4f;

    [SerializeField] private ParticleSystem deathEffectPrefab;
    private HealthComponent healthComponent;

    private void Awake()
    {
        setComponents();
        setStats();
    }

    private void setComponents() {
        healthComponent = new HealthComponent(this);
    }

    private void setStats() {
        healthComponent.setHealth(health);
    }

    private void Start()
    {
        float lifeTime = Random.Range(minLifeTime,maxLifeTime);
        Destroy(gameObject, lifeTime);
    }

    private void FixedUpdate()
    {
        float scale = CommonMethods.getValueInRange(AudioPeer.getAudioBandBuffer(5), minScale, maxScale);
        transform.localScale = new Vector2(scale,scale);
        actualDamage = scale * damage;
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.layer == CommonMethods.HURTBOX_PLAYER)
        {
            collision.GetComponent<IHurtbox>().takeDamage(actualDamage);
        }
    }

    private void OnDestroy()
    {
        Instantiate(deathEffectPrefab, transform.position, transform.rotation);
    }

    public void die()
    {
        Destroy(gameObject);
    }

    public HealthComponent GetHealthComponent()
    {
        return healthComponent;
    }

}
