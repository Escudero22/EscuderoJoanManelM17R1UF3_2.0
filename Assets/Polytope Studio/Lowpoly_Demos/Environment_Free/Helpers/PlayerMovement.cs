using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    private PlayerInput _pl;
    private Animator _animator;
    private CharacterController _characterController;

    public float speed = 5f;
    public float gravity = -9.18f;
    public float jumpHeight = 3f;

    public Transform groundCheck;
    public float groundDistance = 0.4f;
    public LayerMask groundMask;

    private Vector3 velocity;
    private bool isGrounded;

    // Add boolean parameters for animation control
    private bool isDead;
    private bool isRunning;
    private bool isJumping;
    private bool isWalking;

    void Awake()
    {
        _pl = GetComponent<PlayerInput>();
        _animator = GetComponent<Animator>();
        _characterController = GetComponent<CharacterController>();

        if (_animator == null)
        {
            Debug.LogError("Animator component not found on the GameObject.");
        }
    }

    void Start()
    {
        _pl.actions["Dance"].performed += ctx => Dance();
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
