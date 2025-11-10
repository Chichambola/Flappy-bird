using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public abstract class Window : MonoBehaviour
{
    [SerializeField] private Button _actionButton;

    protected Button ActionButton => _actionButton;
    protected int MinAlphaValue = 0;
    protected int MaxAlphaValue = 1;

    private void OnEnable()
    {
        _actionButton.onClick.AddListener(OnButtonClick);
    }

    private void OnDisable()
    {
        _actionButton.onClick.RemoveListener(OnButtonClick);
    }

    protected abstract void OnButtonClick();
    public abstract void Close();
    public abstract void Open();
}
