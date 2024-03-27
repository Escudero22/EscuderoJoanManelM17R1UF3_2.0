using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlLocomotion : MonoBehaviour
{
    PlayerManager plManager;
    AnimarionManager animatorManager;
    PlayerMovement inputManager;
    Vector3 moveDir;
    Transform cameraObject;
    Rigidbody plRigidBody;
    private Animator _animator;

    [Header("Falling")]
    public float inAirTimer;
    public float leapingVelocity;
    public float fallingSpeed;
    public float rayCastHeightOffset = 0.5f;
    public LayerMask groundLayer;
    public float maxDistance = 1;
    [Header("Movement Flags")]
    public bool isSprinting;
    public bool isCroaching;
    public bool isGrounded;

    [Header("Speeds")]
    public float walkinSpeed = 3.5f;
    public float speed = 5;
    public float sprintSpeed = 7.5f;
    public float rotationSpeed = 10;
    private void Awake()
    {
        plManager = GetComponent<PlayerManager>();
        animatorManager = GetComponent<AnimarionManager>();
        inputManager = GetComponent<PlayerMovement>();
        plRigidBody = GetComponent<Rigidbody>();
        cameraObject = Camera.main.transform;
        _animator = GetComponentInChildren<Animator>();

    }

    public void AllMovement()
    {
        FallingAndLanding();
        //if (plManager.isInteract)
        //    return;

        Movement();
        Rotation();
    }
    private void Movement()
    {
        moveDir = cameraObject.forward * inputManager.verticalI;
        moveDir = moveDir + cameraObject.right * inputManager.horizontalI;
        moveDir.Normalize();
        moveDir.y = 0;

        if (isSprinting)
        {
            Debug.Log(inputManager.moveA);
            moveDir = moveDir * sprintSpeed;

        }
        else if (isCroaching)
        {

            Debug.Log(inputManager.moveA);
            moveDir = moveDir * speed;

        }
        else
        {
            moveDir = moveDir * walkinSpeed;
        }



        Vector3 moveVelocity = moveDir;
        plRigidBody.velocity = moveVelocity + Vector3.up * plRigidBody.velocity.y;
    }

    private void Rotation()
    {
        if (!_animator.GetBool("IsDancing"))
        {
            transform.rotation = Quaternion.Euler(0f, cameraObject.eulerAngles.y, 0f);
        }


        //Vector3 targetDir = Vector3.zero;

        //targetDir = cameraObject.forward * inputManager.verticalI;
        //targetDir = targetDir + cameraObject.right * inputManager.horizontalI;
        //targetDir.Normalize();
        //targetDir.y = 0;

        //if(targetDir == Vector3.zero)
        //    targetDir = transform.forward;

        //Quaternion targetRotation = Quaternion.LookRotation(targetDir);
        //Quaternion playerRotation = Quaternion.Slerp(transform.rotation, targetRotation, rotationSpeed * Time.deltaTime);

        //transform.rotation = playerRotation;
    }

    private void FallingAndLanding()
    {
        RaycastHit hit;
        Vector3 rCastOrigin = transform.position;
        rCastOrigin.y = rCastOrigin.y + rayCastHeightOffset;
        if (!isGrounded)
        {
            if (!plManager.isInteract)
            {
                animatorManager.PlayTargetAnimation("fall", true);
            }
            inAirTimer = inAirTimer + Time.deltaTime;
            plRigidBody.AddForce(transform.forward * leapingVelocity);
            plRigidBody.AddForce(-Vector3.up * fallingSpeed * inAirTimer);
        }

        if (Physics.SphereCast(rCastOrigin, 0.9f, -Vector3.up, out hit,maxDistance, groundLayer))
        {
            Debug.Log("hola");
            if (!isGrounded && !plManager.isInteract)
            {
                Debug.Log("adios");

                animatorManager.PlayTargetAnimation("land", true);
            }
            inAirTimer = 0;
            isGrounded = true;
        }
        else
        {
            isGrounded = false;
        }
    }
}
