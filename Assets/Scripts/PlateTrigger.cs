using UnityEngine;

public class PlateTrigger : MonoBehaviour {
    
    public BalanceHandler balance;
    public bool isLeftPlate;

    private void OnTriggerEnter(Collider other) {
        InteractableComponent item = other.GetComponent<InteractableComponent>();
        if (item != null) {
            if (isLeftPlate) {
                balance.AddMassToLeft(item.itemMass);
            }
            else {
                balance.AddMassToRight(item.itemMass);
            }
            
        }
        balance.UpdateTargetPositions();
    }

    private void OnTriggerExit(Collider other) {
        InteractableComponent item = other.GetComponent<InteractableComponent>();
        if (item != null) {
            if (isLeftPlate) {
                balance.RemoveMassFromLeft(item.itemMass);
            }
            else {
                balance.RemoveMassFromRight(item.itemMass);
            }
            
        }
        balance.UpdateTargetPositions();
    }
}