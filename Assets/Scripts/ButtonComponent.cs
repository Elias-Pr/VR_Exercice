using UnityEngine;

public class ButtonComponent : InteractableComponent {
    [SerializeField] private DigicodeHandler digicodeManager;
    [SerializeField] private int buttonValue;

    [SerializeField] private Material pressedMaterial;
    
    private bool _isPressed = false;

    private void Start() {
        Renderer = GetComponent<Renderer>();
        canBeGrabbed = false;
    }

    public override void Interact() {
        if (!_isPressed)
        {
            _isPressed = true;
            Renderer.material = pressedMaterial;
            digicodeManager.PressButton(buttonValue, this);
        }
    }
    
    private void OnTriggerEnter(Collider other) {
        if (other == playerReach && !_isPressed)
        {
            PlayerInRange = true;
            Renderer.material = glowMaterial;
        }

        else
        {
            PlayerInRange = false;
        }
    }

    private void OnTriggerExit(Collider other) {
        if (other == playerReach && !_isPressed)
        {
            PlayerInRange = false;
            Renderer.material = defaultMaterial;
        }
        else if (other == playerReach && _isPressed)
        {
            PlayerInRange = false;
            Renderer.material = pressedMaterial;
        }
    }

    public void ResetButton() {
        _isPressed = false;
        Renderer.material = defaultMaterial;
    }
}