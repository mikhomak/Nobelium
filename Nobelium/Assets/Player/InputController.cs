using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputController : MonoBehaviour
{
    private float horInput;
    private float verInput;
    private Player player;
    private Weapon weapon;

    private void Start()
    {
        player = GetComponent<Player>();
        weapon = GetComponentInChildren<Weapon>();
    }

    private void Update()
    {
        getInputs();
        player.setInputs(horInput, verInput);
        weapon.setMousePosition(getWorldMousePosition());
    }

    private Vector3 getWorldMousePosition()
    {
        return Camera.main.ScreenToWorldPoint(Input.mousePosition);
    }

    private void getInputs()
    {
        horInput = Input.GetAxis("Horizontal");
        verInput = Input.GetAxis("Vertical");
    }
}
