using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerLook : MonoBehaviour
{
    [Header("External")]
    [SerializeField] private Camera playerCamera;

    [Header("Internal")]
    [SerializeField] private float sensetivity;
    [SerializeField] private float xRotation;
    [SerializeField] private float yRotation;
    [SerializeField] private float xMouse;
    [SerializeField] private float yMouse;

    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }
    void Update()
    {
        UpdateCamera();        
    }

    private void OnLook(InputValue input)
    {
        xMouse = input.Get<Vector2>().x;
        yMouse = input.Get<Vector2>().y;
    }
    private void OnLookStop(InputValue input)
    {
        xMouse = input.Get<Vector2>().x;
        yMouse = input.Get<Vector2>().y;
    }
    private void UpdateCamera()
    {
        xMouse *= sensetivity * Time.deltaTime;
        yMouse *= sensetivity * Time.deltaTime;

        xRotation += -yMouse;
        xRotation = Mathf.Clamp(xRotation, -90, 90);
        yRotation += xMouse;

        transform.rotation = Quaternion.Euler(0, yRotation, 0);
        playerCamera.transform.localRotation = Quaternion.Euler(xRotation, 0, 0);

    }
}
