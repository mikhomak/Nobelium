using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour, IComponent
{

    [SerializeField] private Vector3 mousePosition;
    [SerializeField] private GameObject bulletPrefab;
    [SerializeField] private bool activated = true;
    [SerializeField] private float damage = 1f;
    [SerializeField] private float radius = 0.08f;
    [SerializeField] private GameObject pivot;
    [SerializeField] private GameObject shootPoint;
    [SerializeField] private Vector3 pivotPoint;

    private void FixedUpdate()
    {
        rotate();
        movement();
        shoot();
    }

    private void shoot()
    {
        if (AudioPeer.getAudioBandBuffer(5) > 0.2f)
        {
            GameObject bulletGO = Instantiate(bulletPrefab, shootPoint.transform.position, transform.rotation);
            Bullet bullet = bulletGO.GetComponent<Bullet>();
            bullet.setDirection(transform.up * -1);
            bullet.setSpeedMultiplier(AudioPeer.getAudioBandBuffer(5));
            bullet.setScaleMultiplier(AudioPeer.getAudioBandBuffer(0));
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

    private void movement()
    {
        pivotPoint = pivot.transform.position;
        Vector2 mouseOffset = getDirection();
        transform.position = new Vector2(mouseOffset.x, mouseOffset.y);
        float distance = Vector2.Distance(transform.position, pivotPoint);
        if (distance > radius)
        {
            Vector2 norm = mouseOffset.normalized;
            transform.position = new Vector2(norm.x * radius + pivotPoint.x, norm.y * radius + pivotPoint.y);
        }
        
    }

    public void activate()
    {
        activated = true;
    }

    public void deactivate()
    {
        activated = false;
    }

    public void addToListeners()
    {
        GameManager.instance.addListenerToMainEvents(deactivate, activate);
    }
}
