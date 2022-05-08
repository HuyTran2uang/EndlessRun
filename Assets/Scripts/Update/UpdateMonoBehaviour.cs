using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UpdateMonoBehaviour : MonoBehaviour
{
    protected virtual void Awake()
    {
        LoadComponent();
    }

    protected virtual void Reset()
    {
        LoadComponent();
    }

    protected virtual void Update()
    {
        InputManager();
    }

    protected virtual void LoadComponent() { }

    protected virtual void InputManager() { }
}
