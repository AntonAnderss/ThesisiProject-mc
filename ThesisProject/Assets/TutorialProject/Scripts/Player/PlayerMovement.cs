using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    [Header("External")]
    [SerializeField] private Rigidbody characterRB;

    [Header("Internal")]
    [SerializeField] private Vector3 movementInput;
    [SerializeField] private Vector3 movementVector;
    [SerializeField] private float movementSpeed;

    void Start()
    {
        GetComponent<Rigidbody>();    
    }
    void Update()
    {
        UpdateMovement();   
    }

    /* Custom Methods */
    void OnMovement(InputValue input)
    {
        movementInput = input.Get<Vector2>();
    }

    void OnMovementStop(InputValue input)
    {
        movementInput = input.Get<Vector2>();
    }

    void UpdateMovement()
    {
        if (movementInput == null)
            return;

        Vector3 vec = movementInput.x * transform.right + movementInput.y * transform.forward;
        movementVector = new Vector3(vec.x, characterRB.linearVelocity.y, vec.z);

        characterRB.linearVelocity = movementVector * Time.fixedDeltaTime * movementSpeed;
        //transform.Translate(movementVector * Time.fixedDeltaTime * movementSpeed);
    }
}
