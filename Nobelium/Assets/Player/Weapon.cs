using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{

    [SerializeField] private Vector3 mousePosition;
    [SerializeField] private float rotationSpeed;
    [SerializeField] private GameObject bulletPrefab;

    private void FixedUpdate()
    {
        rotate();
        shoot();
    }

    private void shoot()
    {
        if(AudioPeer.getFreqBands(2) > 1.2f)
        {
            GameObject bulletGO = Instantiate(bulletPrefab, transform.position, Quaternion.identity);
            Bullet bullet = bulletGO.GetComponent<Bullet>();
            bulletGO.transform.localScale = new Vector3(1,1,1) * AudioPeer.getFreqBands(5) * 1.2f;
            bullet.setDirection(transform.up);
        }
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
