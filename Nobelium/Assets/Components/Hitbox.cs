using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hitbox : MonoBehaviour
{
    [SerializeField] private float damage;
    [SerializeField] private float actualDamage;
    [SerializeField] private float minScale = 0.1f;
    [SerializeField] private float maxScale = 0.5f;
    [SerializeField] private float lifeTime = 2f;


    private void Start()
    {
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
        if(collision.gameObject.layer == CommonMethods.HURTBOX)
        {
            collision.GetComponent<IHurtbox>().takeDamage(actualDamage);
        }
    }

}
