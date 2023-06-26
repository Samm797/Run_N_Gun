using System;
using UnityEngine;

public class KeyboardManager : MonoBehaviour
{
    public static event Action OnInputChanged;

    private void Update()
    {
        // For testing purposes, backspace is the trigger for the event to fire
        // This will be baked into the UI/Settings at some point
        if (Input.GetKeyDown(KeyCode.Backspace))
        {
            OnInputChanged?.Invoke();
        }
    }
}
