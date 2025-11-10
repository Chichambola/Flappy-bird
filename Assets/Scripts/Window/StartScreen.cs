using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartScreen : Window
{
    public event Action PlayButtonClicked;

    protected override void OnButtonClick()
    {
        PlayButtonClicked?.Invoke();
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
