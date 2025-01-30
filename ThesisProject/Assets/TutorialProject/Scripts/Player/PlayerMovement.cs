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
    [SerializeField] private float MovementSpeed
    {
        get
        {
            if (isCrouching)
                return movementSpeed * crouchMultiplier;
            else if (isSprinting)
                return movementSpeed * sprintMultiplier;
            else
                return movementSpeed;
        }
    }
    [SerializeField] private float maxVelocity
    {
        get
        {
            return MovementSpeed;
        }
    }
    [SerializeField] private bool isSprinting = false;
    [SerializeField] private float sprintMultiplier;
    [SerializeField] private bool isCrouching = false;
    [SerializeField] private float crouchMultiplier;
    [SerializeField] private float crouchHeightLoss;

    [SerializeField] private float jumpForce;
    [SerializeField] private bool isGrounded;

    [SerializeField]
    private float setMaxVelocity;
    [SerializeField]
    private Vector3 currentVelocity;

    private Vector3 forceToAdd;

    void Start()
    {
        characterRB = GetComponent<Rigidbody>();    
        characterRB.maxLinearVelocity = movementSpeed;
    }
    void Update()
    {
        //ResetForce();

        UpdateMovement();   
        if(characterRB.maxLinearVelocity != maxVelocity)
            characterRB.maxLinearVelocity = maxVelocity;

        currentVelocity = characterRB.linearVelocity;
        setMaxVelocity = characterRB.maxLinearVelocity;

        //ApplyForce();
    }
    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.CompareTag("Ground"))
            isGrounded = true;
    }

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
        movementVector = new Vector3(vec.x, 0, vec.z);

        characterRB.AddForce(movementVector * MovementSpeed, ForceMode.Impulse);
    }

    void ApplyForce()
    {
        characterRB.AddForce(forceToAdd, ForceMode.Impulse);
    }
    void IncreaseForce(Vector3 forceIncrease)
    {
        forceToAdd += forceIncrease;
    }
    void ResetForce()
    {
        forceToAdd = Vector3.zero;
    }

    /* Challenge Yourself*/
    void OnJump()
    {
        if (isGrounded)
        {
            characterRB.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
            isGrounded= false;
        }
    }

    void OnSprint() { isSprinting = true; }
    void OnSprintStop() { isSprinting = false; }

    void OnCrouch() 
    { 
        isCrouching = true;
        GetComponent<CapsuleCollider>().height -= 1.161189f;
        transform.localScale -= 0.25f * new Vector3( 0,1, 0);
    }
    void OnCrouchStop() 
    { 
        isCrouching = false;
        GetComponent<CapsuleCollider>().height += 1.161189f;
        transform.localScale += 0.25f * new Vector3(0, 1, 0);
    }
}
