using System;
using UnityEngine;

public class PlayerController : MonoBehaviour {

    [SerializeField] private float speed;
    [SerializeField] private float sensitivity;

    private Camera _camera;
    private Rigidbody _rigidbody;

    [SerializeField] private float cameraXRotation = 0f;

    private void Start() {
        _camera = GetComponentInChildren<Camera>();
        _rigidbody = GetComponent<Rigidbody>();
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    private void Update() {
        float xMov = Input.GetAxisRaw("Horizontal");
        float zMov = Input.GetAxisRaw("Vertical");
        
        Vector3 velocity = transform.TransformDirection(new Vector3(xMov, 0, zMov).normalized) * (speed * Time.fixedDeltaTime);
        _rigidbody.linearVelocity = new Vector3(velocity.x, _rigidbody.linearVelocity.y, velocity.z);

        float mouseX = Input.GetAxis("Mouse X") * sensitivity;
        float mouseY = Input.GetAxis("Mouse Y") * sensitivity;
        
        transform.Rotate(Vector3.up * mouseX);

        cameraXRotation -= mouseY;
        cameraXRotation = Mathf.Clamp(cameraXRotation, -90f, 90f);
        _camera.transform.localRotation = Quaternion.Euler(cameraXRotation, 0f, 0f);
    }
}