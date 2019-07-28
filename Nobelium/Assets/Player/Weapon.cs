using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{

    [SerializeField] private Vector3 mousePosition;
    [SerializeField] private float rotationSpeed;

    private void FixedUpdate()
    {
        rotate();
    }


    public void setMousePosition(Vector3 position)
    {
        this.mousePosition = position;
    }

    private void rotate()
    {
        Vector2 direction = mousePosition - transform.parent.position;
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg + 90;
        transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);
    }

}
