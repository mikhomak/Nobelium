using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [Header("Inputs")]
    [SerializeField] private float horInput;
    [SerializeField] private float verInput;
   

    public void setInputs(float horInput, float verInput)
    {
        this.horInput = horInput;
        this.verInput = verInput;
    }

}
