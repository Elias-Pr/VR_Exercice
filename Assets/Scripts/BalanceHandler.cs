using UnityEngine;

public class BalanceHandler : MonoBehaviour {
    
    [SerializeField] private Transform leftPlate;
    [SerializeField] private Transform rightPlate;
    [SerializeField] private GameObject door;

    private float _tolerance = 0.2f;
    private float _lerpSpeed = 0.5f;

    private float _leftMass;
    private float _rightMass;
    private Vector3 _leftTargetPosition;
    private Vector3 _rightTargetPosition;

    private void Start() {
        _leftTargetPosition = leftPlate.localPosition;
        _rightTargetPosition = rightPlate.localPosition;
    }

    private void Update() {
        //UpdateTargetPositions();
        //MovePlates();
    }

    public void AddMassToLeft(float mass) {
        _leftMass += mass;
    }

    public void RemoveMassFromLeft(float mass) {
        _leftMass -= mass;
    }

    public void AddMassToRight(float mass){
    _rightMass += mass;
    }

    public void RemoveMassFromRight(float mass) {
        _rightMass -= mass;
    }

    public void UpdateTargetPositions() {
        if (Mathf.Abs(_leftMass - _rightMass) < _tolerance)
        {
            //_leftTargetPosition.y = 2;
            //_rightTargetPosition.y = 2;
            
            OpenDoor();
        }
        /*else if (_leftMass > _rightMass)
        {
            _leftTargetPosition.y = 1;
            _rightTargetPosition.y = 3;
        }
        else
        {
            _leftTargetPosition.y = 3;
            _rightTargetPosition.y = 1;
        }*/
    }

    /*private void MovePlates() {
        leftPlate.localPosition = Vector3.Lerp(leftPlate.localPosition, _leftTargetPosition, _lerpSpeed * Time.deltaTime);
        rightPlate.localPosition = Vector3.Lerp(rightPlate.localPosition, _rightTargetPosition, _lerpSpeed * Time.deltaTime);
    }*/

    private void OpenDoor() {
        Destroy(door.gameObject);
    }
}