using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PcInputs : IInput
{
    public float Horizontal => Input.GetAxis("Horizontal");

    public float Vertical => Input.GetAxis("Vertical");

    public bool Jump => Input.GetButtonDown("Jump");

    public bool Attack => Input.GetButtonDown("Attack");

}
