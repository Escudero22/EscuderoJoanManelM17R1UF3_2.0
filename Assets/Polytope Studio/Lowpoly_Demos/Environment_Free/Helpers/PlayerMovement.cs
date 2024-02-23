using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    private PlayerInput _pl;
    private Animator _animator;
    private CharacterController _characterController;

    public float speed = 3f;
    public float gravity = -9.18f;
    public float jumpHeight = 3f;

    public Transform groundCheck;
    public float groundDistance = 0.4f;
    public LayerMask groundMask;

    private Vector3 velocity;
    private bool isGrounded;

    // Add boolean parameters for animation control
    private bool isDead;
    private bool isWalk;
    private bool isJumping;
    private bool isRun;

    void Awake()
    {
        _pl = GetComponent<PlayerInput>();
        _animator = GetComponentInChildren<Animator>();
        _characterController = GetComponent<CharacterController>();

        if (_animator == null)
        {
            Debug.LogError("Animator component not found on the GameObject.");
        }
    }

    void Start()
    {
        // Suscribe al evento "Move" para activar IsRunning
        _pl.actions["Move"].performed += ctx => OnMovePerformed(ctx);
        _pl.actions["Move"].canceled += ctx => OnMoveCanceled(ctx);
        _pl.actions["Dance"].performed += ctx => Dance();

    }

    void OnMovePerformed(InputAction.CallbackContext context)
    {
        // Actualiza booleanos según las condiciones
        isWalk = true;

        // Establece booleanos en el animator
        if (_animator != null)
        {
            _animator.SetBool("IsWalking", isWalk);
        }
    }
    void OnMoveCanceled(InputAction.CallbackContext context)
    {
        // Cuando se deja de pulsar, establece IsWalking en false
        isWalk = false;

        // Establece booleanos en el animator
        if (_animator != null)
        {
            _animator.SetBool("IsWalking", isWalk);
        }
    }

    void Update()
    {
        Vector2 movementInput = _pl.actions["Move"].ReadValue<Vector2>();
        float x = movementInput.x;
        float z = movementInput.y;

        isGrounded = Physics.CheckSphere(groundCheck.position, groundDistance, groundMask);

        Vector3 move = transform.right * x + transform.forward * z;
        _characterController.Move(move * speed * Time.deltaTime);

        velocity.y += gravity * Time.deltaTime;
        _characterController.Move(velocity * Time.deltaTime);

        //// Update boolean parameters based on conditions
        //isRunning = (x != 0 || z != 0) && isGrounded;
        //isWalking = (x != 0 || z != 0) && !isRunning && isGrounded;
        ////isJumping = !isGrounded;

        //// Set boolean parameters in the animator
        //if (_animator != null)
        //{
        //    _animator.SetBool("IsDead", isDead);
        //    _animator.SetBool("IsRunning", isRunning);
        //    //_animator.SetBool("IsJumping", isJumping);
        //    _animator.SetBool("IsWalking", isWalking);
        //}

    }

    void Dance()
    {
        if (_animator != null)
        {
            _animator.SetTrigger("dance");
        }
    }
}
