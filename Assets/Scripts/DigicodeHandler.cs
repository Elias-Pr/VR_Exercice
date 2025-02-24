using System.Collections.Generic;
using UnityEngine;

public class DigicodeHandler : MonoBehaviour {
    
    [SerializeField] private string correctCode = "384610";
    [SerializeField] private ButtonComponent[] buttons;

    private List<int> _enteredCode = new List<int>();

    public void PressButton(int value, ButtonComponent button) {
        _enteredCode.Add(value);

        if (_enteredCode.Count == 6)
        {
            CheckCode();
        }
    }

    private void CheckCode() {
        string enteredString = string.Join("", _enteredCode);

        if (enteredString == correctCode)
        {
            Win();
        }
        else
        {
            Debug.Log("Wrong Code!");
            ResetButtons();
        }
    }

    private void ResetButtons() {
        _enteredCode.Clear();
        foreach (ButtonComponent button in buttons)
        {
            button.ResetButton();
        }
    }

    private void Win() {
        Debug.Log("You win !!!");
    }
}