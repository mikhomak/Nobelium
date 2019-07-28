using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{

    [SerializeField] private Vector3 mousePosition;
    [SerializeField] private GameObject bulletPrefab;
    [SerializeField] private float fireRate = 0.01f;
    [SerializeField] private float fireRateTimer = 0f;

    private void FixedUpdate()
    {
        rotate();
        shoot();
    }

    private void shoot()
    {
        if (AudioPeer.getFreqBands(5) > 1.2f)
        {
                GameObject bulletGO = Instantiate(bulletPrefab, transform.position, transform.rotation);
                Bullet bullet = bulletGO.GetComponent<Bullet>();
                float scale = AudioPeer.getFreqBands(0) > 1 ? AudioPeer.getFreqBands(0) : 1;
                bulletGO.transform.localScale = new Vector3(1, 1, 1) * scale * 1.2f;
                bullet.setDirection(transform.up * -1);
                fireRateTimer = 0f;
        }
        fireRateTimer += Time.deltaTime;

    }


    public void setMousePosition(Vector3 position)
    {
        this.mousePosition = position;
    }

    private Vector2 getDirection()
    {
        return mousePosition - transform.parent.position;
    }

    private void rotate()
    {
        Vector2 direction = getDirection();
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg + 90;
        transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);
    }

}
