using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    Map map;
    AnimarionManager animationManager;

    public Vector2 movementInput;
    private float moveA;

    public float verticalI;
    public float horizontalI;

    private void Awake()
    {
        animationManager = GetComponent<AnimarionManager>();
    }
    private void OnEnable()
    {
        if (map == null)
        {
            map = new Map();
            map.Exploration.Move.performed += OnMovePerformed;
        }
        map.Enable();
    }

    private void OnMovePerformed(InputAction.CallbackContext context)
    {
        movementInput = context.ReadValue<Vector2>();
    }

    private void OnDisable()
    {
        map.Disable();
    }

    public void HandleAllInputs()
    {
        MovementInput();
        //JumpingAction
        //ActionInputAction
    }
    private void MovementInput()
    {
        verticalI = movementInput.y;
        horizontalI = movementInput.x;
        moveA = Mathf.Clamp01(Mathf.Abs(horizontalI) + Mathf.Abs(verticalI));
        animationManager.UpdateAnimatorValues(0, moveA);
    }
}

//[SerializeField] private Rigidbody _rb;
//[SerializeField] private Transform _camera;
//private PlayerInput _pl;
//private Animator _animator;
//private CharacterController _characterController;

//public float speed = 3f;
//public float gravity = -9.18f;
//public float jumpHeight = 3f;
//float turnSmoothTime = 0.1f;

//public Transform groundCheck;
//public float groundDistance = 0.4f;
//public LayerMask groundMask;
//private Vector3 _direction;

//private Vector3 velocity;
//private bool isGrounded;
//// Añade estas variables al principio de tu clase
//float turnSmoothVelocity;


//// Add boolean parameters for animation control
//private bool isDead;
//private bool isWalk;
//private bool isJumping;
//private bool isRun;

//void Awake()
//{
//    _pl = GetComponent<PlayerInput>();
//    _animator = GetComponentInChildren<Animator>();
//    _characterController = GetComponent<CharacterController>();

//    if (_animator == null)
//    {
//        Debug.LogError("Animator component not found on the GameObject.");
//    }
//}
////Cambiar Jump a Trigger.
//void Start()
//{
//    // Suscribe al evento "Move" para activar IsRunning
//    _pl.actions["Move"].performed += ctx => OnMovePerformed(ctx);
//    _pl.actions["Move"].canceled += ctx => OnMoveCanceled(ctx);
//    _pl.actions["Dance"].performed += ctx => Dance();
//    _pl.actions["Jump"].performed += ctx => Jump(ctx);

//}

//void OnMovePerformed(InputAction.CallbackContext context)
//{
//    // Actualiza booleanos según las condiciones
//    isWalk = true;

//    // Establece booleanos en el animator
//    if (_animator != null)
//    {
//        _animator.SetBool("IsWalking", isWalk);
//    }
//}
//void OnMoveCanceled(InputAction.CallbackContext context)
//{
//    // Cuando se deja de pulsar, establece IsWalking en false
//    isWalk = false;

//    // Establece booleanos en el animator
//    if (_animator != null)
//    {
//        _animator.SetBool("IsWalking", isWalk);
//    }
//}
//void Jump(InputAction.CallbackContext context)
//{
//    if (_animator != null)
//    {
//        _animator.SetTrigger("IsJumping");
//    }
//}


//void Update()
//{
//    Vector2 movementInput = _pl.actions["Move"].ReadValue<Vector2>();
//    float x = movementInput.x;
//    float z = movementInput.y;
//    _direction = new Vector3(x,0f,z).normalized;
//    Vector3 move = transform.right * x + transform.forward * z;
//    _characterController.Move(move * speed * Time.deltaTime);

//    isGrounded = Physics.CheckSphere(groundCheck.position, groundDistance, groundMask);
//    if(_direction.magnitude != 0f)
//    {
//        RotatePl();
//    }


//}
//private void RotatePl()
//{

//    //mantiene al jugador orientado en la direccion del movimiento
//    float targetAngle = Mathf.Atan2(_direction.x, _direction.z) * Mathf.Rad2Deg + _camera.eulerAngles.y;
//    float angle = Mathf.SmoothDampAngle(transform.eulerAngles.y, targetAngle, ref turnSmoothVelocity, turnSmoothTime);
//    transform.rotation = Quaternion.Euler(0f, angle, 0f);



//    velocity.y += gravity * Time.deltaTime;
//    _characterController.Move(velocity * Time.deltaTime);
//}
//void Dance()
//{
//    if (_animator != null)
//    {
//        _animator.SetTrigger("dance");
//    }
//}
