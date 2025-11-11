using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputReader : MonoBehaviour
{
    private const KeyCode JumpButton = KeyCode.Space;
    private const KeyCode FireButton = KeyCode.E;

    private bool _isJumping;
    private bool _isFiring;

    public bool GetIsJump() => ResetBoolValue(ref _isJumping);
    public bool GetIsFiring() => ResetBoolValue(ref _isFiring);
    
    private void Update()
    {
        if (Input.GetKeyDown(FireButton))
        {
            _isFiring = true;
        }

        if (Input.GetKeyUp(JumpButton))
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
