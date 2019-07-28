﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputController : MonoBehaviour
{
    private float horInput;
    private float verInput;
    private Player player;

    private void Start()
    {
        player = GetComponent<Player>();
    }



    private void Update()
    {
        getInputs();
        jumping();
        player.setInputs(horInput, verInput);
    }


    private void getInputs()
    {
        horInput = Input.GetAxis("Horizontal");
        verInput = Input.GetAxis("Vertical");
    }

    private void jumping()
    {
        if (Input.GetButtonDown("Jump"))
            player.jump();
    }

}
