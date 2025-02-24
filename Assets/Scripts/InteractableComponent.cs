using UnityEngine;

public class InteractableComponent : MonoBehaviour {
    
    public string itemName;
    public int itemMass;
    [SerializeField] protected bool canBeGrabbed = true;

    [SerializeField] protected Collider playerReach;
    [SerializeField] private Transform playerHold;

    [SerializeField] protected Material defaultMaterial;
    [SerializeField] protected Material glowMaterial;

    private Rigidbody _rb;
    private Collider _cl;
    protected Renderer Renderer;
    protected bool PlayerInRange = false;
    private bool _isHeld = false;

    private void Start() {
        _rb = GetComponent<Rigidbody>();
        _cl = GetComponent<Collider>();
        Renderer = GetComponent<Renderer>();

        _rb.mass = itemMass;
        Renderer.material = defaultMaterial;
    }

    private void Update() {
        if (PlayerInRange && Input.GetKeyDown(KeyCode.E)) {
            if (canBeGrabbed) {
                if (!_isHeld){
                    GrabItem();
                }
                else {
                    ReleaseItem();
                }
            }
            else {
                Interact();
            }
        }
    }

    private void OnTriggerEnter(Collider other) {
        if (other == playerReach) {
            PlayerInRange = true;
            Renderer.material = glowMaterial;
        }
    }

    private void OnTriggerExit(Collider other) {
        if (other == playerReach) {
            PlayerInRange = false;
            Renderer.material = defaultMaterial;
        }
    }

    public virtual void Interact() {
        Debug.Log("Interaction avec " + itemName);
    }

    private void GrabItem() {
        _isHeld = true;
        _rb.useGravity = false;
        _rb.isKinematic = true;
        _cl.isTrigger = true;
        transform.SetParent(playerHold);
        transform.localPosition = Vector3.zero;
    }

    private void ReleaseItem(){
    _isHeld = false;
        transform.SetParent(null);
        _rb.useGravity = true;
        _rb.isKinematic = false;
        _cl.isTrigger = false;
    }
}
