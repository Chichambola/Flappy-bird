using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputReader : MonoBehaviour
{
    private bool _isJumping;
    public bool _isFiring;

    public bool GetIsJump() => ResetBoolValue(ref _isJumping);
    public bool GetIsFiring() => ResetBoolValue(ref _isFiring);
    
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            _isFiring = true;
        }

        if (Input.GetKeyUp(KeyCode.Space))
        {
            _isJumping = true;
        }
    }

    private bool ResetBoolValue(ref bool value)
    {
        bool localValue = value;
        value = false;
        return localValue;
    }
}
