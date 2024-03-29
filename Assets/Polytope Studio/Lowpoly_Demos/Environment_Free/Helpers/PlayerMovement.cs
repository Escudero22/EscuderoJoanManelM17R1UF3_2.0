using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    Map map;
    PlLocomotion playerLocomotion;
    AnimarionManager animationManager;

    public Vector2 movementInput;
    public float moveA;

    public float verticalI;
    public float horizontalI;
    private bool isDancing = false;

    public bool b_input;
    public bool c_input;
    public bool j_input;
    public bool a_input;
    public bool block_input;
    public bool dance_input;
    public AudioSource attackSound; // Referencia al AudioSource que reproducirá el sonido de ataque

    private void Awake()
    {
        animationManager = GetComponent<AnimarionManager>();
        playerLocomotion = GetComponent<PlLocomotion>();
    }
    private void OnEnable()
    {
        if (map == null)
        {
            map = new Map();
            map.Exploration.Move.performed += OnMovePerformed;

            map.PlayerActions.B.performed += i => b_input = true;
            map.PlayerActions.C.performed += i => c_input = true;
            map.Exploration.Jump.performed += i => j_input = true;
            map.PlayerActions.A.performed += i => a_input = true;
            map.Exploration.Dance.performed += i => dance_input = true;
            map.PlayerActions.Block.performed += i => block_input = true;
            map.PlayerActions.B.canceled += i => b_input = false;
            map.PlayerActions.C.canceled += i => c_input = false;
            map.Exploration.Jump.canceled += i => j_input = false;
            map.PlayerActions.A.canceled += i => a_input = false;
            map.PlayerActions.Block.canceled += i => block_input = false;
            map.Exploration.Dance.canceled += i => dance_input = false;



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
        SprintingInput();
        CroachingInput();
        JumpingAction();
        ActionInputAction();
        Dance();
    }
    private void MovementInput()
    {
        verticalI = movementInput.y;
        horizontalI = movementInput.x;
        moveA = Mathf.Clamp01(Mathf.Abs(horizontalI) + Mathf.Abs(verticalI));
        animationManager.UpdateAnimatorValues(0, moveA, playerLocomotion.isSprinting, playerLocomotion.isCroaching);
    }
    private void SprintingInput()
    {
        if (b_input && moveA > 0.5f)
        {
            playerLocomotion.isSprinting = true;
        }
        else
        {
            playerLocomotion.isSprinting = false;
        }
    }
    private void CroachingInput()
    {
        if (c_input)
        {
            Debug.Log("funciona");
            playerLocomotion.isCroaching = true;
        }
        else
        {


            playerLocomotion.isCroaching = false;
        }
    }
    private void JumpingAction()
    {
        if (j_input)
        {
            j_input=false;
            playerLocomotion.Jump();
        }
    }
    private void ActionInputAction()
    {
        if (a_input)
        {
            j_input = false;
            playerLocomotion.Attack();
            // Si hay un AudioSource y tiene un clip de sonido, reproducir el sonido de ataque
            if (attackSound != null && attackSound.clip != null && !j_input)
            {
                attackSound.Play();
            }
        }
        if (block_input)
        {
            block_input = false;
            playerLocomotion.Block();
        }
    }

    private void Dance()
    {
        if (dance_input && !isDancing)
        {
            isDancing = true;
            animationManager.animator.SetBool("IsDancing", true);
            animationManager.PlayTargetAnimation("dance", dance_input);
        }

        if (isDancing)
        {
            // Obtenemos el nombre de la animación actual
            string currentAnimation = animationManager.animator.GetCurrentAnimatorClipInfo(0)[0].clip.name;

            // Si el nombre de la animación actual no es "Dance", significa que ha terminado
            if (currentAnimation != "dance")
            {
                isDancing = false;
                animationManager.animator.SetBool("IsDancing", false);
            }
        }
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
