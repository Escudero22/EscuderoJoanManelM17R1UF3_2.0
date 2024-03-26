using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlLocomotion : MonoBehaviour
{
    PlayerMovement inputManager;
    Vector3 moveDir;
    Transform cameraObject;
    Rigidbody plRigidBody;
    private Animator _animator;

    public bool isSprinting;
    public bool isCroaching;
    public float walkinSpeed = 3.5f;
    public float speed = 5;
    public float sprintSpeed = 7.5f;
    public float rotationSpeed = 10;
    private void Awake()
    {
        inputManager = GetComponent<PlayerMovement>();
        plRigidBody = GetComponent<Rigidbody>();
        cameraObject = Camera.main.transform;
        _animator = GetComponentInChildren<Animator>();

    }

    public void AllMovement()
    {
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
}
