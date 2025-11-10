using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class EndScreen : Window
{
    public event Action RestartButtonClicked;

    protected override void OnButtonClick()
    {
        RestartButtonClicked?.Invoke();
    }

    public override void Close()
    {
        gameObject.SetActive(false);
    }

    public override void Open()
    {
        gameObject.SetActive(true);
    }
}
