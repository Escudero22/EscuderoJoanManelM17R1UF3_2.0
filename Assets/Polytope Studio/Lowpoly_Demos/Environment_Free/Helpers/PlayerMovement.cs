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

    // Update is called once per frame
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

    }

    void Dance()
    {
        if (_animator != null)
        {
            _animator.SetTrigger("dance");
        }
    }
}
